using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Disciplines")]
    public class Discipline
    {
        [Key]
        int Id { get; set; }

        public string Name { get; set; }
    }
}
