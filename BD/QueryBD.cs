using AviaSession1.BD;
using System;
using System.Windows;

namespace AviaSession1
{
    class QueryBD
    {
        static public amonic amonic = new amonic();
        static public User user;
        static public ControlLogin CtrlLog;
        static public bool LoginCtrl()
        {
            try
            {
                user.ControlLogins.Add(CtrlLog = new ControlLogin() { LoginTime = DateTime.Now });
                amonic.SaveChanges();
            }
            catch { ErrorWindow(); return false; }
            return true;
        }
        static public bool LogoutCtrl()
        {
            try
            {
                CtrlLog.LogoutTime = DateTime.Now;
                amonic.SaveChanges();
            }
            catch { ErrorWindow(); return false; }
            return true;
        }
        static public void ErrorWindow()
        {
            try { new No_logout_detected(); }
            catch { MessageBox.Show("Error connect.", "Error"); }
        }
    }
}