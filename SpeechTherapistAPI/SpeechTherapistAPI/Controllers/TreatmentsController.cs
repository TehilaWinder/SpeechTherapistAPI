using Microsoft.AspNetCore.Mvc;
using SpeechTherapistAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeechTherapistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private IDataContext _context;
        public TreatmentsController(IDataContext context)
        {
            _context = context;
        }
        // GET: api/<TreatmentsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.treatments);
        }

        // GET api/<TreatmentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var t = _context.treatments.Find(x => x.TreatmentCode == id);
            if (t == null)
            {
                return NotFound();
            }

            return Ok(t);
        }

        // POST api/<TreatmentsController>
        [HttpPost]
        public ActionResult Post([FromBody] Treatments value)
        {

            var t = _context.treatments.Find(x => x.TreatmentCode == value.TreatmentCode);
            if (t == null)
            {
                _context.treatments.Add(value);
                return Ok(t);
            }
            else

                return Conflict(t);
        }

        // PUT api/<TreatmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TreatmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
