using JobCandidateProject.Models.JobCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobCandidateProject.Repository.JobCandidateRepo
{
    public class JobCandidateService : IJobCandidateService
    {
        IJobCandidateRepository _repo;

        public JobCandidateService(IJobCandidateRepository repo)
        {
            _repo = repo;
        }
        public async Task<JobCandidateDTO> CreateUpdateCandidate(JobCandidateDTO data)
        {
            return await _repo.CreateUpdateCandidate(data);
        }
    }
}
