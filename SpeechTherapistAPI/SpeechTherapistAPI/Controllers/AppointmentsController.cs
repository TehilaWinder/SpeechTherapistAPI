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
        public ActionResult Get()
        {
            var appointments = _appointmentService.GetAll();
            return Ok(_mapper.Map<List<AppointmentsDto>>(appointments));
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(DateTime dateAndHour)
        {

            var a = _appointmentService.GetByDateAndHour(dateAndHour);
            if (a == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AppointmentsDto>(a));
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public ActionResult Post([FromBody] AppointmentsPostModel value)
        {

            var a = _appointmentService.GetByDateAndHour(value.DateAndHour);
            if (a == null)
            {
                _appointmentService.Add(_mapper.Map<Appointments>(value));
                return Ok(value);
            }
            else

                return Conflict(a);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AppointmentsPutModel value)
        {
            var p = _appointmentService.GetById(id);
            if (p == null)
            {

                return NotFound();
            }

            _appointmentService.Update(id, _mapper.Map<Appointments>(value));
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
