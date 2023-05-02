
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroToLinq.Models
{
    public class Album
    {
        //If property is named Id
        //.Net assumes this is the primary key
        [Key]
        public int Id { get; set; }
        //This means they have to type an album title
        [Required(ErrorMessage = "Album Title cannot be blank")]
        [Display(Name = "Album Title")]
        public string Title { get; set; }
        [StringLength(50, ErrorMessage = "Artist cannot be more than 50 characters")]
        public string Artist { get; set; }
        [Required(ErrorMessage = "Genre cannot be blank")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Price cannot be blank")]
        //This means price can have 5 total digits and two past the decimal point
        [Column(TypeName = "decimal(5, 2)")]
        //Range Attribute takes a starting and an upperbound and it will check
        //that Price is in this range
        [Range(0, 999.99)]
        public decimal Price { get; set; }
        //This represents a foreign key in the Album Table
        //This is one to many relationship
        public int PublisherId { get; set; }
        //I can add an instance of publisher here
        //This property does not exist in the database, it only here to make our lives easier
        //When loading data
        //Navigation Properties
        public Publisher Publisher { get; set; }
    }
}
