namespace Books.Services
{
    public interface ITypesSevice
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
