using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBIT.MicroService.Template.Gateway.Interprete.Basicos.Extensores
{
    public static class StringExtension
    {
        public static string RemovaBarraDupla(this string _string)
        {
            return _string.Replace("//", "/");
        }
        public static string RemovaBarraDuplaInvertida(this string _string)
        {
            return _string.Replace("\\\\", "\\");
        }
    }
}
