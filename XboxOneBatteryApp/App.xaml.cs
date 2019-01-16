using SharpDX.XInput;
using System;

namespace XboxOneBatteryApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : System.Windows.Application
    { 
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();

            var trayService = new TrayService(new ControllerService(new Controller(UserIndex.One)));
            
            app.Run();
        }
    }
}
