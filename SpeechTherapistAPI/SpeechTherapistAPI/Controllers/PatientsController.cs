using Microsoft.AspNetCore.Mvc;
using SpeechTherapistAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeechTherapistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IDataContext _context;
        public PatientsController(IDataContext context)
        {
            _context = context;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.patients);
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var p = _context.patients.Find(x => x.PatientCode == id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        // POST api/<PatientsController>
        [HttpPost]
        public ActionResult Post([FromBody] Patients value)
        {
            var p = _context.patients.Find(x => x.PatientCode == value.PatientCode);
            if (p == null)
            {
                _context.patients.Add(value);
            }
            return Conflict(p);

        }

        // PUT api/<PatientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
