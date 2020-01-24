using System;
using System.Collections.Generic;
using System.Windows;

namespace AviaSession1
{
    public class UserLog
    {
        public string date { get; set; }
        public string loginTime { get; set; }
        public string logoutTime { get; set; }
        public string logTime { get; set; }
        public string crash { get; set; }
    }

    public partial class AmonicUser : Window
    {
        List<UserLog> userLogs = new List<UserLog>();
        public AmonicUser()
        {
            InitializeComponent();

            if (QueryBD.user.FirstName != null)
                FN.Content = FN.Content.ToString().Insert(0, QueryBD.user.FirstName);
            int countCrach = 0;
            var timeAll = new DateTime(0);
            foreach (var l in QueryBD.user.ControlLogins)
            {
                var userl = new UserLog();
                if (l.LoginTime.HasValue)
                {
                    var loginTime = l.LoginTime.Value;
                    userl.date = loginTime.Month.ToString() + '/' + loginTime.Day.ToString() + '/' + loginTime.Year.ToString();
                    userl.loginTime = loginTime.Hour.ToString() + ':' + loginTime.Minute.ToString();
                    if (l.LogoutTime.HasValue)
                    {
                        var logoutTime = l.LogoutTime.Value;
                        userl.logoutTime = logoutTime.Hour.ToString() + ':' + logoutTime.Minute.ToString();
                        var logT = logoutTime - loginTime;
                        timeAll += logT;
                        userl.logTime = logT.Hours.ToString() + ':' + logT.Minutes.ToString();
                    }
                    else countCrach++;
                }
                else countCrach++;

                if (l.UnsuccefulLogout != null)
                    userl.crash = l.UnsuccefulLogout;

                userLogs.Add(userl);
            }
            DGUserLogs.ItemsSource = userLogs;

            TimeSpent.Content = timeAll.Hour.ToString() + ':' + timeAll.Minute.ToString();
            CountCrash.Content = countCrach;
        }

        void Window_Closed(object o, EventArgs e) => QueryBD.LogoutCtrl();
    }
}