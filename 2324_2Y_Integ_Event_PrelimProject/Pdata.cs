using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2324_2Y_Integ_Event_PrelimProject
{
    internal class Pdata
    {
        public string Name;
        public string Score;
        public string Playtime;

        public Pdata()
        {
            Name = "asd";
            Score = "";
            Playtime = "";
        }

        public Pdata(string[] values)
        {
            if (values.Length == 3)
            {
                Name = values[0].Trim();
                Score = values[1].Trim();
                Playtime = values[2].Trim();
            }
        }
    }
}
