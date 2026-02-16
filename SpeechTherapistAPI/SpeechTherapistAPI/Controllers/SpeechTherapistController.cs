using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "SpeechTherapist")]
    public class SpeechTherapistController : ControllerBase
    {
        private readonly ISpeechTherapistService _speechTherapistService;
        private readonly IMapper _mapper;
        private readonly IUsersService _userService;
        public SpeechTherapistController(ISpeechTherapistService speechTherapistService, IUsersService usersService, IMapper mapper)
        {
            _speechTherapistService = speechTherapistService;
            _mapper = mapper;
            _userService = usersService;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Get()
        {
            var speechTerapists = await _speechTherapistService.GetAllAsync();
            return Ok(_mapper.Map<List<SpeechTherapistDto>>(speechTerapists));
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Get(int id)
        {
            var p = await _speechTherapistService.GetByIdAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PatientDto>(p));
        }

        // POST api/<PatientsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SpeechTherapistPostModel value)
        {
            var user = new Users { UserName = value.UserName, password = value.Password, Type = eType.SpeechTherapist };
            var User = await _userService.AddUserAsync(user);
            var newSpeechTherapist = _mapper.Map<SpeechTerapist>(value);
            newSpeechTherapist.User = User;
            newSpeechTherapist.UserCode = User.UserCode;
            var p = await _speechTherapistService.GetByIdAsync(newSpeechTherapist.SpeechTherapistCode);

            if (p == null)
            {
                await _speechTherapistService.AddAsync(newSpeechTherapist);
                return Ok();
            }


            return Conflict(p);

        }

        // PUT api/<PatientsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SpeechTherapistPutModel value)
        {
            var p = _speechTherapistService.GetByIdAsync(id);
            if (p == null)
            {

                return NotFound();
            }

            await _speechTherapistService.UpdateAsync(id, _mapper.Map<SpeechTerapist>(value));
            return Ok();
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var p = _speechTherapistService.GetByIdAsync(id);
            if (p == null)
            {

                return NotFound();
            }

            await _speechTherapistService.DeleteAsync(id);
            return NoContent();
        }
    }
}
