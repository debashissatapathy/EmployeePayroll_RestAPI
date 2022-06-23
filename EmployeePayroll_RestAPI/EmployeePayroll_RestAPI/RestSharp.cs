using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll_RestAPI
{
    public class RestSharp
    {
        public void givenEmployee_OnPost_ShouldReturnAddedEmployee()
        {
            //arrange
            RestRequest request = new RestRequest("/Employee", Method.Post);
            JObject jobjectbody = new JObject();
            jobjectbody.Add("Name", "Niketan");
            jobjectbody.Add("Salary", "35000");

            request.AddParameter("application/json", jobjectbody, ParameterType.RequestBody);

        }
    }
}
