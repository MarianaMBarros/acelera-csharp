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
    public class AccelerationController : ControllerBase
    {
        private readonly IAccelerationService _service;
        private readonly IMapper _mapper;

        public AccelerationController(IAccelerationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/acceleration
        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (!companyId.HasValue)
                return Ok(null);

            var accelerations = _service.FindByCompanyId(companyId.Value);
            return Ok(_mapper.Map<IList<AccelerationDTO>>(accelerations));
        }

        // GET api/acceleration/{id}
        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            var acceleration = _service.FindById(id);
            return Ok(_mapper.Map<AccelerationDTO>(acceleration));
        }

        // POST api/acceleration
        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            var acceleration = _mapper.Map<Acceleration>(value);
            acceleration = _service.Save(acceleration);
            return Ok(_mapper.Map<AccelerationDTO>(acceleration));
        }
    }
}
