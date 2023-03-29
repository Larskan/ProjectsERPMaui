
using ProjectsERPMaui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
<<<<<<< HEAD
=======
using System.Text.Json.Serialization;
>>>>>>> 6807885ae19d1dbe1846aa3509d4314567bab109
using System.Threading.Tasks;

namespace ProjectsERPMaui.Services
{
    class DynamicsService
    {
        HttpClient httpClient;

<<<<<<< HEAD
        private string IpAd = "";
=======
        // change her to your ip
        string IpAd = "http://172.28.126.160:7048";

>>>>>>> 6807885ae19d1dbe1846aa3509d4314567bab109
        public DynamicsService()
        {
            this.httpClient = new HttpClient();
        }

<<<<<<< HEAD
        public Employee employee { get; set; } = new Employee();
        List<Project> projectList;
        public async Task<List<Project>> GetProject()
        {
            if (projectList?.Count > 0)
                return projectList;
             
            // Online
            var response = await httpClient.GetAsync(IpAd);
=======
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

>>>>>>> 6807885ae19d1dbe1846aa3509d4314567bab109
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

        public async Task<Employee> GetEmployee(string username, string password)
        {
            var _token = $"admin:Password";
            var _tokenBase64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(_token));
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Basic", "YWRtaW46UGFzc3dvcmQ=");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _tokenBase64);

            String jsonData = "{\"username\": \"" + username +
                    "\", \"password\": \"" + password + "\" }";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage resp = await httpClient.PostAsync(IpAd,content);

            if(resp.IsSuccessStatusCode)
            {
                string temp = await resp.Content.ReadAsStringAsync();
                employee = JsonSerializer.Deserialize<Employee>(temp);
            }

            return employee;
        }
    }
}
