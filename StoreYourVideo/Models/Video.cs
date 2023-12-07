using System.ComponentModel.DataAnnotations;

namespace StoreYourVideo.Models
{
    public class Video
    {
        [Key]
        public String ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string url { get; set; }
    }
}
