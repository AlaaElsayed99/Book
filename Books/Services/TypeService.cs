using Microsoft.EntityFrameworkCore;

namespace Books.Services
{
    public class TypeService : ITypesSevice
    {
        private readonly AppDbContext _context;

        public TypeService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.BookTypes
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Type })
                .OrderBy(s => s.Text)
                .ToList();
        }

        
    }
}
