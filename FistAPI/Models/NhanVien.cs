
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FistAPI.Models
{
    public class NhanVien
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MA_NV { get; set; }
        public string TEN_NV { get; set; }
        public string MA_CV { get; set; }
        public string EMAIL { get; set; }
    }
}
