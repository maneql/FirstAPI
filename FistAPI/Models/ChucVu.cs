
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FistAPI.Models
{
    public class ChucVu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MA_CV { get; set; }
        public string TEN_CV { get; set; }
        public int LUONG_CV { get; set; }
    }
}
