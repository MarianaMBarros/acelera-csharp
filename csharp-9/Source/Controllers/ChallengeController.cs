using System.Collections.Generic;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _service;
        private readonly IMapper _mapper;

        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (!accelerationId.HasValue && !userId.HasValue)
                return Ok(null);

            var challenges = _service.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value);
            return Ok(_mapper.Map<IList<ChallengeDTO>>(challenges));
        }

        // POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            var challenge = _mapper.Map<Models.Challenge>(value);
            challenge = _service.Save(challenge);
            return Ok(_mapper.Map<ChallengeDTO>(challenge));
        }
    }
}
