using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
        public async Task<ActionResult> Get()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(_mapper.Map<List<PatientDto>>(patients));
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var p = await _patientService.GetByIdAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PatientDto>(p));
        }

        // POST api/<PatientsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PatientPostModel value)
        {
            var p = _patientService.GetByIdNumberAsync(value.IdNumber);
            if (p == null)
            {
                await _patientService.AddAsync(_mapper.Map<Patients>(value));
                return Ok();
            }
            

                return Conflict(p);

        }

        // PUT api/<PatientsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PatientPutModel value)
        {
            var p = _patientService.GetByIdAsync(id);
            if (p == null)
            {
                
                return NotFound();
            }

            await _patientService.UpdateAsync(id, _mapper.Map<Patients>(value));  
            return Ok();
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var p = _patientService.GetByIdAsync(id);
            if (p == null)
            {

                return NotFound();
            }

            await _patientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
