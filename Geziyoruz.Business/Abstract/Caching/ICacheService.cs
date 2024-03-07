

namespace Geziyoruz.Business.Abstract.Caching
{
    public interface ICacheService
    {
        void SetCache(string key, object item, TimeSpan timeSpan);
        T GetCache<T>(string key);
        void Remove(string key);
    }
}
