using ManoPirmasDotNetProjektas.Paskaitos.Colections.Array;
using ManoPirmasDotNetProjektas.Paskaitos.Colections.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Colections
{
    public static class CollectionsExecutor
    {
        public static void Run()
        {
            //Masyvai.MasyvaiTesting();
            //Masyvai.AutobusuUzduotis();
            //Listai.AutobusuUzduotis();
            Listai.AntraAutobusoUzduotis();
        }

        public static void Dictionaries()
        {
            Dictionary<int,string> dictionary = new Dictionary<int,string>();
        }
    }
}
