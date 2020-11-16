using System;
using System.IO;
using GameOfLifeApi2.Models;
using System.Text.Json;

namespace GameOfLifeApi2.Resources
{
    public class FileWriter
    {
     
        public static void WriteTimeStamp(Board board)
        {
            string result;
            if (board == null)
            {
                result = "Board is null";
            }
            else
            {
                result = JsonSerializer.Serialize(board);
            }
            string path = @"C:\Users\avaldemoro\Documents\GameOfLifeApi2\history.txt";
            if (!File.Exists(path))
            {

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(DateTime.Today.ToString("g") + " " + result);
                }
            }else{
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(DateTime.Now.ToString("g") + " " + result);
                }
            }

            
        }
    }
}
