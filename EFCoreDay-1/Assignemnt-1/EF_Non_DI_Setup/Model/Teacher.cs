using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EF_Non_DI_Setup.Model
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
