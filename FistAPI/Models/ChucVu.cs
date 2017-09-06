using MongoDB.Bson;

namespace FistAPI.Models
{
    public class ChucVu
    {
        public ObjectId id { get; set; }
        public string MA_CV { get; set; }
        public string TEN_CV { get; set; }
        public int LUONG_CV { get; set; }
    }
}
