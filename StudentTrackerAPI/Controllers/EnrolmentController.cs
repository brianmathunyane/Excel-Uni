using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTracker.Interfaces;
using StudentTracker.Models;

namespace StudentTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EnrolmentController : ControllerBase
    {
        private readonly IEnrolmentService _EnrolmentService;

        public EnrolmentController(IEnrolmentService EnrolmentService)
        {
            _EnrolmentService = EnrolmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnrolments() => Ok(await _EnrolmentService.GetAllEnrolmentAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrolmentsById(int id)
        {
            var Enrolment = await _EnrolmentService.GetEnrolmentByIdAsync(id);
            return Enrolment == null ? NotFound() : Ok(Enrolment);
        }

    

        [HttpPost]
        public async Task<IActionResult> AddEnrolment(Enrolment Enrolment)
        {
            var created = await _EnrolmentService.CreateEnrolmentAsync(Enrolment);
            return CreatedAtAction(nameof(GetEnrolmentsById), new { id = created.EnrolmentId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrolment(int id, Enrolment Enrolment)
        {
            if (id != Enrolment.EnrolmentId) return BadRequest();

            var updated = await _EnrolmentService.UpdateEnrolmentAsync(Enrolment);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _EnrolmentService.DeleteEnrolmentAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
