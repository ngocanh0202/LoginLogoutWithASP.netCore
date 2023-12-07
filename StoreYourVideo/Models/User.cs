using System.ComponentModel.DataAnnotations;

namespace StoreYourVideo.Models
{
    public class User
    {
        [Key]
        public String ID { get; set; }
        public String Name { get; set; }
        public String UserName { get; set; }
        public String Password {  get; set; }
        public ICollection<Video> videos { get; set; }
    }
}
