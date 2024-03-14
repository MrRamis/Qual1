using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp1.Check
{
   public static class ChackTable1
    {
        public static bool ChackName(string chack)
        {
            if(chack == null || chack.Replace(" ", string.Empty) == "") return false;
            return true;
        }

        public static bool ChackCount(string chack)
        {
            return int.TryParse(chack, out _); 
            
        }
        public static bool ChackDiscount(string chack)
        {
            return double.TryParse(chack, out _);
         
        }

    }
}
