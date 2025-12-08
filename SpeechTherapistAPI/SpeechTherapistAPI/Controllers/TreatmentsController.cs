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
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentsServie _treatmentsServie;
        private readonly IMapper _mapper;
        public TreatmentsController(ITreatmentsServie treatmentsServie, IMapper mapper)
        {
            _treatmentsServie = treatmentsServie;
            _mapper = mapper;
        }
        // GET: api/<TreatmentsController>
        [HttpGet]
        public ActionResult Get()
        {
            var treatments= _treatmentsServie.GetAll();
            return Ok(_mapper.Map<TreatmentsDto>(treatments));
        }

        // GET api/<TreatmentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string name)
        {
            var t = _treatmentsServie.GetByName(name);
            if (t == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TreatmentsDto>(t));
        }

        // POST api/<TreatmentsController>
        [HttpPost]
        public ActionResult Post([FromBody] TreatmentsPostModel value)
        {

            var t = _treatmentsServie.GetByName(value.TreatmentName);
            if (t == null)
            {
                _treatmentsServie.Add(_mapper.Map<Treatments>(value));
                return Ok(value);
            }
            else

                return Conflict(t);
        }

        // PUT api/<TreatmentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TreatmentsPutModel value)
        {
            var p = _treatmentsServie.GetById(id);
            if (p == null)
            {

                return NotFound();
            }

            _treatmentsServie.Update(id, _mapper.Map<Treatments>(value));
            return Ok();
        }

        // DELETE api/<TreatmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _treatmentsServie.GetById(id);
            if (p == null)
            {

                return NotFound();
            }

            _treatmentsServie.Delete(id);
            return NoContent();
        }
    }
}
