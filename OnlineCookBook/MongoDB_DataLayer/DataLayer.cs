using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;


namespace OnlineCookBook.MongoDB_DataLayer
{
    public class DataLayer
    {
        public List<string> dajMiSveAaaaaa(string cat)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = new MongoClient(connectionString);
            var db = server.GetDatabase("preduzece");

            var collection = db.GetCollection<string>("radnici");
            List<string> rdnici = collection.Find(new BsonDocument()).ToList();
            var update = MongoDB.Driver.Builders.Update.Set("oznake", BsonValue.Create(new List<string> { "test" }));
            return rdnici;

            
            
            
            
        }
    }
}