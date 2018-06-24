namespace Yers.IService
{
    public interface ISettingService : IServiceSupport
    {
        void Add(string key, string value);
    }
}