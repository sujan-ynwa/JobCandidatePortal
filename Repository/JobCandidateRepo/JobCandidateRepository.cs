using JobCandidateProject.Models;
using JobCandidateProject.Models.JobCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobCandidateProject.Repository.JobCandidateRepo
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        private readonly AppDbContext _dbContext;

        public JobCandidateRepository(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<JobCandidateDTO> CreateUpdateCandidate(JobCandidateDTO data)
        {
            //check if the user with the given email already exists
           var candidate = _dbContext.Jobcandidate.FirstOrDefault(candi =>  candi.Email.ToLower()==data.Email.ToLower());

            if (candidate != null) // update the user if already exists
            {
                candidate.FirstName = data.FirstName;
                candidate.LastName = data.LastName;
                candidate.PhoneNumber = data.PhoneNumber;
                candidate.TimeInterval = data.TimeInterval;
                candidate.LinkedInURL = data.LinkedInURL;
                candidate.GitHubURL = data.GitHubURL;
                candidate.Comment = data.Comment;

            }else // create new user
            {
                _dbContext.Add(new JobCandidateData
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                    TimeInterval = data.TimeInterval,
                    LinkedInURL = data.LinkedInURL,
                    GitHubURL = data.GitHubURL,
                    Comment = data.Comment
                });
            }
                       
             await _dbContext.SaveChangesAsync();
            return data;
        }
    }
}
