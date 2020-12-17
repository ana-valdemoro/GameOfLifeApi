using System.IO;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace GameOfLifeApi2.HealthCheck
{
    public class FileHealthCheck : IHealthCheck
    {
        public readonly IConfiguration Configuration;
        public readonly string CurrentDirectory;

        public FileHealthCheck(IConfiguration configuration)
        {
            Configuration = configuration;
            CurrentDirectory = Directory.GetCurrentDirectory();
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(HasWritePermissionOnDirectory()
                ? HealthCheckResult.Healthy("A healthy result.Folder is accessible to read and write")
                : HealthCheckResult.Unhealthy("Unhealthy result: Folder doesn't have write permissions"));
        }

        public bool HasWritePermissionOnDirectory()
        {
            var writeAllow = false;
            //FileInfo fileInfo = new FileInfo(CurrentDirectory);
            //if ((fileInfo.Attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly) {
            //    writeAllow = true;
            //}
            DirectoryInfo dInfo = new DirectoryInfo(CurrentDirectory);
            DirectorySecurity accessControlList = dInfo.GetAccessControl();
            var accessRules = accessControlList.GetAccessRules(true, true, 
                typeof(System.Security.Principal.SecurityIdentifier));
            foreach (FileSystemAccessRule rule in accessRules)
            {
                if ((FileSystemRights.Write & rule.FileSystemRights) != FileSystemRights.Write)
                    continue;
                if (rule.AccessControlType == AccessControlType.Allow) writeAllow = true;
            }
            return writeAllow;
        }
        
    }
}
