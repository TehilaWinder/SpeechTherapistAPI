using Microsoft.AspNetCore.Mvc;
using SpeechTherapistAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeechTherapistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private IDataContext _context;
        public AppointmentsController(IDataContext context)
        {
            _context = context;
        }
        // GET: api/<AppointmentsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.appointments);
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var a = _context.appointments.Find(x => x.AppointmentCode == id);
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

            var a = _context.appointments.Find(x => x.AppointmentCode == value.AppointmentCode);
            if (a == null)
            {
                _context.appointments.Add(value);
                return Ok(a);
            }
            else

                return Conflict(a);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
