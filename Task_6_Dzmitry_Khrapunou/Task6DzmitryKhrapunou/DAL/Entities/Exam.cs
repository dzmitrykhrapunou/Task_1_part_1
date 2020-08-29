using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Exams")]
    public class Exam
    {
        [Key]
        int Id { get; set; }

        [ForeignKey("SessionId")]
        public int SessionId { get; set; }

        [ForeignKey("GroupId")]
        public int GroupId { get; set; }

        [ForeignKey("DisciplineId")]
        public int DisciplineId { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }
    }    
}
