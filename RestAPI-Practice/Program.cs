using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using static RestAPI_Practice.Rootobject;

namespace RestAPI_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                GetEmployeeDataFromRestApi();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.ReadLine();
        }
        public static void GetEmployeeDataFromRestApi()
        {
            string uri = "https://dummy.restapiexample.com/api/v1/";
            var client = new RestClient(uri);
            var request = new RestRequest("employees");
            var response = client.Execute<List<Rootobject>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Rootobject result = JsonConvert.DeserializeObject<Rootobject>(rawResponse);

                foreach (var value in result.data)
                {
                    Console.WriteLine($"ID : {value.id}");
                    Console.WriteLine($"Age : {value.employee_age}");

                    Console.WriteLine($"Name : {value.employee_name}");
                    Console.WriteLine($"Salary : {value.employee_salary}");
                }
            }
        }
    }
}
