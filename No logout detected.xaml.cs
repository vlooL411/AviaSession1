using System;
using System.Windows;

namespace AviaSession1
{
    public partial class No_logout_detected : Window
    {
        public No_logout_detected()
        {
            InitializeComponent();
            if (QueryBD.user != null)
            {
                var now = DateTime.Now;
                MessageLogout.Content += " " + now.Day + "/" + now.Month + "/" + now.Year + " at " + now.Hour + ":" + now.Minute;
                if (QueryBD.CtrlLog != null)
                    QueryBD.CtrlLog.LogoutTime = now;
            }
        }

        void Confirm_Click(object o, RoutedEventArgs e)
        {
            if (QueryBD.CtrlLog != null)
            {
                QueryBD.CtrlLog.UnsuccefulLogout = ReasoneError.Text;
                QueryBD.CtrlLog.Crash = (byte)(Soft.IsChecked.Value == true ? 1 : 0);
                QueryBD.amonic.SaveChanges();
            }
        }
    }
}