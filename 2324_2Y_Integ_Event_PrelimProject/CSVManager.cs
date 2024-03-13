using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2324_2Y_Integ_Event_PrelimProject
{
    internal class CSVManager
    {
        public List<Pdata> GetPdata(string FileName)
        {
            List<Pdata> temp = new List<Pdata>();

            if (File.Exists(FileName))
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split(',');

                        Pdata data = new Pdata(values);
                        temp.Add(data);
                    }
                }
            }
            else
            {
                CreateCSV();
            }
            return temp;
        }

        public void CreateCSV()
        {
            using (StreamWriter sw = new StreamWriter("Easy_Lboard.csv")) { }
            using (StreamWriter sw = new StreamWriter("Med_Lboard.csv")) { }
            using (StreamWriter sw = new StreamWriter("Hard_Lboard.csv")) { }


        }
    }
}
