using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;

namespace Application
{
    public class Materials
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string MaterialContent { get; set; }
        public int ClassName { get; set; }
        public int NumberOfTheme { get; set; }
        public Materials(string title, string materialContent, int className, int numberOfTheme)
        {
            ClassName = className;
            NumberOfTheme = numberOfTheme;
            Title = title;
            MaterialContent = materialContent;
        }

        public Materials(string id, string title, string materialContent, int className, int numberOfTheme)
        {
            Id = id;
            Title = title;
            MaterialContent = materialContent;
            ClassName = className;
            NumberOfTheme = numberOfTheme;
        }
    }
}
