using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotnet_cyberpunk_challenge_4.Models.Arasaka
{
    public class ArasakaDevice
    {
        public int id { get; set; }
        public string name { get; set; }
        public string architecture { get; set; }
        public string processorType {get;set;}
        public string region { get; set; }
        public string athenaAccessKey {get;set;}
        // Foreign Key for Cluster
        public int clusterId { get; set; }

        // Navigation property for the Cluster
        [JsonIgnore]  // Prevent circular reference during serialization
        public virtual ArasakaCluster cluster { get; set; }
    }
}