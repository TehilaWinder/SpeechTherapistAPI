using Microsoft.AspNetCore.Mvc;
using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeechTherapistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private ITreatmentsServie _treatmentsServie;
        public TreatmentsController(ITreatmentsServie treatmentsServie)
        {
            _treatmentsServie = treatmentsServie;
        }
        // GET: api/<TreatmentsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_treatmentsServie.GetAll());
        }

        // GET api/<TreatmentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var t = _treatmentsServie.GetById(id);
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

            var t = _treatmentsServie.GetById(value.TreatmentCode);
            if (t == null)
            {
                _treatmentsServie.Add(value);
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
