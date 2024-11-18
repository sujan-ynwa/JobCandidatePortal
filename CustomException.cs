using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobCandidateProject
{
    public static class CustomException
    {
        public static string GenerateResponse(this Exception ex)
        {


            string response = ex.InnerException.Message;                


            var result = JsonConvert.SerializeObject(response);

            return result;
        }

        
    }
}
