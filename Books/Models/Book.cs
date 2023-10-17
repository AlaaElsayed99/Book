using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Book:BaseModel
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1500)]

        public string Description { get; set; }

        public string Author { get; set; }
        
        public string Cover { get; set; }
        public int BookTypeId { get; set; }
        public BookType? Type { get; set; }

    }
}
