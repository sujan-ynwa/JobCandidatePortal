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
        public async Task<List<JobCandidateDTO>> CreateUpdateCandidate(List<JobCandidateDTO> data)
        {
            if(data.GroupBy(dto=> dto.Email).Where(s=> s.Count() > 1).Count() > 0)
            {
                throw new Exception("Duplicate email found.");
            }
            
            return await _repo.CreateUpdateCandidate(data);
        }
    }
}
