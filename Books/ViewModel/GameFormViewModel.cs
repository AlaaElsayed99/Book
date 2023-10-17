namespace Books.ViewModel
{
    public class GameFormViewModel
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1500)]

        public string Description { get; set; }

        public string Author { get; set; }

        public IEnumerable<SelectListItem> BooksTypes { get; set; } = Enumerable.Empty<SelectListItem>();
        public int BookTypeId { get; set; }
    }
}
