using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using Vogen;
var customResolver = CompositeResolver.Create(
	new SomeIdMessagePackFormatter()
);
var finalResolver = CompositeResolver.Create(
	// customResolver,
	AttributeFormatterResolver.Instance,
	StandardResolverAllowPrivate.Instance
);
MessagePackSerializer.DefaultOptions = MessagePackSerializer.DefaultOptions.WithResolver(finalResolver);

Result<Foo> foo = new Foo(SomeId.From(Guid.NewGuid()), 123);
Result<Foo> foo2 = new SomeError();
// var foo = new Foo(SomeId.From(Guid.NewGuid()), 123);
Console.WriteLine($"Original: {foo}");
Console.WriteLine($"Original: {foo2}");

var bytes = MessagePackSerializer.Serialize(foo);
Console.WriteLine($"Serialized: {bytes.Length}");
var bytes2 = MessagePackSerializer.Serialize(foo2);
Console.WriteLine($"Serialized: {bytes2.Length}");
var fooDe = MessagePackSerializer.Deserialize<Result<Foo>>(bytes);
var fooDe2 = MessagePackSerializer.Deserialize<Result<Foo>>(bytes2);
Console.WriteLine($"Deserialized: {fooDe}");
Console.WriteLine($"Deserialized: {fooDe2}");

[MessagePackObject]
public record Foo(
	[property: Key(0)]
	SomeId Id,
	[property: Key(1)]
	int X
);

public record SomeError() : Error(
	"hi", 1, ErrorKind.BadInput
);

[MessagePackFormatter(typeof(SomeIdMessagePackFormatter))]
[ValueObject<Guid>(Conversions.MessagePack)]
public readonly partial struct SomeId;

public class ResultFormatter<T> : IMessagePackFormatter<Result<T>>
{
	public Result<T> Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
	{
		var success = reader.ReadBoolean();
		if (success)
		{
			var r = options.Resolver.GetFormatter<T>();
			var val = r!.Deserialize(ref reader, options);
			return val;
		}
		else
		{
			var r = options.Resolver.GetFormatter<Error>();
			var error = r!.Deserialize(ref reader, options);
			return error;
		}
	}

	public void Serialize(ref MessagePackWriter writer, Result<T> value, MessagePackSerializerOptions options)
	{
		writer.Write(value.Success);
		if (value.Success)
		{
			var r = options.Resolver.GetFormatter<T>();
			r!.Serialize(ref writer, value.Value, options);
		}
		else
		{
			var r = options.Resolver.GetFormatter<Error>();
			r!.Serialize(ref writer, value.Error, options);
		}
	}
}

/// <summary>
/// Represents an operation that succeeded (with a value) or failed with an error.
/// </summary>
[MessagePackFormatter(typeof(ResultFormatter<>))]
[MessagePackObject]
public readonly struct Result<T>
{
	[Key(0)]
	private readonly T? _value;
	[Key(1)]
	private readonly Error? _error;
	private Result(T? value) => _value = value;
	private Result(Error? error) => _error = error;

	/// <summary>
	/// Indicates whether or not the operation succeeded.
	/// </summary>
	[IgnoreMember]
	public bool Success => _error is null;

	/// <summary>
	/// Gets the error if the result represents a failure — throws if the result is successful.
	/// </summary>
	[IgnoreMember]
	public Error Error => _error ?? throw new InvalidOperationException("The result doesn't contain an error.");

	/// <summary>
	/// Gets the wrapped value if the result represents a success — throws if the result is a failure.
	/// </summary>
	[IgnoreMember]
	public T Value => _value ?? throw new InvalidOperationException("The result contains an error.");

	/// <summary>
	/// Gets the wrapped value if the result represents a success — returns `null` if the result is a failure.
	/// </summary>
	[IgnoreMember]
	public T? ValueOrDefault => _value ?? default;

	/// <summary>
	/// Wraps an <see cref="Sarmashq.Error"/> object inside a <see cref="Result"/> that represents a failure.
	/// </summary>
	public static implicit operator Result<T>(Error error) => new(error);

	/// <summary>
	/// Wraps a <typeparamref name="T"/> object inside a <see cref="Result"/> that represents a success.
	/// </summary>
	public static implicit operator Result<T>(T value) => new(value);

	public override string ToString() =>
		$"Result:{(Success ? $"Success({_value})" : $"Error({_error})")}";
}

/// <summary>
/// Represents an error during the execution of a command.
/// </summary>
[MessagePackObject]
public abstract record Error(string Message, int Code, ErrorKind Kind)
{
	/// <summary>
	/// The human-readable message associated with the error.
	/// </summary>
	[Key(0)]
	public string Message { get; } = Message;

	/// <summary>
	/// A numeric error code that uniquely identifies the specific type of the error within the bounded context.
	/// </summary>
	[Key(1)]
	public int Code { get; } = Code;

	/// <summary>
	/// The category of error that an <see cref="Error"/> instance belongs to.
	/// </summary>
	[Key(3)]
	public ErrorKind Kind { get; } = Kind;
}

/// <summary>
/// Represents the category of error that an <see cref="IError"/> instance belongs to.
/// </summary>
public enum ErrorKind
{
	/// <summary>
	/// Classifies errors that are related to invalid input from the user/client.
	/// </summary>
	BadInput,

	/// <summary>
	/// Classifies domain logic and business invariant violations.
	/// </summary>
	Logical,

	/// <summary>
	/// Classifies errors that are the result of unexpected internal errors.
	/// </summary>
	Unexpected,
}
