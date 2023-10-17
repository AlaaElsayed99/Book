using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Books.ViewModel
{
    public class CreateBookViewModel:GameFormViewModel
    {
      
        [AllowedExtention(AttribuesImage.AllowedExtention)]
        [MaxSize(AttribuesImage.MaxFileSizeInBytes)]

        public IFormFile Cover { get; set; } = default!;

    }
}
