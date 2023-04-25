using System.ComponentModel.DataAnnotations;

namespace IntroToLinq.Models
{
    public class Album
    {
        //This sets ID as the primary key
        [Key]
        public int Id { get; set; }
        //This means the Title property has to have a value
        [Required(ErrorMessage = "Album Title cannot be blank")]
        //Display attribute
        //This is when you want a property to show up as a different name to the user
        [Display(Name = "Album Title")]
        public string Title { get; set; }
        [MinLength(3, ErrorMessage = "Artist must be atleast 3 characters")]
        public string Artist { get; set; }
        [Required(ErrorMessage = "Genre cannot be blank")]
        [StringLength(20, ErrorMessage = "Genre cannot be more than 20 characters")]
        public string Genre { get; set; }
        [Display(Name = "Album Price")]
        [Required(ErrorMessage = "Price cannot be blank")]
        [Range(0, 999.99, ErrorMessage = "Price must be between 0 and 999.99")]
        public decimal Price { get; set; }
    }
}
