using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginFormWithDatabasesession.Models
{
    [Table("User1")]
    public class User1
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string? Email { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
