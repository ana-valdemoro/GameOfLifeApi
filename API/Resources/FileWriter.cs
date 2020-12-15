using System;
using System.IO;
using GameOfLife.Models;
using Microsoft.Extensions.Configuration;

namespace GameOfLifeApi2.Resources {
    public  class FileWriter {
        public IConfiguration Configuration { get; }
        public FileWriter(IConfiguration configuration) {
            Configuration = configuration;
        }
        public void WriteBoardLog(Board board) {
            string result = board == null ? "Board is null" : board.ToString();
            string path = @Configuration["HealthCheck:FilePath"];
            if (!File.Exists(path)) {
                using (StreamWriter sw = new StreamWriter(path)) {
                    sw.WriteLine(DateTime.Now.ToString("g") + " " + result);
                }
            }else{
                using (StreamWriter sw = File.AppendText(path)) {
                    sw.WriteLine(DateTime.Now.ToString("g") + " " + result);
                }   
            }
        }
    }
}
