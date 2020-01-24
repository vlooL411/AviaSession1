using AviaSession1.BD;
using System;
using System.Linq;
using System.Windows;

namespace AviaSession1
{
    public partial class AmonicAdmin : Window
    {
        public AmonicAdmin()
        {
            InitializeComponent();
            Update();
            var offl = QueryBD.amonic.Offices.ToList();
            offl.Add(new Office() { Title = "All offices" });
            if (offl.Count != 0)
                OfficeBox.ItemsSource = offl;
            OfficeBox.SelectedIndex = OfficeBox.Items.Count - 1;
        }

        void Update()
        {
            DGUsers.ItemsSource = null;
            var usersl = QueryBD.amonic.Users.ToList();
            if (usersl.Count != 0)
                DGUsers.ItemsSource = usersl;
        }

        void ChangeRole_Click(object o, RoutedEventArgs e)
        {
            var us = DGUsers.SelectedItem as User;
            if (us != null) new Edit_role(us).Show();
        }
        void AddUser_Click(object o, RoutedEventArgs e) => new Add_user().Show();

        void EDLogin_Click(object o, RoutedEventArgs e)
        {
            var us = (DGUsers.SelectedItem as User);
            if (us == null) return;
            us.Active = Convert.ToByte(!Convert.ToBoolean(us.Active));
            QueryBD.amonic.SaveChanges();
            Update();
        }

        void OfficeBox_Selected(object o, RoutedEventArgs e)
        {
            var s = (OfficeBox.SelectedItem as Office).Title;
            var usersl = QueryBD.amonic.Users.ToList();
            if (s != "All offices")
                usersl = usersl.Where(u => u.Office.Title == s).ToList();
            DGUsers.ItemsSource = null;
            if (usersl.Count != 0)
                DGUsers.ItemsSource = usersl;
        }

        void Close_Click(object o, RoutedEventArgs e) => Close();
    }
}