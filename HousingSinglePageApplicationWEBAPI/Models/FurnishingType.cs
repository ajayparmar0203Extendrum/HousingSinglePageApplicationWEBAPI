using System.ComponentModel.DataAnnotations;

namespace HousingSinglePageApplicationWEBAPI.Models
{
    public class FurnishingType :BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
