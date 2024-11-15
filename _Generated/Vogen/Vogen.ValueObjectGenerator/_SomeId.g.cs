﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a source generator named Vogen (https://github.com/SteveDunn/Vogen)
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0618
// Suppress warnings for 'Override methods on comparable types'.
#pragma warning disable CA1036
// Suppress Error MA0097 : A class that implements IComparable<T> or IComparable should override comparison operators
#pragma warning disable MA0097
// Suppress warning for 'The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.'
// The generator copies signatures from the BCL, e.g. for `TryParse`, and some of those have nullable annotations.
#pragma warning disable CS8669, CS8632
// Suppress warnings about CS1591: Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable CS1591
#nullable enable
[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Vogen", "5.0.0.0")]
[global::System.Diagnostics.DebuggerTypeProxyAttribute(typeof(SomeIdDebugView))]
[global::System.Diagnostics.DebuggerDisplayAttribute("Underlying type: System.Guid, Value = { _value }")]
// ReSharper disable once UnusedType.Global
public readonly partial struct SomeId : global::System.IEquatable<SomeId>, global::System.IEquatable<System.Guid>, global::System.IComparable<SomeId>, global::System.IComparable, global::System.IParsable<SomeId>, global::System.ISpanParsable<SomeId>, global::System.IFormattable, global::System.ISpanFormattable, global::System.IUtf8SpanFormattable
{
#if DEBUG
private readonly global::System.Diagnostics.StackTrace? _stackTrace = null!;
#endif
#if !VOGEN_NO_VALIDATION
    private readonly global::System.Boolean _isInitialized;
#endif
    private readonly System.Guid _value;
    /// <summary>
    /// Gets the underlying <see cref = "System.Guid"/> value if set, otherwise a <see cref = "Vogen.ValueObjectValidationException"/> is thrown.
    /// </summary>
    public readonly System.Guid Value
    {
        [global::System.Diagnostics.DebuggerStepThroughAttribute]
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        get
        {
            EnsureInitialized();
            return _value;
        }
    }

    [global::System.Diagnostics.DebuggerStepThroughAttribute]
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public SomeId()
    {
#if DEBUG
            _stackTrace = new global::System.Diagnostics.StackTrace();
#endif
#if !VOGEN_NO_VALIDATION
        _isInitialized = false;
#endif
        _value = default;
    }

    [global::System.Diagnostics.DebuggerStepThroughAttribute]
    private SomeId(System.Guid value)
    {
        _value = value;
#if !VOGEN_NO_VALIDATION
        _isInitialized = true;
#endif
    }

    /// <summary>
    /// Builds an instance from the provided underlying type.
    /// </summary>
    /// <param name = "value">The underlying type.</param>
    /// <returns>An instance of this type.</returns>
    [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static SomeId From(System.Guid value)
    {
        return new SomeId(value);
    }

    /// <summary>
    /// Tries to build an instance from the provided underlying type.
    /// If a normalization method is provided, it will be called.
    /// If validation is provided, and it fails, false will be returned.
    /// </summary>
    /// <param name = "value">The underlying type.</param>
    /// <param name = "vo">An instance of the value object.</param>
    /// <returns>True if the value object can be built, otherwise false.</returns>
    
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member because of nullability attributes.

    public static bool TryFrom(
#if NETCOREAPP3_0_OR_GREATER
[global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
    System.Guid value,
#if NETCOREAPP3_0_OR_GREATER
[global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)]
#endif
 out SomeId vo)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member because of nullability attributes.

    {
        vo = new SomeId(value);
        return true;
    }

    /// <summary>
    /// Tries to build an instance from the provided underlying value.
    /// If a normalization method is provided, it will be called.
    /// If validation is provided, and it fails, an error will be returned.
    /// </summary>
    /// <param name = "value">The primitive value.</param>
    /// <returns>A <see cref = "Vogen.ValueObjectOrError{T}"/> containing either the value object, or an error.</returns>
    public static Vogen.ValueObjectOrError<SomeId> TryFrom(System.Guid value)
    {
        return new Vogen.ValueObjectOrError<SomeId>(new SomeId(value));
    }

    [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#if VOGEN_NO_VALIDATION
#pragma warning disable CS8775
  public readonly bool IsInitialized() => true;
#pragma warning restore CS8775
#else
    public readonly bool IsInitialized() => _isInitialized;
#endif
    public static explicit operator SomeId(System.Guid value) => From(value);
    public static explicit operator System.Guid(SomeId value) => value.Value;
    // only called internally when something has been deserialized into
    // its primitive type.
    private static SomeId __Deserialize(System.Guid value)
    {
        return new SomeId(value);
    }

    public readonly global::System.Boolean Equals(SomeId other)
    {
        // It's possible to create uninitialized instances via converters such as EfCore (HasDefaultValue), which call Equals.
        // We treat anything uninitialized as not equal to anything, even other uninitialized instances of this type.
        if (!IsInitialized() || !other.IsInitialized())
            return false;
        return global::System.Collections.Generic.EqualityComparer<System.Guid>.Default.Equals(Value, other.Value);
    }

    public global::System.Boolean Equals(SomeId other, global::System.Collections.Generic.IEqualityComparer<SomeId> comparer)
    {
        return comparer.Equals(this, other);
    }

    public readonly global::System.Boolean Equals(System.Guid primitive)
    {
        return Value.Equals(primitive);
    }

    public readonly override global::System.Boolean Equals(global::System.Object? obj)
    {
        return obj is SomeId && Equals((SomeId)obj);
    }

    public static global::System.Boolean operator ==(SomeId left, SomeId right) => left.Equals(right);
    public static global::System.Boolean operator !=(SomeId left, SomeId right) => !(left == right);
    public static global::System.Boolean operator ==(SomeId left, System.Guid right) => left.Value.Equals(right);
    public static global::System.Boolean operator ==(System.Guid left, SomeId right) => right.Value.Equals(left);
    public static global::System.Boolean operator !=(System.Guid left, SomeId right) => !(left == right);
    public static global::System.Boolean operator !=(SomeId left, System.Guid right) => !(left == right);
    public int CompareTo(SomeId other) => Value.CompareTo(other.Value);
    public int CompareTo(object? other)
    {
        if (other is null)
            return 1;
        if (other is SomeId x)
            return CompareTo(x);
        ThrowHelper.ThrowArgumentException("Cannot compare to object as it is not of type SomeId", nameof(other));
        return 0;
    }

    /// <inheritdoc cref = "System.Guid.TryParse(System.ReadOnlySpan{char}, out System.Guid)"/>
    /// <summary>
    /// </summary>
    /// <returns>
    /// True if the value could a) be parsed by the underlying type, and b) passes any validation (after running any optional normalization).
    /// </returns>
    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<char> input,
#if NETCOREAPP3_0_OR_GREATER
[global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
 out SomeId result)
    {
        if (System.Guid.TryParse(input, out var __v))
        {
            result = new SomeId(__v);
            return true;
        }

        result = default;
        return false;
    }

    /// <inheritdoc cref = "System.Guid.TryParse(System.ReadOnlySpan{char}, System.IFormatProvider? , out System.Guid)"/>
    /// <summary>
    /// </summary>
    /// <returns>
    /// True if the value could a) be parsed by the underlying type, and b) passes any validation (after running any optional normalization).
    /// </returns>
    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<char> s, global::System.IFormatProvider? provider,
#if NETCOREAPP3_0_OR_GREATER
[global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
 out SomeId result)
    {
        if (System.Guid.TryParse(s, provider, out var __v))
        {
            result = new SomeId(__v);
            return true;
        }

        result = default;
        return false;
    }

    /// <inheritdoc cref = "System.Guid.TryParse(string? , out System.Guid)"/>
    /// <summary>
    /// </summary>
    /// <returns>
    /// True if the value could a) be parsed by the underlying type, and b) passes any validation (after running any optional normalization).
    /// </returns>
    public static global::System.Boolean TryParse(string? input,
#if NETCOREAPP3_0_OR_GREATER
[global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
 out SomeId result)
    {
        if (System.Guid.TryParse(input, out var __v))
        {
            result = new SomeId(__v);
            return true;
        }

        result = default;
        return false;
    }

    /// <inheritdoc cref = "System.Guid.TryParse(string? , System.IFormatProvider? , out System.Guid)"/>
    /// <summary>
    /// </summary>
    /// <returns>
    /// True if the value could a) be parsed by the underlying type, and b) passes any validation (after running any optional normalization).
    /// </returns>
    public static global::System.Boolean TryParse(string? s, global::System.IFormatProvider? provider,
#if NETCOREAPP3_0_OR_GREATER
[global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)]
#endif
 out SomeId result)
    {
        if (System.Guid.TryParse(s, provider, out var __v))
        {
            result = new SomeId(__v);
            return true;
        }

        result = default;
        return false;
    }

    /// <inheritdoc cref = "System.Guid.Parse(System.ReadOnlySpan{char})"/>
    /// <summary>
    /// </summary>
    /// <returns>
    /// The value created by calling the Parse method on the primitive.
    /// </returns>
    /// <exception cref = "global::Vogen.ValueObjectValidationException">Thrown when the value can be parsed, but is not valid.</exception>
    public static SomeId Parse(global::System.ReadOnlySpan<char> input)
    {
        var r = System.Guid.Parse(input);
        return From(r);
    }

    /// <inheritdoc cref = "System.Guid.Parse(System.ReadOnlySpan{char}, System.IFormatProvider? )"/>
    /// <summary>
    /// </summary>
    /// <returns>
    /// The value created by calling the Parse method on the primitive.
    /// </returns>
    /// <exception cref = "global::Vogen.ValueObjectValidationException">Thrown when the value can be parsed, but is not valid.</exception>
    public static SomeId Parse(global::System.ReadOnlySpan<char> s, global::System.IFormatProvider? provider)
    {
        var r = System.Guid.Parse(s, provider);
        return From(r);
    }

    /// <inheritdoc cref = "System.Guid.Parse(string)"/>
    /// <summary>
    /// </summary>
    /// <returns>
    /// The value created by calling the Parse method on the primitive.
    /// </returns>
    /// <exception cref = "global::Vogen.ValueObjectValidationException">Thrown when the value can be parsed, but is not valid.</exception>
    public static SomeId Parse(string input)
    {
        var r = System.Guid.Parse(input);
        return From(r);
    }

    /// <inheritdoc cref = "System.Guid.Parse(string, System.IFormatProvider? )"/>
    /// <summary>
    /// </summary>
    /// <returns>
    /// The value created by calling the Parse method on the primitive.
    /// </returns>
    /// <exception cref = "global::Vogen.ValueObjectValidationException">Thrown when the value can be parsed, but is not valid.</exception>
    public static SomeId Parse(string s, global::System.IFormatProvider? provider)
    {
        var r = System.Guid.Parse(s, provider);
        return From(r);
    }

#nullable disable
    /// <inheritdoc cref = "System.Guid.ToString(string? , System.IFormatProvider? )"/>
    public string ToString([System.Diagnostics.CodeAnalysis.StringSyntaxAttribute("GuidFormat")] string format, global::System.IFormatProvider provider)
    {
        return IsInitialized() ? Value.ToString(format, provider) : "[UNINITIALIZED]";
    }

    /// <inheritdoc cref = "System.ISpanFormattable"/>
    bool System.ISpanFormattable.TryFormat(global::System.Span<char> destination, out int charsWritten, [System.Diagnostics.CodeAnalysis.StringSyntaxAttribute("GuidFormat")] global::System.ReadOnlySpan<char> format, global::System.IFormatProvider provider)
    {
        charsWritten = default;
        return IsInitialized() ? (Value as System.ISpanFormattable).TryFormat(destination, out charsWritten, format, provider) : false;
    }

    /// <inheritdoc cref = "System.IUtf8SpanFormattable"/>
    bool System.IUtf8SpanFormattable.TryFormat(global::System.Span<byte> utf8Destination, out int bytesWritten, [System.Diagnostics.CodeAnalysis.StringSyntaxAttribute("GuidFormat")] global::System.ReadOnlySpan<char> format, global::System.IFormatProvider provider)
    {
        bytesWritten = default;
        return IsInitialized() ? (Value as System.IUtf8SpanFormattable).TryFormat(utf8Destination, out bytesWritten, format, provider) : false;
    }

#nullable restore
    public readonly override global::System.Int32 GetHashCode()
    {
        return global::System.Collections.Generic.EqualityComparer<System.Guid>.Default.GetHashCode(Value);
    }

    /// <inheritdoc cref = "System.Guid.ToString()"/>
    public override global::System.String ToString() => IsInitialized() ? Value.ToString() ?? "" : "[UNINITIALIZED]";
    /// <inheritdoc cref = "System.Guid.ToString(string? )"/>
    public global::System.String ToString([System.Diagnostics.CodeAnalysis.StringSyntaxAttribute("GuidFormat")] string? format) => IsInitialized() ? Value.ToString(format) ?? "" : "[UNINITIALIZED]";
    [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    private readonly void EnsureInitialized()
    {
        if (!IsInitialized())
        {
#if DEBUG
               ThrowHelper.ThrowWhenNotInitialized(_stackTrace);
#else
            ThrowHelper.ThrowWhenNotInitialized();
#endif
        }
    }

#nullable disable
    internal sealed class SomeIdDebugView
    {
        private readonly SomeId _t;
        SomeIdDebugView(SomeId t)
        {
            _t = t;
        }

        public global::System.Boolean IsInitialized => _t.IsInitialized();
        public global::System.String UnderlyingType => "System.Guid";
        public global::System.String Value => _t.IsInitialized() ? _t._value.ToString() : "[not initialized]";
#if DEBUG
        public global::System.String CreatedWith => _t._stackTrace?.ToString() ?? "the From method";
#endif
        public global::System.String Conversions => @"MessagePack";
    }

#nullable restore
    static class ThrowHelper
    {
#if NETCOREAPP3_0_OR_GREATER
    [global::System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute]
#endif
        internal static void ThrowInvalidOperationException(string message) => throw new global::System.InvalidOperationException(message);
#if NETCOREAPP3_0_OR_GREATER
    [global::System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute]
#endif
        internal static void ThrowArgumentException(string message, string arg) => throw new global::System.ArgumentException(message, arg);
#if NETCOREAPP3_0_OR_GREATER
    [global::System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute]
#endif
        internal static void ThrowWhenCreatedWithNull() => throw new global::Vogen.ValueObjectValidationException("Cannot create a value object with null.");
#if NETCOREAPP3_0_OR_GREATER
    [global::System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute]
#endif
        internal static void ThrowWhenNotInitialized() => throw new global::Vogen.ValueObjectValidationException("Use of uninitialized Value Object.");
#if NETCOREAPP3_0_OR_GREATER
    [global::System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute]
#endif
        internal static void ThrowWhenNotInitialized(global::System.Diagnostics.StackTrace? stackTrace) => throw new global::Vogen.ValueObjectValidationException("Use of uninitialized Value Object at: " + stackTrace ?? "");
#if NETCOREAPP3_0_OR_GREATER
    [global::System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute]
#endif
        internal static void ThrowWhenValidationFails(Vogen.Validation validation)
        {
            var ex = new global::Vogen.ValueObjectValidationException(validation.ErrorMessage);
            if (validation.Data is not null)
            {
                foreach (var kvp in validation.Data)
                {
                    ex.Data[kvp.Key] = kvp.Value;
                }
            }

            throw ex;
        }
    }
}
#nullable restore
