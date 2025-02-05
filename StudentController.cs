using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollmentMicroservice.Data;
using StudentEnrollmentMicroservice.Model;

namespace StudentEnrollmentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
            private readonly ApplicationDbContext dbContext;

            public StudentController(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
        [HttpGet]
        public IActionResult GetStudent()
        {
            var student = dbContext.Students.ToList();
            if (student == null) return NotFound();
            return Ok(student);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            var student = dbContext.Students.Find(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public IActionResult AddStudent(AddStudentDto addStudentDto)
        {
            var studentEntity = new Student()
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                Email = addStudentDto.Email,
                EnrollmentDate =addStudentDto.EnrollmentDate,
           };

            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();
            return Ok(studentEntity);
        }
        [HttpPut]
        [Route("{id:int}")]

        public IActionResult UpdateStudent(int id, UpdateStudentDto updateStudentDto)
        {
            var student = dbContext.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            student.FirstName = updateStudentDto.FirstName;
            student.LastName = updateStudentDto.LastName;
            student.Email = updateStudentDto.Email;
            student.EnrollmentDate = updateStudentDto.EnrollmentDate;
            dbContext.SaveChanges();

            return Ok(student);
        }
        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteStudent(int id)
        {
            var feedback = dbContext.Students.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }
            dbContext.Students.Remove(feedback);
            dbContext.SaveChanges();
            return Ok(feedback);
        }
    }
}
