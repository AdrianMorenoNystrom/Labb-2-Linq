using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LABB_2.Models
{
    public enum Group
    {
        NET23,
        NET22,
        JAVA23,
        COBOL24
    }
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public Group? Group { get; set; }
        [ForeignKey("Student")]
        public int FkStudentId { get; set; }
        public virtual Student? Student { get; set; }
    }
}

