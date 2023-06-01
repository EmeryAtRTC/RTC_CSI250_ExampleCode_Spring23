using System.ComponentModel.DataAnnotations;

namespace AutoShop23.Validation
{
    public class VehicleImageValidation : ValidationAttribute
    {
        //override IsValid method
        public override bool IsValid(object value)
        {
            //The value is whatever got sent to the property you are validating
            //cast to IformFile
            IFormFile file = (IFormFile)value;
            //set a maxSize for the file 3mb
            int maxLength = 1024 * 1024 * 3;
            //set some valid file extensions
            string[] validExtensions = { ".jpg", ".gif", ".png", "jpeg" };
            //validating the file
            if(file is null)
            {
                ErrorMessage = "Please upload a file";
                return false;
            }
            //check to see it has valid exention
            if (!validExtensions.Contains(Path.GetExtension(file.FileName)))
            {
                ErrorMessage = $"Not an Image File. Please Upload {string.Join(",", validExtensions)}";
                return false;
            }
            if(file.Length > maxLength)
            {
                ErrorMessage = $"File is too large";
                return false;
            }
            return true;
        }
    }
}
