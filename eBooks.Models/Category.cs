using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eBooks.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range (1,100, ErrorMessage ="Display order range is between 1 and 100!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
