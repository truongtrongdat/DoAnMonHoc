using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonHoc.Models
{
    public class Photopackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã gói chụp")]

        public int Magoichup { get; set; }
        [Display(Name = "Tên gói chụp")]
        public string Tengoichup { get; set; }


    }
}
