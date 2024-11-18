using JobCandidateProject.Models;
using JobCandidateProject.Models.JobCandidate;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<JobCandidateDTO>> CreateUpdateCandidate(List<JobCandidateDTO> data)
        {
           
            //get list of emails for searching the DB 
            var all_emails_from_dto = data.Select(s => s.Email.ToLower()).ToList();

            //search through db and find the emails that already exists.. use them to update
            var candidates_for_update = _dbContext.Jobcandidate.Where(candidate => all_emails_from_dto.Contains(candidate.Email.ToLower())).ToList();

            //get the remaining data for insert
            var candidates_for_insert = data.Where(dto => !candidates_for_update.Any(candidate => candidate.Email.ToLower() == dto.Email.ToLower())).ToList();

            //_dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE Jobcandidate");

            if (candidates_for_update.Count() > 0) // update the user if already exists
            {
                data.ForEach(dto =>
                {
                    var index = candidates_for_update.FindIndex(candidate => candidate.Email.ToLower() == dto.Email);
                    if(index != -1)
                    {
                        candidates_for_update[index].FirstName = dto.FirstName;
                        candidates_for_update[index].LastName = dto.LastName;
                        candidates_for_update[index].PhoneNumber = dto.PhoneNumber;
                        candidates_for_update[index].TimeInterval = dto.TimeInterval;
                        candidates_for_update[index].LinkedInURL = dto.LinkedInURL;
                        candidates_for_update[index].GitHubURL = dto.GitHubURL;
                        candidates_for_update[index].Comment = dto.Comment;
                    }
                });                

            }
            if(candidates_for_insert.Count() > 0)// create new user
            {
                var candidate_list = new List<JobCandidateData>();
                candidates_for_insert.ForEach(dto =>
                {
                    candidate_list.Add(new JobCandidateData {
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        PhoneNumber = dto.PhoneNumber,
                        Email = dto.Email,
                        TimeInterval = dto.TimeInterval,
                        LinkedInURL = dto.LinkedInURL,
                        GitHubURL = dto.GitHubURL,
                        Comment = dto.Comment
                    });
                });

                _dbContext.AddRange(candidate_list);
            }
                       
             await _dbContext.SaveChangesAsync();
            return data;
        }
    }
}
