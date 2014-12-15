using System;
using ServiceStack.Redis;

namespace RedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            RedisClientFactory factory = RedisClientFactory.Instance;
            using (RedisClient client = factory.CreateRedisClient("127.0.0.1", 6379))
            {
                client.Set("vstest", "firsValue");
                str = client.Get<string>("vstest");
            }
            Console.WriteLine(str);
            //RedisHelper redisHelper = new RedisHelper("192.168.97.201", "fanhuan");
            //using (IRedisClient client1 = redisHelper.GetRedisClient())
            //{
            //   str= redisHelper.GetHash(client1, "PHONE_SHARE_COUNT_KEY", "18707158184");
            //}
            //Console.WriteLine(str);

            RedisHelper redisHelper = new RedisHelper("127.0.0.1");
            using (IRedisClient client2 = redisHelper.GetRedisClient())
            {
                redisHelper.SetHash(client2, "HASH_TEST", "1", "1");
                str = redisHelper.GetHash(client2, "HASH_TEST", "1");
            }

            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
