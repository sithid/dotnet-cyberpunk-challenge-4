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
        
        // TODO: Add a List of ArasakaDeviceDto.
        // TIP: To make sure things work properly with SQLite the List should also be nullable
    }

    // TODO: Add the class for the new ArasakaDevice DTO. The ArasakaClusterDto should reference this class

}