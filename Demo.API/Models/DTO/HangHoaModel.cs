using System.ComponentModel.DataAnnotations;

namespace Demo.API.Models.DTO
{
    public class HangHoaModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Content { get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
        public byte Sale { get; set; }

    }
}
