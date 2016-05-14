namespace Microsoft.VenuGopal.CSharp.Random
{
    using Microsoft.VenuGopal.CSharp.Random.Delegates;

    public interface IModuleHost
    {
        void PostOutputDataItems(DataItem item, ModuleHostCallback.DataItemAcknowledgementCallback acknowledgeCallback, object acknowledgementState);
    }
}
