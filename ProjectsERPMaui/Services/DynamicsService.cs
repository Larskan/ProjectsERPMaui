
using ProjectsERPMaui.Model;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
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
            //Creates new instance of the Employee class and assigns it to employee variable
            employee = new Employee();

            var _token = USER_PASS;
            //Encoes the _token string to base64 format and assigns it to _tokenBase64
            var _tokenBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_token));

            //Sets the Accept header of the httpClient object to indicate that it can accept JSON data in response
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //Sets the Authorization header of the httpClient object to use basic auth scheme with encoded _token string as credentials
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _tokenBase64);

            //Creates a JSON string with username and password as parameters
            String jsonData = "{\"username\": \"" + username +
                                "\", \"password\": \"" + password + "\" }";
            //Creates a new StringContent object with JSON string and specifies that its JSON Application
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //Sends HTTP POST request to URL with JSON content in body and assigns response to the response variable
            HttpResponseMessage response = await httpClient.PostAsync(IP_AD + "/BC/ODataV4/ERPWebGet_Login?Company=CRONUS%20Danmark%20A%2FS", content);

            string data = "";

            if (response.IsSuccessStatusCode)
            {
                //converting the string to a Json and than serialize it and create the employee
                data = await response.Content.ReadAsStringAsync();
                //Deserializes the data string to instance of ERPJsonConverterClass and assing it to Json var
                ERPJsonConverterClass Json = JsonSerializer.Deserialize<ERPJsonConverterClass>(data);
                //Deserializes the value of Json object to an instance of Employee Class 
                employee = JsonSerializer.Deserialize<Employee>(Json.value);

            }
            else
            {
                //Error message
                await Shell.Current.DisplayAlert("Error: ", "somthing went wrong", "OK");
            }
            //Returns employee object wrapped in Task object
            return employee;

        }

        //Declares list of projects to hold data return by API
        List<Project> projectClass;
        /// <summary>
        /// gets all projects with are available for the user who is login
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public async Task<List<Project>> GetProjects(int empID)
        {
            //Initializes empty list of projects
            projectClass = new List<Project>();

            //Instance of HttpClient class that will be used to send HTTP requests to the API
            HttpClient httpClient = new HttpClient();

            var _token = USER_PASS;
            //Converts token to base64-encoded string for authentication
            var _tokenBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_token));

            //Application/json media type to the list of accepted response formats
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Authorization header to HTTP request
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _tokenBase64);

            //Creates JSON object with Employee ID as its value
            String jsonData = "{\"empId\":\""+ empID + "\" }";

            //New StringContent to hold JSON object
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //Sends POST request to API endpoint with JSON object as the request body
            HttpResponseMessage response = await httpClient.PostAsync(IP_AD + "/BC/ODataV4/ERPWebGet_GetProjectTask?Company=CRONUS%20Danmark%20A%2FS", content);

            string data = "";

            if (response.IsSuccessStatusCode)
            {
                //Retrieves response body as a string
                data = await response.Content.ReadAsStringAsync();
                //Deserializes the data string to instance of ERPJsonConverterClass and assing it to Json var
                ERPJsonConverterClass Json = JsonSerializer.Deserialize<ERPJsonConverterClass>(data);
                //root = JsonSerializer.Deserialize<Root>(Json.value);
                //Deserializes the value of Json object to an instance of Employee Class 
                projectClass = JsonSerializer.Deserialize<List<Project>>(Json.value);
            }
            else
            {
                //Error message
                Console.WriteLine("Error: ", "somthing went wrong", "OK");
            }

            //Returns the list of Project objects retrieved from the API
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
