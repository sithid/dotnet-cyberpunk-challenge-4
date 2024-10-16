using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotnet_cyberpunk_challenge_4.Models.Arasaka
{
    public class ArasakaDeviceProcess
    {
        public int id { get; set; }
        public string memory { get; set; }
        public string family { get; set; }
        public ICollection<string> openFiles { get; set; }
        public int deviceId {get;set;}
        // Navigation property for ArasakaDevice
        [JsonIgnore]  // Prevent circular reference during serialization
        public virtual ArasakaDevice ArasakaDevice { get; set; }
    }
}