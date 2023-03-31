
using ProjectsERPMaui.Model;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
        private string IP_AD = "http://172.28.126.160:7048";
        // change hier your user and password
        private string USER_PASS = $"admin:Password";

        public DynamicsService()
        {
            this.httpClient = new HttpClient();
        }


        Employee employee;
        /// <summary>
        /// checks if the user exist and the pssword is correct witch the user 
        /// has entered in the application by comunicting with dynamics
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployee(string username, string password)
        {
            employee = new Employee();

            var _token = USER_PASS;
            var _tokenBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_token));

            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _tokenBase64);

            //Sending a string as a Json
            String jsonData = "{\"username\": \"" + username +
                                "\", \"password\": \"" + password + "\" }";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(IP_AD + "/BC/ODataV4/ERPWebGet_Login?Company=CRONUS%20Danmark%20A%2FS", content);

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

        List<Project> projectClass;
        /// <summary>
        /// gets all projects with are available for the user who is login
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public async Task<List<Project>> GetProjects(int empID)
        {
            projectClass = new List<Project>();

            HttpClient httpClient = new HttpClient();

            var _token = USER_PASS;
            var _tokenBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_token));

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _tokenBase64);

            String jsonData = "{\"empId\":\""+ empID + "\" }";

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(IP_AD + "/BC/ODataV4/ERPWebGet_GetProjectTask?Company=CRONUS%20Danmark%20A%2FS", content);

            string data = "";

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
                ERPJsonConverterClass Json = JsonSerializer.Deserialize<ERPJsonConverterClass>(data);
                //root = JsonSerializer.Deserialize<Root>(Json.value);
                projectClass = JsonSerializer.Deserialize<List<Project>>(Json.value);
            }
            else
            {
                Console.WriteLine("Error: ", "somthing went wrong", "OK");
            }

            return projectClass;
        }

        bool done;
        /// <summary>
        /// updates the time used for the selected task
        /// </summary>
        /// <param name="projectTask"></param>
        /// <returns></returns>
        public async Task<bool> UpdateTasks(ProjectTask projectTask)
        {

            HttpClient httpClient = new HttpClient();

            var _token = USER_PASS;
            var _tokenBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_token));

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _tokenBase64);

            //ProjectTask temp = new ProjectTask();
            String jsonData = JsonSerializer.Serialize<ProjectTask>(projectTask);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(IP_AD + "/BC/ODataV4/ERPWebGet_GetProjectTask?Company=CRONUS%20Danmark%20A%2FS", content);

            string data = "";

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
                ERPJsonConverterClass Json = JsonSerializer.Deserialize<ERPJsonConverterClass>(data);
                //root = JsonSerializer.Deserialize<Root>(Json.value);
                done = JsonSerializer.Deserialize<bool>(Json.value);
            }
            else
            {
                Console.WriteLine("Error: ", "somthing went wrong", "OK");
            }

            return done;
        }
    }
}
