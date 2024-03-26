using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBIT.MicroService.Template.Gateway.Interprete.Basicos.Utilitarios
{
    public static class DiretorioDeConfiguracao
    {
        const string UMBIT_CONFIG_PATH_ENVIRONMENT_VARIABLE = "NET8_API";

        public static string ObtenhaDiretorioPadrao()
        {
            var UMBIT_config_path = Environment.GetEnvironmentVariable(UMBIT_CONFIG_PATH_ENVIRONMENT_VARIABLE);

            if (string.IsNullOrEmpty(UMBIT_config_path))
            {
                Environment.SetEnvironmentVariable(UMBIT_CONFIG_PATH_ENVIRONMENT_VARIABLE, @"C:\Program Files (x86)\UMBIT");
            }

            return Environment.GetEnvironmentVariable(UMBIT_CONFIG_PATH_ENVIRONMENT_VARIABLE);
        }
    }
}
