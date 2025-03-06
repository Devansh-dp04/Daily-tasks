using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Env_Based_Connection
{
    public class ClassInfo
    {
        [Key]
        public int Classid { get; set; }
        public int Standard { get; set; }
        public string Section { get; set; } 


    }
}
