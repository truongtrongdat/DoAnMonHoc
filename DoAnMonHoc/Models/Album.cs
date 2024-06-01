using System.ComponentModel.DataAnnotations;

namespace DoAnMonHoc.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenAlbum { get; set; }

        public string GhiChu { get; set; }

        public string LinkAlbumAnh { get; set; }

        public string LinkOutAlbumAnh { get; set; }
        public string Type { get; set; }
    }
}
