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
public partial class SomeIdMessagePackFormatter : global::MessagePack.Formatters.IMessagePackFormatter<SomeId>
{
    public void Serialize(ref global::MessagePack.MessagePackWriter writer, SomeId value, global::MessagePack.MessagePackSerializerOptions options)
    {
        global::MessagePack.Formatters.IMessagePackFormatter<System.Guid>? r = options.Resolver.GetFormatter<System.Guid>();
        if (r is null)
            Throw("No formatter for underlying type of 'System.Guid' registered for value object 'SomeId'.");
        r.Serialize(ref writer, value.Value, options);
    }

    public SomeId Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
    {
        global::MessagePack.Formatters.IMessagePackFormatter<System.Guid>? r = options.Resolver.GetFormatter<System.Guid>();
        if (r is null)
            Throw("No formatter for underlying type of 'System.Guid' registered for value object 'SomeId'.");
        System.Guid g = r.Deserialize(ref reader, options);
        return Deserialize(g);
    }

    private static void Throw(string message) => throw new global::MessagePack.MessagePackSerializationException(message);
    static SomeId Deserialize(System.Guid value) => UnsafeDeserialize(default, value);
    [global::System.Runtime.CompilerServices.UnsafeAccessor(global::System.Runtime.CompilerServices.UnsafeAccessorKind.StaticMethod, Name = "__Deserialize")]
    static extern SomeId UnsafeDeserialize(SomeId @this, System.Guid value);
}