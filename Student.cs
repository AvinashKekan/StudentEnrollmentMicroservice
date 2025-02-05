using System.ComponentModel.DataAnnotations;

namespace StudentEnrollmentMicroservice.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}
