using AviaSession1.BD;
using System.Linq;
using System.Windows;

namespace AviaSession1
{
    public partial class Edit_role : Window
    {
        User user;
        public Edit_role(User us)
        {
            user = us;
            InitializeComponent();

            if (user.RoleID == 1) Admin.IsChecked = true;
            else User.IsChecked = true;

            var offl = QueryBD.amonic.Offices.ToList();
            if (offl.Count != 0) OfN.ItemsSource = offl;
            int pos = -1;
            foreach (var of in OfN.Items)
            {
                pos++;
                if ((of as Office).ID == user.ID) break;
            }
            OfN.SelectedIndex = pos;

            DataContext = null;
            DataContext = user;
        }

        void Apply_Click(object o, RoutedEventArgs e)
        {
            if (FN.Text == "" || LN.Text == "" || email.Text == "") return;
            var ul = QueryBD.amonic.Users.Where(u => u.ID == user.ID).ToList();
            if (ul.Count != 0)
            {
                ul[0].FirstName = FN.Text;
                ul[0].LastName = LN.Text;
                ul[0].Email = email.Text;
                ul[0].RoleID = User.IsChecked.Value ? 2 : 1;
                ul[0].OfficeID = (OfN.SelectedItem as Office).ID;
                QueryBD.amonic.SaveChanges();
            }
            Close();
        }

        void Cancel_Click(object o, RoutedEventArgs e) => Close();
    }
}