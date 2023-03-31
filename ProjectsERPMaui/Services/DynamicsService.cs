
using ProjectsERPMaui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Services
{
    class DynamicsService
    {
        HttpClient httpClient;

        // change her to your ip
        string IpAd = "http://172.28.117.231:7048";

        public DynamicsService()
        {
            this.httpClient = new HttpClient();
        }

        Employee employee;
        public async Task<Employee> GetEmployee(string username, string password)
        {
            employee = new Employee();

            var _token = $"Admin:Pass";
            var _tokenBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_token));

            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _tokenBase64);

            //Sending a string as a Json
            String jsonData = "{\"username\": \"" + username +
                                "\", \"password\": \"" + password + "\" }";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(IpAd + "/BC/ODataV4/ERPWebGet_Login?Company=CRONUS%20Danmark%20A%2FS", content);

            string data = "";

            if (response.IsSuccessStatusCode)
            {
                //converting the string to a Json and than serialize it ad create the employee
                data = await response.Content.ReadAsStringAsync();
                ERPJsonConverterClass Json = JsonSerializer.Deserialize<ERPJsonConverterClass>(data);
                employee = JsonSerializer.Deserialize<Employee>(Json.value);

            }
            else
            {
                await Shell.Current.DisplayAlert("Error: ", "somthing went wrong", "OK");
            }

            return employee;

        }

        Project projects;
        public async Task<Project> GetProjects(int empID)
        {
            projects = new Project();

            var _token = $"Admin:Pass";
            var _tokenBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_token));

            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _tokenBase64);

            //Sending a string as a Json
            String jsonData = "{\"EmpID\": \"" + empID + "\" }";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(IpAd + "/BC/ODataV4/ERPWebGet_ProjectAndTask?Company=CRONUS%20Danmark%20A%2FS", content);

            string data = "";

            if (response.IsSuccessStatusCode)
            {
                //converting the string to a Json and than serialize it ad create the employee
                data = await response.Content.ReadAsStringAsync();
                ERPJsonConverterClass Json = JsonSerializer.Deserialize<ERPJsonConverterClass>(data);
                projects = JsonSerializer.Deserialize<Project>(Json.value);

            }
            else
            {
                await Shell.Current.DisplayAlert("Error: ", "somthing went wrong", "OK");
            }

            return projects;
        }
    }
}
