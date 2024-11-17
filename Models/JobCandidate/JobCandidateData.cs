using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobCandidateProject.Models.JobCandidate
{
    public class JobCandidateData
    {
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime? TimeInterval { get; set; }

        public string? LinkedInURL { get; set; }
        public string? GitHubURL { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
