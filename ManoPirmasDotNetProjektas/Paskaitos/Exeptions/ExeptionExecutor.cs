using ManoPirmasDotNetProjektas.Paskaitos.Generics;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Exeptions
{
    internal class ExeptionExecutor : ITema
    {
        private readonly ILoggerServise _logger;

        public ExeptionExecutor(ILoggerServise logger)
        {
            _logger = logger;
        }

        public Task Run()
        {
            _logger.LogInfo("running Exeption executor");

            try
            {
                BreakProgram();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return Task.CompletedTask;
        }

        public void BreakProgram()
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
                _logger.LogError(exception.ToString());

                throw;
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception);
                _logger.LogError(exception.ToString());

                throw;
            }
            catch(Exception e) when (e.Message == "Object reference not set to an instance of an object.")
            {
                Console.WriteLine("Pagavau su specifiniu message");
                _logger.LogError(e.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                _logger.LogError(exception.ToString());

                throw;
            }

            BreakProgram2();
        }

        public void BreakProgram2()
        {
            try
            {
                throw new MyCustomExecption("Tiesiog noriu breakint programa.");
            }
            catch (Exception e) 
            {
                _logger.LogError(e.ToString());
            }
        }
    }
}
