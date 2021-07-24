using SolvexWorkShop.Core.BaseModel;

namespace SolvexWorkshop.Model.Entities
{
    public class Document : BaseEntity
    {
        public string FileName { get; set; } //file-store name
        public string OriginalName { get; set; } //selected file
        public string ContentType { get; set; }
    }
}
