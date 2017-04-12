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
using System.Windows.Shapes;

namespace Mattt_Meredith_tuner
{
    /// <summary>
    /// Interaction logic for Opener.xaml
    /// </summary>
    public partial class Opener : Window
    {
        public Opener()
        {
            InitializeComponent();
    }

        private void WindowSelect_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (WindowSelect.SelectedIndex == 1)
            {
                MMMMM.version2 v = new MMMMM.version2();
                v.Show();
                this.Close();
            }
        }

    }
}
