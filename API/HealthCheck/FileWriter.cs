using System;
using System.IO;
using GameOfLife.Models;

namespace GameOfLifeApi2.Resources
{
    public static class FileWriter
    {
     
        public static void WriteBoardLog(Board board)
        {
            string result;
            if (board == null)
            {
                result = "Board is null";
            }
            else
            {
                result =board.ToString();
            }
            string path = @"C:\Users\avaldemoro\Documents\GameOfLifeApi2\boardLog.txt";
            if (!File.Exists(path))
            {

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(DateTime.Now.ToString("g") + " " + result);
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
