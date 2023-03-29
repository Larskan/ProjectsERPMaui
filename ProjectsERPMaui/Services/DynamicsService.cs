
using ProjectsERPMaui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Services
{
    class DynamicsService
    {
        HttpClient httpClient;

        private string IpAd = "";
        public DynamicsService()
        {
            this.httpClient = new HttpClient();
        }

        public Employee employee { get; set; } = new Employee();
        List<Project> projectList;
        public async Task<List<Project>> GetProject()
        {
            if (projectList?.Count > 0)
                return projectList;
             
            // Online
            var response = await httpClient.GetAsync(IpAd);
            if (response.IsSuccessStatusCode)
            {
                projectList = await response.Content.ReadFromJsonAsync<List<Project>>();
            }
            // Offline
            /*using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
            */
            return projectList;
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
