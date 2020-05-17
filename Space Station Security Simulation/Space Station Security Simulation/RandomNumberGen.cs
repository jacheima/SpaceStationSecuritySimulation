using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Station_Security_Simulation
{


    public class RandomNumberGen
    {
        Form1 form1;
        int numberType;
        

        public int GenerateNumber()
        {
            Random random = new Random();

            int randomNumber = 0;


            randomNumber = random.Next(999999);
            

            return randomNumber;
        }

    }
}
