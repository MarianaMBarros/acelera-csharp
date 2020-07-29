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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/candidate
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if (!companyId.HasValue && !accelerationId.HasValue)
                return Ok(null);

            if (companyId.HasValue)
            {
                var candidates = _service.FindByCompanyId(companyId.Value);
                return Ok(_mapper.Map<IList<CandidateDTO>>(candidates));
            }
            else
            {
                var candidates = _service.FindByAccelerationId(accelerationId.Value);
                return Ok(_mapper.Map<IList<CandidateDTO>>(candidates));
            }
        }

        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            var candidate = _service.FindById(userId, accelerationId, companyId);
            return Ok(_mapper.Map<CandidateDTO>(candidate));
        }

        // POST api/candidate
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            var candidate = _mapper.Map<Candidate>(value);
            candidate = _service.Save(candidate);
            return Ok(_mapper.Map<CandidateDTO>(candidate));
        }
    }
}
