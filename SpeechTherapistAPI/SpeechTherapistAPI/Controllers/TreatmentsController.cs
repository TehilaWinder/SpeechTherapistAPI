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
        public async Task<ActionResult> Get()
        {
            var treatments= await _treatmentsServie.GetAllAsync();
            return Ok(_mapper.Map<List<TreatmentsDto>>(treatments));
        }

        // GET api/<TreatmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string name)
        {
            var t = await _treatmentsServie.GetByNameAsync(name);
            if (t == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TreatmentsDto>(t));
        }

        // POST api/<TreatmentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TreatmentsPostModel value)
        {

            var t = _treatmentsServie.GetByNameAsync(value.TreatmentName);
            if (t == null)
            {
                await _treatmentsServie.AddAsync(_mapper.Map<Treatments>(value));
                return Ok(value);
            }
            else

                return Conflict(t);
        }

        // PUT api/<TreatmentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TreatmentsPutModel value)
        {
            var p = _treatmentsServie.GetByIdAsync(id);
            if (p == null)
            {

                return NotFound();
            }

            await _treatmentsServie.UpdateAsync(id, _mapper.Map<Treatments>(value));
            return Ok();
        }

        // DELETE api/<TreatmentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _treatmentsServie.GetByIdAsync(id);
            if (p == null)
            {

                return NotFound();
            }

            _treatmentsServie.DeleteAsync(id);
            return NoContent();
        }
    }
}
