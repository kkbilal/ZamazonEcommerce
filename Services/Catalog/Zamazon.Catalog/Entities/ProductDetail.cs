using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Zamazon.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ProductDetailId { get; set; }
        public int ProductDescription { get; set; }
        public int ProductInfo { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
        
    }
}
