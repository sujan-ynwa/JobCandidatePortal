using JobCandidateProject.Models.JobCandidate;
using JobCandidateProject.Repository.JobCandidateRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobCandidateProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobCandidateController : Controller
    {
        IJobCandidateService _service;       
        public JobCandidateController(IJobCandidateService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateUpdateCandidate")]
        public  IActionResult CreateUpdateCandidate([FromBody] List<JobCandidateDTO> data)
        {
            if (ModelState.IsValid)
            {
                return Ok(_service.CreateUpdateCandidate(data));
            }else
            {
                return BadRequest();
            }

        }

    }

}
