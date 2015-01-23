using QuickBootstrap.Cache.Extendsions;
using StackExchange.Redis;

namespace QuickBootstrap.Cache
{
    /// <summary>
    /// 连接池需要重新设计
    /// </summary>
    public class RedisContext : CacheContext
    {
        public static IDatabase RedisDatabase;

        public override void Init() { }

        public override T Get<T>(string key)
        {
            try
            {
                return RedisDatabase.Get<T>(key);
            }
            catch
            {
                return null;
            }
        }

        public override bool Set<T>(string key, T t)
        {
            try
            {
                RedisDatabase.Set(key, t);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool Remove(string key)
        {
            try
            {
                return RedisDatabase.KeyDelete(key);
            }
            catch
            {
                return false;
            }
        }

        public override void Dispose() { }
    } 
}
