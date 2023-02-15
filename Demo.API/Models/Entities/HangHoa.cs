using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.API.Models.Entities
{
    public class HangHoa
    {
        [Key]
        public Guid MaHh { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Content { get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
        public byte Sale { get; set; }

        public Guid? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }
}
