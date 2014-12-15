using System;
using ServiceStack.Redis;

namespace RedisTest
{
    public class RedisHelper
    {
        private static PooledRedisClientManager _prcm;

        private string RedisConnection { get; set; }

        private string RedisConnectionAuth { get; set; }

        public RedisHelper(string redisConnection, string redisConnectionAuth = "")
        {
            this.RedisConnection = redisConnection;
            this.RedisConnectionAuth = redisConnectionAuth;
        }

        private PooledRedisClientManager GetDefaultManager()
        {
            if (_prcm == null)
            {
                _prcm = new PooledRedisClientManager(new[] { this.RedisConnection })
                {
                    ConnectTimeout = 0xbb8,
                    IdleTimeOutSecs = 30
                };
            }
            return _prcm;
        }

        /// <summary>
        /// 获取redis客户端
        /// </summary>
        /// <returns></returns>
        public IRedisClient GetRedisClient()
        {
            IRedisClient client = this.GetDefaultManager().GetClient();
            if (!string.IsNullOrWhiteSpace(this.RedisConnectionAuth))
            {
                client.Password = this.RedisConnectionAuth;
            }
            return client;
        }

        /// <summary>
        /// 根据key获取value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(IRedisClient client, string key) where T : class
        {
            if (client.ContainsKey(key))
            {
                return client.Get<T>(key);
            }
            return default(T);
        }

        /// <summary>
        /// 根据key获取value,不存在就进行写操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="key"></param>
        /// <param name="fun"></param>
        /// <param name="expiresAt"></param>
        /// <returns></returns>
        public T Get<T>(IRedisClient client, string key, Func<T> fun, DateTime expiresAt) where T : class
        {
            T local = this.Get<T>(client, key);
            if (local != null)
            {
                return local;
            }
            T local2 = fun();
            client.Set(key, local2, expiresAt);
            return local2;
        }

        /// <summary>
        /// 根据key和field从hash表中获取元素
        /// </summary>
        /// <param name="client"></param>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string GetHash(IRedisClient client, string key, string field)
        {
            if (!client.ContainsKey(key))
            {
                return string.Empty;
            }
            return client.GetValueFromHash(key, field);
        }

        /// <summary>
        /// 根据key删除元素
        /// </summary>
        /// <param name="client"></param>
        /// <param name="key"></param>
        public void Remove(IRedisClient client, string key)
        {
            client.Remove(key);
        }

        /// <summary>
        /// 写入hash表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetHash(IRedisClient client, string key, string field, string value)
        {
            return client.SetEntryInHash(key, field, value);
        }
    }
}
