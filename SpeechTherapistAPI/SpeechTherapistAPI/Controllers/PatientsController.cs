using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpeechTherapist.Core.DTOs;
using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Service;
using SpeechTherapistAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeechTherapistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        public PatientsController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public ActionResult Get()
        {
            var patients = _patientService.GetAll();
            return Ok(_mapper.Map<PatientDto>(patients));
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
            return Ok(_mapper.Map<PatientDto>(p));
        }

        // POST api/<PatientsController>
        [HttpPost]
        public ActionResult Post([FromBody] PatientPostModel value)
        {
            var p = _patientService.GetByIdNumber(value.IdNumber);
            if (p == null)
            {
                _patientService.Add(_mapper.Map<Patients>(value));
                return Ok();
            }
            

                return Conflict(p);

        }

        // PUT api/<PatientsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PatientPutModel value)
        {
            var p = _patientService.GetById(id);
            if (p == null)
            {
                
                return NotFound();
            }

            _patientService.Update(id, _mapper.Map<Patients>(value));  
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
