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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((!accelerationId.HasValue && !userId.HasValue) || (accelerationId.HasValue && userId.HasValue))
                return Ok(null);

            else if (accelerationId.HasValue)
            {
                var companies = _service.FindByAccelerationId(accelerationId.Value);
                return Ok(_mapper.Map<IList<CompanyDTO>>(companies));
            }
            else
            {
                var companies = _service.FindByUserId(userId.Value);
                return Ok(_mapper.Map<IList<CompanyDTO>>(companies));
            }
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            var company = _service.FindById(id);
            return Ok(_mapper.Map<CompanyDTO>(company));
        }

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            var company = _mapper.Map<Company>(value);
            company = _service.Save(company);
            return Ok(_mapper.Map<CompanyDTO>(company));
        }
    }
}
