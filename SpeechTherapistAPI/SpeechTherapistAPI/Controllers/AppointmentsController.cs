using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpeechTherapist.Core.DTOs;
using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Service;
using SpeechTherapist.Service;
using SpeechTherapistAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeechTherapistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;
        public AppointmentsController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }
        // GET: api/<AppointmentsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var appointments = await _appointmentService.GetAllAsync();
            return Ok(_mapper.Map<List<AppointmentsDto>>(appointments));
        }


        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(DateTime dateAndHour)
        {

            var a = await _appointmentService.GetByDateAndHourAsync(dateAndHour);
            if (a == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AppointmentsDto>(a));
        }
        // POST api/<AppointmentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AppointmentsPostModel value)
        {

            var a = await _appointmentService.GetByDateAndHourAsync(value.DateAndHour);
            if (a == null)
            {
                await _appointmentService.AddAsync(_mapper.Map<Appointments>(value));
                return Ok(value);
            }
            else

                return Conflict(a);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AppointmentsPutModel value)
        {
            var p = _appointmentService.GetByIdAsync(id);
            if (p == null)
            {

                return NotFound();
            }

            await _appointmentService.UpdateAsync(id, _mapper.Map<Appointments>(value));
            return Ok();
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
             var p = await _appointmentService.GetByIdAsync(id);
            if (p == null)
            {

                return NotFound();
            }

            await _appointmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
