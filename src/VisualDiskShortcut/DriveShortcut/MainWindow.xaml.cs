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
using Microsoft.Win32;

namespace DriveShortcut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var guid = Guid.NewGuid().ToString();
            try
            {
                var key = Registry.Users;
                var root = key.OpenSubKey(@"S-1-5-21-1604552579-546483149-179987394-1001\Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\");
                var driveroot = root.CreateSubKey($"{{{guid}}}");
                driveroot.SetValue(string.Empty, "MyDrive");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
