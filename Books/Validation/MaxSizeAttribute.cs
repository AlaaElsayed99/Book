namespace Books.Validation
{
    public class MaxSizeAttribute :ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
               
                if (file.Length>_maxFileSize)
                {
                    return new ValidationResult($"Maximum allowed size is  {_maxFileSize}");
                }

            }
            return ValidationResult.Success;

        }
    }
}
