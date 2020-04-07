using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataMongo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("local");
            var command = new BsonDocument { { "dbstats", 1 } };
            var result = database.RunCommand<BsonDocument>(command);
            var cars = database.GetCollection<BsonDocument>("cars");
            Hashtable hashtable = new Hashtable();
            hashtable["key1"] = "value1";
            hashtable["key2"] = "value2";
            var doc = new BsonDocument(hashtable);
            HashSet<int> hashSet = new HashSet<int>();
            hashSet.Add(1);
            hashSet.Add(2);
            doc = hashSet.ToBsonDocument();
            cars.InsertOne(doc);
            Console.WriteLine(result.ToJson());
            Console.ReadKey();
        }
    }

}
