using System.ComponentModel.DataAnnotations;

namespace Demo.API.Models.DTO
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(100)]
        public String NameLoai { get; set; }
    }
}
