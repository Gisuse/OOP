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

        public Materials()
        {
            Title = "Хімія — природнича наука";
            MaterialContent = "Слово «хімія» має кілька значень. Хімією називають одну з наук, а також навчальний предмет у школі, університеті. Іноді це слово вживають як скорочену назву хіміч\" ної промисловості. Хімія — природнича наука. На уроках природознавства ви дізналися, що існує кіль\" ка наук про природу. Серед них є й хімія.";
        }
    }
}
