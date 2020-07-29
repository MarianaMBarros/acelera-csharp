using System.Collections.Generic;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _service;
        private readonly IMapper _mapper;

        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/submission
        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            if (!challengeId.HasValue && !accelerationId.HasValue)
                return Ok(null);

            var accelerations = _service.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value);
            return Ok(_mapper.Map<IList<SubmissionDTO>>(accelerations));
        }

        // GET api/submission/higherScore
        [HttpGet("higherScore")]
        public ActionResult<decimal> GetHigherScore(int? challengeId)
        {
            if (!challengeId.HasValue)
                return Ok(null);

            var higherScore = _service.FindHigherScoreByChallengeId(challengeId.Value);
            return Ok(higherScore);
        }

        // POST api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            var submission = _mapper.Map<Submission>(value);
            submission = _service.Save(submission);
            return Ok(_mapper.Map<SubmissionDTO>(submission));
        }
    }
}
