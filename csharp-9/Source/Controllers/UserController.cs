using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            if ((string.IsNullOrWhiteSpace(accelerationName) && !companyId.HasValue) || (!string.IsNullOrWhiteSpace(accelerationName) && companyId.HasValue))
                return Ok(null);

            else if (!string.IsNullOrWhiteSpace(accelerationName))
            {
                var users = _service.FindByAccelerationName(accelerationName);
                return Ok(_mapper.Map<IList<UserDTO>>(users));
            }
            else
            {
                var users = _service.FindByCompanyId(companyId.Value);
                return Ok(_mapper.Map<IList<UserDTO>>(users));
            }
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _service.FindById(id);
            return Ok(_mapper.Map<UserDTO>(user));
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            var user = _mapper.Map<User>(value);
            user = _service.Save(user);
            return Ok(_mapper.Map<UserDTO>(user));
        }

    }
}
