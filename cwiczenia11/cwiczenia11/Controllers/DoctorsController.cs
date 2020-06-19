using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia11.DAL.DTOs.Requests;
using cwiczenia11.DAL.DTOs.Responses;
using cwiczenia11.DAL.Services.DoctorDbService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace cwiczenia11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorDbService _service;

        public DoctorController(IDoctorDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var res = _service.GetAllDoctors();
            if (!res.Equals(null))
            {
                return Ok(res);
            }
            return BadRequest("Error: Something went wrong");
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            var res = _service.GetDoctor(id);
            if (!res.Equals(null))
            {
                return Ok(res);
            }
            return BadRequest("Error: Something went wrong");
        }
        [HttpPost]
        public IActionResult InsertDoctor(InsertDoctorRequest request)
        {
            var res = _service.InsertDoctor(request);
            if (!res.Equals(null))
            {
                return Ok(res);
            }
            return BadRequest("Error: Something went wrong :/");
        }

        [HttpPut]
        public IActionResult ModifyDoctor(ModifyDoctorRequest request)
        {
            var res = _service.ModifyDoctor(request);
            if (!res.Equals(null))
            {
                return Ok(res);
            }
            return BadRequest("Error: Something went wrong :/");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var res = _service.DeleteDoctor(id);
            if (!res.Equals(null))
            {
                return Ok(res);
            }
            return BadRequest("Error: Something went wrong :/");
        }
    }
}