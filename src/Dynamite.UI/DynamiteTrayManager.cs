using System;
using System.Windows.Forms;
using Dynamite.UI.Properties;

namespace Dynamite.UI
{
    public class DynamiteTrayManager : ApplicationContext
    {
        readonly DynamiteStatusForm _dynamiteStatusForm = new DynamiteStatusForm();
        readonly NotifyIcon _notifyIcon;

        public DynamiteTrayManager()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new[]
                {
                    new MenuItem("Show Status", ShowStatusWindow),
                    new MenuItem("Exit", Exit)
                }),
                Visible = true
            };

            _notifyIcon.Click += NotifyIconClick;
        }

        void NotifyIconClick(object sender, EventArgs e)
        {
            ShowStatusWindow(sender, e);
        }

        void ShowStatusWindow(object sender, EventArgs e)
        {
            if (_dynamiteStatusForm.Visible)
            {
                _dynamiteStatusForm.Activate();
            }
            else
            {
                _dynamiteStatusForm.ShowDialog();
            }
        }

        void Exit(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;

            Application.Exit();
        }
    }
}