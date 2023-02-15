using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;

namespace Demo.API.Models.Entities
{
    public class Loai
    {
        [Key]
        public Guid MaLoai { get; set; }
        [Required]
        [MaxLength(100)]
        public String NameLoai { get; set; }

        public virtual ICollection<HangHoa> HangHoas { get; set; }

    }
}
