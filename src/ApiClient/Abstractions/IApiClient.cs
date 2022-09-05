namespace ApliClientLib.Abstractions
{
    public interface IApiClient
    {
        IClientOperations ClientOperations { get; }
        IOrderOperations OrderOperations { get; }
    }
}
