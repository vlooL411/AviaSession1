using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AviaSession1
{
    public partial class AdaptiveLTB : UserControl
    {
        public string head { get; set; }
        public string text { get; set; }
        public AdaptiveLTB()
        {
            InitializeComponent();
            Head.Content = head;
            Text.Text = text;
        }
    }
}
