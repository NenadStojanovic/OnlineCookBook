using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Driver;

namespace OnlineCookBook.MongoDB_DataLayer.Entities
{
    public class Bill
    {
        public ObjectId Id { get; set; }

        public DateTime Date { get; set; }

        public float Fprice { get; set; }//full price

        public MongoDBRef User { get; set; }

        public List<MongoDBRef> Ingredients { get; set; }

        public Bill()
        {
            Ingredients = new List<MongoDBRef>();
        }
    }
}