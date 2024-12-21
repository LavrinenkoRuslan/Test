using MessagePack;
using MessagePack.Resolvers;
using Test;

MessagePackSerializerOptions GetResolver()
{
    var resolver = CompositeResolver.Create(
        NativeDecimalResolver.Instance,
        NativeGuidResolver.Instance,
        NativeDateTimeResolver.Instance,
        TypelessObjectResolver.Instance,
        StandardResolver.Instance
    );
    return MessagePackSerializerOptions.Standard.WithResolver(resolver).WithOmitAssemblyVersion(true);
}


Dictionary<string, IPrimaryKeyItem> itemList = new Dictionary<string, IPrimaryKeyItem>();

itemList.Add("1", new PrimaryKeyItem<int>(1));
itemList.Add("2", new PrimaryKeyItem<string>("2"));

var json = MessagePackSerializer.SerializeToJson(itemList, GetResolver());

Console.Read();
