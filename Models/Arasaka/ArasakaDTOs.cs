using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_cyberpunk_challenge_4.Models.Arasaka
{
    public class ArasakaClusterDto
    {
        public string clusterName { get; set; }
        public int nodeCount { get; set; }
        public int cpuCores { get; set; }
        public int memoryGb { get; set; }
        public int storageTb { get; set; }
        public string creationDate { get; set; }
        public string environment { get; set; }
        public string kubernetesVersion { get; set; }
        public string region { get; set; }
        public List<ArasakaDeviceDto>? devices { get; set; }
    }

    public class ArasakaDeviceDto
    {
        public string name { get; set; }
        public string architecture { get; set; }
        public string processorType { get; set; }
        public string region { get; set; }
        public string athenaAccessKey { get; set; }
        public int clusterId {get;set;}
        public List<ArasakaDeviceProcessDto>? processes { get; set; }
    }

    public class ArasakaDeviceProcessDto
    {
        public string memory { get; set; }
        public string family { get; set; }
        public List<string> openFiles { get; set; }
    }

}