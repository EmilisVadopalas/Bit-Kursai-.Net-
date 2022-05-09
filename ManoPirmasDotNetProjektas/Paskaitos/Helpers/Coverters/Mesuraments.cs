using ManoPirmasDotNetProjektas.Paskaitos.OPP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Helpers.Coverters
{
    public static class Mesuraments
    {
        public static double ConvertMeasurements(int mesurament, LenghtMesuraments from, LenghtMesuraments to)
        {
            return (mesurament * (int)from) / (int)to;
        }
    }
}
