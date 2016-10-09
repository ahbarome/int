using Topshelf;

namespace INT.Service.Host
{
    public class Bootstrap
    {
        static void Main(string[] args)
        {
            HostFactory.Run(service =>
                {
                    service.Service<Controller>(serviceController =>
                    {
                        serviceController.ConstructUsing(name => new Controller());
                        serviceController.WhenStarted(controller => controller.Start());
                        serviceController.WhenStopped(controller => controller.Stop());
                    });
                    service.SetDescription("Servicio para la administración dispositivos biométricos");
                    service.SetDisplayName("INT.Service.Host");
                    service.SetServiceName("INT.Service.Host");
                });
        }
    }
}
