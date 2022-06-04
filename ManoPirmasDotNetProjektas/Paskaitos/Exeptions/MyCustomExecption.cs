using System;

namespace ManoPirmasDotNetProjektas.Paskaitos.Exeptions
{
    public class MyCustomExecption : Exception
    {
        public string PapildomaManoCustomInfo { get; init; }

        public MyCustomExecption(string errorMessage) : base(errorMessage)
        {
            PapildomaManoCustomInfo = "My errror";
        }

        public override string ToString()
        {
            return $"MANO ERROR\nMANO ERORR\nERRO'\n{base.ToString()}";
        }
    }
}
