﻿using JobCandidateProject.Models.JobCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobCandidateProject.Repository.JobCandidateRepo
{
    public interface IJobCandidateService
    {
        public Task<List<JobCandidateDTO>> CreateUpdateCandidate(List<JobCandidateDTO> data);
    }
}
