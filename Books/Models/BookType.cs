
namespace Books.Models
{
    public class BookType: BaseModel
    {

        public string Type { get; set; }
        public ICollection<Book>? Books { get; set; }

    }
}
