using EmployeePayroll_RestAPI;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace EmployeePayroll_RestAPITest.Tests
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }
    [TestClass]
    public class RestSharpTestCase
    {
        RestClient Client;

        [TestInitialize]
        public void SetUp()
        {
            Client = new RestClient("http://localhost:3000");
        }
        private RestResponse getEmployeeList()
        {
            //arrange
            RestRequest request = new RestRequest("/Employee", Method.Get);

            //act 
            RestResponse response = Client.Execute(request);
            return response;
        }
        [TestMethod]
        public void OnCallingGETApi_ReturnEmployeeList()
        {
            RestResponse response = getEmployeeList();

            //assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(5, dataResponse.Count);

            foreach (Employee e in dataResponse)
            {
                System.Console.WriteLine("id: " + e.Id + ", Name: " + e.Name + ", Salary: " + e.Salary);
            }

        }
    }
}