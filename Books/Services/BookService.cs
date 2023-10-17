
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Books.Services
{
    public class BookService : IBookService
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagePath;

        public BookService(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagePath = $"{webHostEnvironment.WebRootPath}{AttribuesImage.IamgePath}";
        }
        public async Task Create(CreateBookViewModel ViewBook)
        {
            var coverName = await CoverChange(ViewBook.Cover);
            Models.Book Book = new()
            {
                Title=ViewBook.Title,
                Description=ViewBook.Description,
                Author=ViewBook.Author,
                BookTypeId=ViewBook.BookTypeId,
                Cover=coverName,
            };
            _context.Add(Book);
        }

        public bool Delete(int id)
        {
            var isDeleted = false;
            var book = _context.Books.Find(id);
            if (book == null) return isDeleted;
            _context.Books.Remove(book);
            var effectedRow = _context.SaveChanges();
            if (effectedRow > 0)
            {
                isDeleted = true;
                var cover = Path.Combine(_imagePath, book.Cover);
                File.Delete(cover);
            }

            return isDeleted;
        }

        public IEnumerable<Book> GetAllBook()
        {
            var Books= _context.Books.AsNoTracking().Include(s=>s.Type).ToList();
            return  Books;
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Include(s=>s.Type).FirstOrDefault(s=>s.Id==id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<Book>? Update(EditViewModel model)
        {
            var book = _context.Books.Include(s=>s.Type).FirstOrDefault(s=>s.Id==model.Id);
            if (book == null) return null;
            var hasnewcover = model.Cover is not null;
            var oldCover = book.Cover;
            book.Title = model.Title;
            book.Description = model.Description;
            book.Author = model.Author;
            book.BookTypeId = model.BookTypeId;
            if (hasnewcover)
            {
                book.Cover =await CoverChange(model.Cover);
            }
            var effictedRow= _context.SaveChanges();
            if (effictedRow > 0)
            {
                if (hasnewcover)
                {
                    var cover=Path.Combine(_imagePath,oldCover);
                    File.Delete(cover);
                }
                return book;
            }
            else
            {
                var cover = Path.Combine(_imagePath, book.Cover);
                File.Delete(cover);
                return null;
            }

        }

        private async Task<string> CoverChange(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagePath, coverName);
            using var fileStream = File.Create(path);
            await cover.CopyToAsync(fileStream);
            return coverName;
        }
    }
}
