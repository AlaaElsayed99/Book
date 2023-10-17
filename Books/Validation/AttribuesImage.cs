
namespace Books.Validation
{
    public class AttribuesImage
    {
        public const string IamgePath = "/assets/Images/Books";
        public const string AllowedExtention = ".jpg,.png,.jpeg";
        public const int MaxFileSizeinMg = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeinMg*1024*1024;

    }
}
