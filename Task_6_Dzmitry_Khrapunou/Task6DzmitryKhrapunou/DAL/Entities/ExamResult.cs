using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("ExamResults")]
    public class ExamResult
    {
        [Key]
        int Id { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        [ForeignKey("ExamId")]
        public int ExamId { get; set; }

        public int Mark { get; set; }
    }    
}
