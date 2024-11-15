using MessagePack;
using MessagePack.Resolvers;
using Vogen;
var customResolver = CompositeResolver.Create(
	new SomeIdMessagePackFormatter()
);
var finalResolver = CompositeResolver.Create(
	// customResolver,
	AttributeFormatterResolver.Instance,
	StandardResolver.Instance
);
MessagePackSerializer.DefaultOptions = MessagePackSerializer.DefaultOptions.WithResolver(finalResolver);

// Result<Foo> foo = new Foo(SomeId.From(Guid.NewGuid()), 123);
var foo = new Foo<int>(SomeId.From(Guid.NewGuid()), 123);
Console.WriteLine($"Original: {foo}");

var bytes = MessagePackSerializer.Serialize(foo);
Console.WriteLine($"Serialized: {bytes.Length}");
var fooDe = MessagePackSerializer.Deserialize<Foo<int>>(bytes);
Console.WriteLine($"Deserialized: {fooDe}");

[MessagePackObject]
public record Foo<T>(
	[property: Key(0)]
	SomeId Id,
	[property: Key(1)]
	T X
);

[MessagePackFormatter(typeof(SomeIdMessagePackFormatter))]
[ValueObject<Guid>(Conversions.MessagePack)]
public readonly partial struct SomeId;

/// <summary>
/// Represents an operation that succeeded (without a value) or failed with an error.
/// </summary>
public readonly struct Result
{
	private readonly Error? _error;
	private Result(Error? error) => _error = error;

	/// <summary>
	/// Indicates whether or not the operation succeeded.
	/// </summary>
	public bool Success => _error is null;

	/// <summary>
	/// Gets the error if the result represents a failure — throws if the result is successful.
	/// </summary>
	public Error Error => _error ?? throw new InvalidOperationException("The result doesn't contain an error.");

	/// <summary>
	/// Wraps an <see cref="Sarmashq.Error"/> object inside a <see cref="Result"/> that represents a failure.
	/// </summary>
	public static implicit operator Result(Error error) => new(error);

	/// <summary>
	/// A singleton instance of a successful <see cref="Result"/> with no underlying value.
	/// </summary>
	public static Result Ok { get; } = _ok;
	private static readonly Result _ok = new(null);
}

/// <summary>
/// Represents an operation that succeeded (with a value) or failed with an error.
/// </summary>
[MessagePackObject]
public readonly struct Result<T>
{
	[Key(0)]
	private readonly T? _value;
	[Key(0)]
	private readonly Error? _error;
	private Result(T? value) => _value = value;
	private Result(Error? error) => _error = error;

	/// <summary>
	/// Indicates whether or not the operation succeeded.
	/// </summary>
	public bool Success => _error is null;

	/// <summary>
	/// Gets the error if the result represents a failure — throws if the result is successful.
	/// </summary>
	public Error Error => _error ?? throw new InvalidOperationException("The result doesn't contain an error.");

	/// <summary>
	/// Gets the wrapped value if the result represents a success — throws if the result is a failure.
	/// </summary>
	public T Value => _value ?? throw new InvalidOperationException("The result contains an error.");

	/// <summary>
	/// Gets the wrapped value if the result represents a success — returns `null` if the result is a failure.
	/// </summary>
	public T? ValueOrDefault => _value ?? default;

	/// <summary>
	/// Wraps an <see cref="Sarmashq.Error"/> object inside a <see cref="Result"/> that represents a failure.
	/// </summary>
	public static implicit operator Result<T>(Error error) => new(error);

	/// <summary>
	/// Wraps a <typeparamref name="T"/> object inside a <see cref="Result"/> that represents a success.
	/// </summary>
	public static implicit operator Result<T>(T value) => new(value);
}

/// <summary>
/// Represents an error during the execution of a command.
/// </summary>
public abstract record Error(string Message, int Code, ErrorKind Kind)
{
	/// <summary>
	/// The human-readable message associated with the error.
	/// </summary>
	public string Message { get; } = Message;

	/// <summary>
	/// A numeric error code that uniquely identifies the specific type of the error within the bounded context.
	/// </summary>
	public int Code { get; } = Code;

	/// <summary>
	/// The category of error that an <see cref="Error"/> instance belongs to.
	/// </summary>
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
