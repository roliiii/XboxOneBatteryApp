using SharpDX.XInput;

namespace XboxOneBatteryApp
{
    class ControllerService : IIconProvider
    {
        private Controller controller;

        public ControllerService(Controller controller)
        {
            this.controller = controller;
        }

        private BatteryInformation getBatteryInfo()
        {
            return controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
        }

        public System.Drawing.Icon getIcon()
        {
            if (!controller.IsConnected)
                return XboxOneBatteryApp.Resource.notConnected;

            if (getBatteryInfo().BatteryType == BatteryType.Wired || getBatteryInfo().BatteryType == BatteryType.Disconnected)
                return XboxOneBatteryApp.Resource.wired;
                    
            return getBatteryLevelIcon(getBatteryInfo());
        }

        private System.Drawing.Icon getBatteryLevelIcon(BatteryInformation batteryInfo)
        {
            switch (batteryInfo.BatteryLevel)
            {
                case BatteryLevel.Empty:
                    return XboxOneBatteryApp.Resource.empty;
                case BatteryLevel.Low:
                    return XboxOneBatteryApp.Resource.low;
                case BatteryLevel.Medium:
                    return XboxOneBatteryApp.Resource.medium;
                case BatteryLevel.Full:
                    return XboxOneBatteryApp.Resource.full;
                default:
                    break;
            }

            return null;
        }
    }
}