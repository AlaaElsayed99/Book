namespace Books.ViewModel
{
    public class EditViewModel:GameFormViewModel
    {

        public int Id { get; set; }
        public string? CurrentCover { get; set; }    

        [AllowedExtention(AttribuesImage.AllowedExtention)]
        [MaxSize(AttribuesImage.MaxFileSizeInBytes)]

        public IFormFile? Cover { get; set; } = default!;
    }
}
