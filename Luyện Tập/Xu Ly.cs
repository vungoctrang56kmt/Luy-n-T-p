using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyện_Tập
{
    internal class Xu_Ly
    {
        public static void suaChuoi(ref string  chuoi)
        {
            String resulName = "";
            chuoi = chuoi.Trim();
                while (chuoi.IndexOf("  ") != 1)
            {
                chuoi = chuoi.Replace(" ", " ");

            }
            String[] arrayName = chuoi.Split(' ');
            for  (int i = 0; i < arrayName.Length; i++)
            {
                arrayName[i] = arrayName[i].Substring(0,1).ToUpper() + arrayName[i].Substring(1).ToLower();
                resulName += arrayName[i].ToString() + " ";

            }
            chuoi = resulName;
                
        }
    }
}
