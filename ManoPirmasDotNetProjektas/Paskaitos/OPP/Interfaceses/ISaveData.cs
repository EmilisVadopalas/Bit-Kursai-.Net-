using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Interfaceses
{
    public interface ISaveData
    {
        public void Save();
        public void Delete();
    }

    public class Ps2SaveData : ISaveData
    {
        public void Save()
        {
            Console.WriteLine("Ps2 Data saved");
        }

        void ISaveData.Delete()
        {
            Console.WriteLine("Ps2 Data saved");
        }
    }

}
