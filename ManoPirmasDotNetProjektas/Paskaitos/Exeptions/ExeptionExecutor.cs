using ManoPirmasDotNetProjektas.Paskaitos.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Exeptions
{
    internal static class ExeptionExecutor
    {
        public static void Run()
        {
            try
            {
                BreakProgram();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine(ex);
            }
        }

        public static void BreakProgram()
        {
            try
            {
                var employee = new Darbuotojas("Jonas", 10, 10);

                Console.WriteLine(employee.Name);

                employee = null;

                //if (employee is null)
                //{
                //    Console.WriteLine("darbuotojas nerastas");
                //}
                //else
                //{
                    Console.WriteLine(employee.Name);
                //}
            }           
            catch (ArgumentNullException exception) when (exception.Message == "operation")
            {
                Console.WriteLine(exception);

                throw;
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception);

                throw;
            }
            catch(Exception e) when (e.Message == "Object reference not set to an instance of an object.")
            {
                Console.WriteLine("Pagavau su specifiniu message");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                throw;
            }


            BreakProgram2();
        }

        public static void BreakProgram2()
        {
            try
            {
                throw new MyCustomExecption("Tiesiog noriu breakint programa.");
            }
            catch (Exception e) 
            {
                
            }
        }
    }
}
