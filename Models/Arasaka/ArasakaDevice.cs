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
        
        // TODO: We need two properties:
        // The first is a property to hold the Foreign Key for Cluster.
        // Second is to have a navigation property for Cluster, i.e. we need to reference the
        // actual cluster object
        // TIP: Add a decorator on the navigation property for [JsonIgnore] to keep from doing a ciruclar reference
    }
}