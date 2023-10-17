namespace Books.Services
{
    public interface IBookService
    {
        Task Create(CreateBookViewModel ViewBook);
        IEnumerable<Book> GetAllBook();
        Book GetBookById(int id);
        void Save();
        Task<Book>? Update(EditViewModel model);
        bool Delete(int id);
    }
}
