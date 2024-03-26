namespace UMBIT.MicroService.Template.Gateway.Interprete.Model
{
    public class ServiceSettings
    {
        public List<ServiceSetting> Services { get; set; }
    }

    public class ServiceSetting
    {
        public string ServiceName { get; set; }
        public string Apelido { get; set; }
        public int Port { get; set; }
    }
}
