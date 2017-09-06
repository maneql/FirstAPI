using MongoDB.Bson;
using MongoDB.Driver;

namespace FistAPI.Models
{
    public class NhanVien
    {
        public ObjectId id { get; set; }
        public string MA_NV { get; set; }
        public string TEN_NV { get; set; }
        public string MA_CV { get; set; }
        public string EMAIL { get; set; }
    }
}
