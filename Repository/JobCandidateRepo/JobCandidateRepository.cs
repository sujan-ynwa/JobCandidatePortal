using JobCandidateProject.Models.JobCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobCandidateProject.Repository.JobCandidateRepo
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        public Task<JobCandidateDTO> CreateUpdateCandidate(JobCandidateDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
