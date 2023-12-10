using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreYourVideo.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        [Key]
        public int ID { get; set; }
        
        public String? Name { get; set; }
        [Required(ErrorMessage = "Please enter your email!!")]
        [DataType(DataType.EmailAddress)]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password!!")]
        [MinLength(9, ErrorMessage = "Password's length must be longer 9") ]
        public String Password {  get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Please enter again your password!!")]
        [Compare("Password", ErrorMessage = "Your confirm password is not equal your password")]
        public String PasswordAgain { get; set; }
        public ICollection<Video>? videos { get; set; }

        public override string ToString()
        {
            return $"{UserName} {Password}";
        }
    }
}
