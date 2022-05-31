using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Models
{
    public class UserAlbum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [ForeignKey("AppUser")]
        public string IdUser { get; set; }
        public AppUser AppUser { get; set; }
    }
}
