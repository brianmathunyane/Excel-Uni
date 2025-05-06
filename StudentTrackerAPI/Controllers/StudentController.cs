using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTracker.Interfaces;
using StudentTracker.Models;

namespace StudentTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        private readonly IStudentService _StudentService;

        public StudentController(IStudentService StudentService)
        {
            _StudentService = StudentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents() => Ok(await _StudentService.GetAllStudentsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var Student = await _StudentService.GetStudentByIdAsync(id);
            return Student == null ? NotFound() : Ok(Student);
        }

        [HttpGet("Studentname/{Studentname}")]
        public async Task<ActionResult<Student>> GetStudentByStudentname(string Studentname)
        {
            var Student = await _StudentService.GetStudentByStudentnameAsync(Studentname);

            if (Student == null)
                return NotFound($"Student with Studentname '{Studentname}' not found.");

            return Ok(Student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Student Student)
        {
            var created = await _StudentService.CreateStudentAsync(Student);
            return CreatedAtAction(nameof(GetStudentById), new { id = created.StudentId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAccount(int id, Student Student)
        {
            if (id != Student.StudentId) return BadRequest();
            var updated = await _StudentService.UpdateStudentAsync(Student);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _StudentService.DeleteStudentAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
