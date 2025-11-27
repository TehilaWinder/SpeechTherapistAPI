using Microsoft.AspNetCore.Mvc;
using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeechTherapistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IPatientService _patientService;
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_patientService.GetAll());
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var p = _patientService.GetById(id);
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
            var p = _patientService.GetById(value.PatientCode);
            if (p == null)
            {
                _patientService.Add(value);
                return Ok();
            }
            

                return Conflict(p);

        }

        // PUT api/<PatientsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Patients value)
        {
            var p = _patientService.GetById(id);
            if (p == null)
            {
                
                return NotFound();
            }

            _patientService.Update(id, value);  
            return Ok();
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _patientService.GetById(id);
            if (p == null)
            {

                return NotFound();
            }

            _patientService.Delete(id);
            return NoContent();
        }
    }
}
