using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagementApis.Models
{
    public class UserDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public AddressInfo address { get; set; } = new AddressInfo();
        public string phone { get; set; }
        public string website { get; set; }
        public CompanyInfo company { get; set; } = new CompanyInfo();
    }
}

