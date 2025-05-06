using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentTracker.Models
{
    [Table("Enrolment")]
    public class Enrolment
    {
        [Key]
        public int EnrolmentId { get; set; }

        [StringLength(255)]
        public string? Institution { get; set; }

        [StringLength(255)]
        public string Qualification { get; set; } = string.Empty;

        [StringLength(50)]
        public string? QualificationType { get; set; }

        public DateTime? EnrolmentDate { get; set; }

        public Double? AverageToDate { get; set; }
    }
}
