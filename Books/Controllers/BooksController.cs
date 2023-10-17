

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly ITypesSevice _typesSevice;
        private readonly IBookService _bookService;

        public BooksController(ITypesSevice TypesSevice, IBookService bookService)
        {
           
            _typesSevice = TypesSevice;
            _bookService = bookService;
            
        }
        public IActionResult Index()
        {
            var games = _bookService.GetAllBook();
            return View(games);
        }
        public IActionResult Details(int id)
        {
            var game = _bookService.GetBookById(id);
            return View(game);
        }
        [HttpGet]
        public IActionResult CreateNew()
        {

            CreateBookViewModel createBookViewModel = new() {
                BooksTypes = _typesSevice.GetSelectList(),
            };

            return View(createBookViewModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task< IActionResult> CreateNew(CreateBookViewModel createBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                createBookViewModel.BooksTypes = _typesSevice.GetSelectList();
                return View(createBookViewModel);
            }

             await _bookService.Create(createBookViewModel);
             _bookService.Save();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();
            EditViewModel Edit = new EditViewModel()
            {
                Id=book.Id,
                Title=book.Title,
                Author=book.Author,
                BooksTypes= _typesSevice.GetSelectList(),  
                Description= book.Description,
                CurrentCover= book.Cover

            };
            return View(Edit);
            
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditViewModel EditBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                EditBookViewModel.BooksTypes = _typesSevice.GetSelectList();
                return View(EditBookViewModel);
            }

            var book = await _bookService.Update(EditBookViewModel);
            if (book == null) return BadRequest();


            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _bookService.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}
