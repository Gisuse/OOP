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
        public Materials()
        {
            ClassName = 7;
            NumberOfTheme = 5;
            Title = "Правила безпеки під час nроботи з лабораторним посудом та обладнанням.Маркування небезпечних речовин";
            MaterialContent = "\nРечовини і небезпека. Людина у своєму житті стикається з багатьма речовинами. Серед них трапляються такі, які становлять певну небезпеку. Одні речовини можуть спричинити пожежу, інші — завдати шкоди здоров’ю. Про це треба пам’ятати під час про ведення дослідів у шкільному хімічному кабінеті, а також при використанні різних речовин і розчинів у повсякденному житті — під час ремонту квартири, прання, чищення одягу, боротьби зі шкідниками та хворобами рослин на присадибній ділянці тощо.\nСерйозну небезпеку становлять горючі речовини — природний газ, органічні роз чинники (наприклад, спирт, ацетон), нафтопродукти, більшість полімерів.\n Деякі речовини та їх суміші можуть спри чинити вибух. Кожен, хто користується газовою плитою, повинен знати: не можна допускати надходження газу в приміщення. Суміш навіть невеликої його кількості з повітрям вибухає від іскри або запаленого сірника.";
        }
    }
}
