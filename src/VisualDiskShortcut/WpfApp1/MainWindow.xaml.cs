using Microsoft.Win32;
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

namespace WpfApp1
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
        public void RegistryApp()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}");
            key.SetValue("", "TuanhStorage123", RegistryValueKind.String);
            key.SetValue("System.IsPinnedToNameSpaceTree", 0x1, RegistryValueKind.DWord);
            key.SetValue("SortOrderIndex", 0x42, RegistryValueKind.DWord);

            RegistryKey defaulticon = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\DefaultIcon ");
            defaulticon.SetValue("", @"%C:\Windows%/system32/imageres.dll,-104", RegistryValueKind.ExpandString);

            RegistryKey inProcServer32 = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\InProcServer32");
            inProcServer32.SetValue("", @"%C:\Windows%\system32\shell32.dll", RegistryValueKind.ExpandString);

            RegistryKey instance = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\Instance");
            instance.SetValue("CLSID", "d05671ab-5883-4ae5-ba5d-3d491d9c1465", RegistryValueKind.String);

            RegistryKey initPropertyBag = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\Instance\InitPropertyBag");
            initPropertyBag.SetValue("Attributes", 0x11, RegistryValueKind.DWord);
            initPropertyBag.SetValue("TargetFolderPath ", @"%C:\Users\spd09%\MyCloudStorageApp", RegistryValueKind.ExpandString);

            RegistryKey shellFolder = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\ShellFolder");
            shellFolder.SetValue("FolderValueFlags", 0x28, RegistryValueKind.DWord);
            //Step 10
            //shellFolder.SetValue("Attributes", 0xF080004D, RegistryValueKind.DWord);

            RegistryKey nameSpace = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{ebce018c-ab57-48a3-8ecb-b95827530ad8}");
            nameSpace.SetValue("", "TuanhStorage123", RegistryValueKind.String);
        }
        /// <summary>
        /// 添加注册表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var guid = "34890980-4ce3-4e15-8c3e-e656802de88d";
            //var df= Guid.NewGuid().ToString();
            try
            {

                //计算机\HKEY_CLASSES_ROOT\CLSID\{18701C81-34AB-498E-8C7F-5D26B9C36732}
                {
                    var key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64);
                    var root = key.OpenSubKey(@"CLSID\", true);


                    var driveroot = root.CreateSubKey($"{{{guid}}}");
                    driveroot.SetValue(string.Empty, "MyDrive");
                    driveroot.SetValue("SortOrderIndex", 0x00000042, RegistryValueKind.DWord);
                    driveroot.SetValue("System.IsPinnedToNameSpaceTree", 0x00000000, RegistryValueKind.DWord);

                    var keyDefaultIcon = driveroot.CreateSubKey("DefaultIcon", true);
                    keyDefaultIcon.SetValue(string.Empty, @"C:\Users\13414\Pictures\drive.ico", RegistryValueKind.ExpandString);//图标路径
                    keyDefaultIcon.Close();

                    var keyInProcServer32 = driveroot.CreateSubKey("InProcServer32", true);
                    keyInProcServer32.SetValue(string.Empty, @"%SystemRoot%\system32\shell32.dll", RegistryValueKind.ExpandString);
                    keyInProcServer32.SetValue("ThreadingModel", "Apartment");
                    keyInProcServer32.Close();

                    var keyInstance = driveroot.CreateSubKey("Instance", true);
                    keyInstance.SetValue(string.Empty, string.Empty);
                    keyInstance.SetValue("CLSID", "{0AFACED1-E828-11D1-9187-B532F1E9575D}");
                    {
                        var varInitPropertyBag = keyInstance.CreateSubKey("InitPropertyBag", true);
                        //varInitPropertyBag.SetValue(string.Empty, null);
                        varInitPropertyBag.SetValue("Attributes", 0x00000011, RegistryValueKind.DWord);
                        varInitPropertyBag.SetValue("Target", @"C:\Users\13414\Documents\BaiduNetdiskWorkspace");
                        varInitPropertyBag.Close();
                    }
                    keyInstance.Close();

                    var varShellFolder = driveroot.CreateSubKey("ShellFolder", true);
                    //varShellFolder.SetValue(string.Empty, null);
                    varShellFolder.SetValue("Attributes", 0xf080004d, RegistryValueKind.QWord);
                    varShellFolder.SetValue("FolderValueFlags", 0x00000028, RegistryValueKind.DWord);
                    varShellFolder.Close();
                    driveroot.Close();
                }
                //计算机\HKEY_CURRENT_USER\Software\Classes\CLSID\
                {
                    var key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                    var root = key.OpenSubKey(@"Software\Classes\CLSID\", true);


                    var driveroot = root.CreateSubKey($"{{{guid}}}");
                    driveroot.SetValue(string.Empty, "MyDrive");
                    driveroot.SetValue("SortOrderIndex", 0x00000042, RegistryValueKind.DWord);
                    driveroot.SetValue("System.IsPinnedToNameSpaceTree", 0x00000000, RegistryValueKind.DWord);

                    var keyDefaultIcon = driveroot.CreateSubKey("DefaultIcon", true);
                    keyDefaultIcon.SetValue(string.Empty, @"C:\Users\13414\Pictures\drive.ico", RegistryValueKind.ExpandString);//图标路径
                    keyDefaultIcon.Close();

                    var keyInProcServer32 = driveroot.CreateSubKey("InProcServer32", true);
                    keyInProcServer32.SetValue(string.Empty, @"%SystemRoot%\system32\shell32.dll", RegistryValueKind.ExpandString);
                    keyInProcServer32.SetValue("ThreadingModel", "Apartment");
                    keyInProcServer32.Close();

                    var keyInstance = driveroot.CreateSubKey("Instance", true);
                    keyInstance.SetValue(string.Empty, string.Empty);
                    keyInstance.SetValue("CLSID", "{0AFACED1-E828-11D1-9187-B532F1E9575D}");
                    {
                        var varInitPropertyBag = keyInstance.CreateSubKey("InitPropertyBag", true);
                        //varInitPropertyBag.SetValue(string.Empty, null);
                        varInitPropertyBag.SetValue("Attributes", 0x00000011, RegistryValueKind.DWord);
                        varInitPropertyBag.SetValue("Target", @"C:\Users\13414\Documents\BaiduNetdiskWorkspace");
                        varInitPropertyBag.Close();
                    }
                    keyInstance.Close();

                    var varShellFolder = driveroot.CreateSubKey("ShellFolder", true);
                    //varShellFolder.SetValue(string.Empty, null);
                    varShellFolder.SetValue("Attributes", 0xf080004d, RegistryValueKind.QWord);
                    varShellFolder.SetValue("FolderValueFlags", 0x00000028, RegistryValueKind.DWord);
                    varShellFolder.Close();
                    driveroot.Close();
                }

                //计算机\HKEY_USERS\S-1-5-21-1604552579-546483149-179987394-1001\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\
                {
                    var key = Registry.Users;
                    var root = key.OpenSubKey(@"S-1-5-21-1604552579-546483149-179987394-1001\Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\", true);
                    var driveroot = root.CreateSubKey($"{{{guid}}}");
                    driveroot.SetValue(string.Empty, "MyDrive");
                    driveroot.Close();
                    root.Close();
                }

                //计算机\HKEY_USERS\S-1-5-21-1604552579-546483149-179987394-1001\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel
                {
                    var key = Registry.Users;
                    var root = key.OpenSubKey(@"S-1-5-21-1604552579-546483149-179987394-1001\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel\", true);
                    root.SetValue($"{{{guid}}}", 0x00000001, RegistryValueKind.DWord);
                    root.Close();
                    root.Close();
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// 移除注册表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            var guid = "{34890980-4ce3-4e15-8c3e-e656802de88d}";
            //计算机\HKEY_CLASSES_ROOT\CLSID\{18701C81-34AB-498E-8C7F-5D26B9C36732}
            {
                var key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64);
                var root = key.OpenSubKey(@"CLSID\", true);

                root.DeleteSubKeyTree(guid);
                root.Close();
            }
            //计算机\HKEY_CURRENT_USER\Software\Classes\CLSID\  与计算机\HKEY_CLASSES_ROOT\CLSID\{18701C81-34AB-498E-8C7F-5D26B9C36732} 关联删除
            //{
            //    var key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            //    var root = key.OpenSubKey(@"Software\Classes\CLSID\", true);

            //    root.DeleteSubKeyTree("{94f6a013-532f-4bfb-9693-30973db7efad}");
            //    root.Close();
            //}

            //计算机\HKEY_USERS\S-1-5-21-1604552579-546483149-179987394-1001\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\
            {
                var key = Registry.Users;
                var root = key.OpenSubKey(@"S-1-5-21-1604552579-546483149-179987394-1001\Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\", true);
                root.DeleteSubKeyTree(guid);
                root.Close();
            }

            //计算机\HKEY_USERS\S-1-5-21-1604552579-546483149-179987394-1001\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel
            {
                var key = Registry.Users;
                var root = key.OpenSubKey(@"S-1-5-21-1604552579-546483149-179987394-1001\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel\", true);
                root.DeleteValue(guid);
                root.Close();
            }

        }
    }
}
