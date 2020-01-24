using AviaSession1.BD;
using System.Linq;
using System.Windows;

namespace AviaSession1
{
    public partial class Login : Window
    {
        public Login() => InitializeComponent();

        void Login_Click(object o, RoutedEventArgs e)
        {
            var login = Username.Text;
            var password = Password.Text;
            if (login != "" && password != "")
            {
                var users = QueryBD.amonic.Users.Where(u => u.Email == login && u.Password == password).ToList();
                if (users.Count != 0)
                    if (users[0] != null)
                    {
                        QueryBD.user = users[0];
                        if (QueryBD.user.Role != null)
                            if (QueryBD.user.Role.Title != null)
                            {
                                if (!QueryBD.LoginCtrl())
                                {
                                    MessageBox.Show("Error connect", "Error");
                                    Close();
                                }
                                if (QueryBD.user.Active == 1)
                                    switch (QueryBD.user.Role.Title)
                                    {
                                        case "User":
                                            new AmonicUser().Show();
                                            Close();
                                            break;
                                        case "Administrator":
                                            new AmonicAdmin().Show();
                                            Close();
                                            break;
                                    }
                                else MessageBox.Show("Sorry, you don't activate.", "Warning");
                            }
                    }
            }
        }
        void Exit_Click(object o, RoutedEventArgs e) => Close();
    }
}