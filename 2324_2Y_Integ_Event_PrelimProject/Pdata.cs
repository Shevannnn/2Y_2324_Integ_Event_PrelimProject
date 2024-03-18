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
        public int Score;
        public int Playtime;

        public Pdata()
        {
            Name = "";
            Score = 0;
            Playtime = 0;
        }

        public Pdata(string[] values)
        {
            if (values.Length == 3)
            {
                Name = values[0].Trim();
                Score = int.Parse(values[1].Trim());
                Playtime = int.Parse(values[2].Trim());
            }
        }
    }
}
