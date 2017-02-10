using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Driver;

namespace OnlineCookBook.MongoDB_DataLayer.Entities
{
    public class Comment
    {
        public ObjectId Id { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public User User { get; set; }

        public ObjectId RecipeId { get; set; }
    }
}