using AviaSession1.BD;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;

namespace AviaSession1
{
    public partial class Add_user : Window
    {
        User user = new User();
        public Add_user()
        {
            InitializeComponent();

            var offl = QueryBD.amonic.Offices.ToList();
            if (offl.Count != 0) OfN.ItemsSource = offl;
            if (OfN.Items.Count != 0)
                OfN.SelectedIndex = 0;
        }

        void Save_Click(object o, RoutedEventArgs e)
        {
            if (FN.Text == "" || LN.Text == "" || email.Text == "" || Password.Text == "" || !Birth.SelectedDate.HasValue || OfN.SelectedItem == null) return;
            user.FirstName = FN.Text;
            user.LastName = LN.Text;
            user.Email = email.Text;
            user.Office = OfN.SelectedItem as Office;
            user.Password = Password.Text;
            user.Birthdate = Birth.SelectedDate;
            user.RoleID = 2;
            QueryBD.amonic.Users.Add(user);
            QueryBD.amonic.SaveChanges();
            Close();
        }
        void Close_Click(object o, RoutedEventArgs e) => Close();
    }
}