using HouseControl.Library;
using HouseControl.Sunset;
using Ninject;

namespace HouseControlAgent;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Initializing Controller");

        var controller = InitializeHouseController();

        await Task.Delay(1); // placeholder to keep Main signature when test code is not used

        // For hardware/scheduling testing purposes
        // Uncomment this section to ensure that the hardware
        // and scheduling is working as expected.
        await controller.SendCommand(5, DeviceCommand.On);
        await controller.SendCommand(5, DeviceCommand.Off);

        var currentTime = DateTime.Now;
        controller.ScheduleOneTimeItem(currentTime.AddMinutes(1), 3, DeviceCommand.On);
        controller.ScheduleOneTimeItem(currentTime.AddMinutes(2), 5, DeviceCommand.On);
        controller.ScheduleOneTimeItem(currentTime.AddMinutes(3), 3, DeviceCommand.Off);
        controller.ScheduleOneTimeItem(currentTime.AddMinutes(4), 5, DeviceCommand.Off);

        Console.WriteLine("Initialization Complete");

        string command = "";
        while (command != "q")
        {
            command = Console.ReadLine() ?? "";
            if (command == "s")
            {
                var schedule = controller.GetCurrentScheduleItems();
                foreach (var item in schedule)
                {
                    Console.WriteLine($"{item.Info.EventTime:G} - {item.Info.TimeType} ({item.Info.RelativeOffset}), Device: {item.Device}, Command: {item.Command}");
                }
            }
            if (command == "r")
            {
                controller.ReloadSchedule();
            }
        }
    }

    private static HouseController InitializeHouseController()
    {
        IKernel container = new StandardKernel();

        //45.6382,-122.7013 = Vancouver, WA, USA
        //51.4768,-0.0030 = Royal Observatory, Greenwich
        //51.520,-0.0963 = Barbican Centre

        ScheduleFileName fileName = new(AppDomain.CurrentDomain.BaseDirectory + "ScheduleData");
        container.Bind<ScheduleFileName>().ToConstant(fileName);

        var latLong = new LatLongLocation(51.520, -0.0963);
        container.Bind<LatLongLocation>().ToConstant(latLong);
        container.Bind<ISunsetProvider>().To<CachingSunsetProvider>()
            .WithConstructorArgument<ISunsetProvider>(
                container.Get<SolarTimesSunsetProvider>());

#if DEBUG
        container.Bind<HouseController>().ToSelf()
            .WithPropertyValue("Commander", container.Get<FakeCommander>());
#endif
        var controller = container.Get<HouseController>();

        var sunset = container.Get<ISunsetProvider>()
            .GetSunset(DateTime.Today.AddDays(1));
        Console.WriteLine($"Sunset Tomorrow: {sunset:G}");

        return controller;
    }
}
