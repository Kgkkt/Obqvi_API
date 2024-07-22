using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obqvi_API.DB.Models
{
    [Table("o_users")]
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Username { get; set; }

        [MaxLength(200)]
        public string? Password { get; set; }

        [MaxLength(100)]
        public string? Mail { get; set; }

    }
}
