using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonHoc.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã đặt lịch")]
        public int Madatlich { get; set; }

        [ForeignKey("Photopackage")]
        public int Magoichup { get; set; }
        public Photopackage photopackage { get; set; }

        [Display(Name = "Tên gói chụp")]
        public string Tengoichup { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        [Display(Name = "Họ và Tên")]
        public string Hovaten { get; set; }


        [Required(ErrorMessage = "*")]
        [StringLength(10)]
        [Display(Name = "SĐT")]
        public string Sđt { get; set; }



        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }



        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string Ghichu { get; set; }



        [Display(Name = "Ngày dự kiến chụp")]
        public DateTime Ngaydukienchup { get; set; }


        [Display(Name= "Thời gian liên hệ")]
        public DateTime Thoigianlienheit { get; set; }

    }
}
