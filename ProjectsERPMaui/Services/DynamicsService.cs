
using ProjectsERPMaui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Services
{
    class DynamicsService
    {
        HttpClient httpClient;
        public DynamicsService()
        {
            this.httpClient = new HttpClient();
        }

        List<Project> projectList;
        public async Task<List<Project>> GetProject()
        {
            if (projectList?.Count > 0)
                return projectList;

            // Online
            var response = await httpClient.GetAsync("http adress to dynamics");
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
    }
}
