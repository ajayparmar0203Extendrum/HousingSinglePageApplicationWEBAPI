using System.ComponentModel.DataAnnotations;

namespace HousingSinglePageApplicationWEBAPI.Models
{
    public class PropertyType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
