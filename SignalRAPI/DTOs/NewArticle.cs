using System.ComponentModel.DataAnnotations;

namespace SignalRAPI.DTOs
{
    public class NewArticle
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(0,int.MaxValue)]
        public int Price { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
