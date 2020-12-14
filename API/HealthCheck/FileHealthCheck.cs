using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GameOfLifeApi2.HealthCheck
{
    public class FileHealthCheck: IHealthCheck
    {
        public readonly IConfiguration Configuration;

        public FileHealthCheck(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string path = @Configuration["HealthCheck:FilePath"];

            if (File.Exists(path))
            {
                try
                {
                    FileStream fs = File.Open(path, FileMode.Open);
                    fs.Close();
                    return Task.FromResult(
                        HealthCheckResult.Healthy("A healthy result.File is accesible to read and write"));
                }
                catch
                {
                    return Task.FromResult(
                        HealthCheckResult.Unhealthy("Unhealthy result: File exists but doesn't have read-write permissions"));
                }
 
            }
            return Task.FromResult(
                HealthCheckResult.Unhealthy("Unhealthy result: File doesn't exist."));


        }
    }
}
