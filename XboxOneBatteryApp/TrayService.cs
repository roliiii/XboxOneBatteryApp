using System;
using System.Windows.Forms;
using System.Windows.Threading;

namespace XboxOneBatteryApp
{
    class TrayService
    {
        private NotifyIcon nIcon;
        private DispatcherTimer dispatcherTimer;
        private IIconProvider controllerService;
        
        public TrayService(IIconProvider controllerService)
        {
            this.controllerService = controllerService;
            initTrayIcon();
            initTimer();
        }
        
        private void initTimer()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += updateTray;
            dispatcherTimer.Interval = new TimeSpan(0, 5, 0);
            dispatcherTimer.Start();
        }

        private void initTrayIcon()
        {
            System.Windows.Forms.ContextMenu nIconMenu = new System.Windows.Forms.ContextMenu();
            nIcon = new NotifyIcon();
            nIconMenu.MenuItems.Add("Refresh", onClick: updateTray);
            nIconMenu.MenuItems.Add("Exit", exitApplication);

            nIcon.Icon = controllerService.getIcon();
            nIcon.ContextMenu = nIconMenu;
            nIcon.Visible = true;
        }

        private void exitApplication(object sender, EventArgs e)
        {
            nIcon.Visible = false;
            nIcon.Dispose();
            dispatcherTimer.Stop();

            System.Windows.Application.Current.Shutdown();
        }

        private void updateTray()
        {
            updateTray(null, null);
        }

        private void updateTray(object sender, EventArgs e)
        {
            nIcon.Icon = controllerService.getIcon();
        }
    }
}
