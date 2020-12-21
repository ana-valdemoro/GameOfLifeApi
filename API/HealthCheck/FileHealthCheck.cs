using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace GameOfLifeApi2.HealthCheck {
    public class FileHealthCheck : IHealthCheck {
        public readonly IConfiguration Configuration;
        public readonly string CurrentDirectory;
        private readonly ILogger Logger;

        public FileHealthCheck(IConfiguration configuration, ILogger<FileHealthCheck> logger) {
            Configuration = configuration;
            CurrentDirectory = Directory.GetCurrentDirectory();
            Logger = logger;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(HasWritePermissionOnDirectory()
                ? HealthCheckResult.Healthy("A healthy result.Folder is accessible to read and write")
                : HealthCheckResult.Unhealthy("Unhealthy result: Folder doesn't have write permissions"));
        }

        public bool HasWritePermissionOnDirectory() {
            var writeAllow = false;
            FileIOPermission directoryPermission = new FileIOPermission(FileIOPermissionAccess.Write, CurrentDirectory);
            try
            {
                directoryPermission.Demand();
                writeAllow = true;
                Logger.LogInformation("El directorio actual tiene permisos");
            }
            catch (SecurityException s)
            {
                Logger.LogInformation(s.Message);
            }
            return writeAllow;
        }
        
    }
}
