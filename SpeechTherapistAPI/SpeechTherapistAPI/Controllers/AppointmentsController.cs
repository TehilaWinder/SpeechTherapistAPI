using Microsoft.AspNetCore.Mvc;
using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Service;
using SpeechTherapist.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeechTherapistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private IAppointmentService _appointmentService;
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        // GET: api/<AppointmentsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_appointmentService.GetAll());
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var a = _appointmentService.GetById(id);
            if (a == null)
            {
                return NotFound();
            }

            return Ok(a);
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public ActionResult Post([FromBody] Appointments value)
        {

            var a = _appointmentService.GetById(value.AppointmentCode);
            if (a == null)
            {
                _appointmentService.Add(value);
                return Ok(a);
            }
            else

                return Conflict(a);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Appointments value)
        {
            var p = _appointmentService.GetById(id);
            if (p == null)
            {

                return NotFound();
            }

            _appointmentService.Update(id, value);
            return Ok();
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _appointmentService.GetById(id);
            if (p == null)
            {

                return NotFound();
            }

                _appointmentService.Delete(id);
            return NoContent();
        }
    }
}
