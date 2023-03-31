using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Model
{
    /// <summary>
    /// Converting and splitting the Json to a usable value
    /// </summary>
    internal class ERPJsonConverterClass
    {
        [JsonProperty("@odata.context")]
        public string odatacontext { get; set; }
        public string value { get; set; }
    }
}
