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
        public string CreateUpdateCandidate([FromBody] JobCandidateDTO data)
        {
            _service.CreateUpdateCandidate(data);

            return "Success";
        }

    }

}
