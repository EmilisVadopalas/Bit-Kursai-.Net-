using ManoPirmasDotNetProjektas.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Apibendrinimas
{
    internal class Student
    {
        public int[] Grades { get; private set; }


        public Student() { }

        public Student(int[] grades)
        {
            Grades = grades;
        }

        public double CalculateGradeAvg()
        {
            return Grades.Vidurkis(); //custom from previous tasks
            //return Grades.Average(); built in
        }
    }
}
