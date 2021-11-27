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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using System.Drawing.Drawing2D;

namespace QuickAccess
{

    /// <summary>
    /// Interaction logic for QuickAcessHome.xaml
    /// </summary>
    public partial class QuickAcessHome : Page //server=localhost;userid=root;persistsecurityinfo=True;database=quickaccess
    {
        private Dictionary<String, Link> Link;


        public QuickAcessHome()
        {
            InitializeComponent();
            //  this.Link = LoadXml(XDocument.Load("C:\\Users\\Fransua\\source\\repos\\QuickAccess\\PathData.xml"));
            pathListBox.DataContext = this;
        }


        private Dictionary<String, Link> LoadXml(XDocument doc)
        {
            return (from elem in doc.Root.Descendants("Module")
                    select new Link()
                    {
                        Name = elem.Element("Name").Value,
                        Path = elem.Element("Path").Value,

                    }).ToDictionary(k => k.Name, v => v);
        }



        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            //ListBoxItem itm = new ListBoxItem();
            // itm.Content = textBox1.Text;

            //  pathListBox.Items.Add(itm);
            MessageBox.Show("This Feature would be implemented later: please add path using the PathData.xml");

        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {

            if ((pathListBox.SelectedValue != null))
            {
                string item = pathListBox.SelectedValue.ToString();

                if (item.EndsWith(".exe") || item.Contains("."))
                {
                    openNewApplication(item);
                }
                else
                {
                    startExplorer(item);
                }
            }
        }

        private void Button_Click_List_box(object sender, RoutedEventArgs e)
        {

            if ((pathListBox.SelectedValue != null))
            {
                string item = pathListBox.SelectedValue.ToString();
                if (item.Equals("Shutdown Computer"))
                {
                    Process.Start("shutdown", "/s /t 0");

                }
                else if (item.Equals("Restart Computer"))
                {
                    Process.Start("shutdown", "/r /t 0"); // the argument /r is to restart the computer
                }
                else
                {

                    if (item.EndsWith(".exe") || item.Contains("."))
                    {
                        openNewApplication(item);
                    }
                    else
                    {
                        startExplorer(item);
                    }
                }
            }
        }

        // private void btnOpenFile_ClickAchion(Environment.SpecialFolder initialLocation)
        //  {
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.InitialDirectory = Environment.GetFolderPath(initialLocation);
        //    if (openFileDialog.ShowDialog() == true)
        //     txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        //  }



        private void startExplorer(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                MessageBox.Show(string.Format("{0} Directory name canno be empty  or is null", path));
                return;
            }
            if (path.Contains("/") && !path.Contains("//"))
            {
                path.Replace("//", "//");
            }
            Console.WriteLine("Openning" + path);
            try
            {
                if (Directory.Exists(path))
                {
                    ProcessStartInfo StartInformation = new ProcessStartInfo();

                    StartInformation.FileName = path;

                    Process process = Process.Start(StartInformation);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);

                MessageBox.Show(string.Format("{0} Directory does not exist!", path));

                throw;
            }
            //  WindowState = WindowState.Minimized;


        }
        private void openNewApplication(String name)
        {
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show(string.Format("{0} program name canno be empty  or is null", name));
                return;
            }
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = name;
                //  notePad.StartInfo.Arguments = "ProcessStart.cs"; // if you need some
                process.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);

                MessageBox.Show(string.Format("{0} Application  does not exist!", name));

                //throw;
            }
            //  WindowState = WindowState.Minimized;
        }
        private void btnOpenFile_Click_OpenApplication(object sender, RoutedEventArgs e)
        {
            openNewApplication("notepad++.exe");


        }

        private void btnOpenFile_Click_OpenApplication2(object sender, RoutedEventArgs e)
        {
            openNewApplication("chrome.exe");


        }
        private void btnOpenFile_Click_Documents(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            startExplorer(path);
        }

        private void btnOpenFile_Click_Desktop(object sender, RoutedEventArgs e)
        {


            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            startExplorer(path);
        }


        private void btnOpenFile_Click_UserFransua(object sender, RoutedEventArgs e)
        {

            startExplorer(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
        }
        private void btnOpenFile_Click_ChromeDownload(object sender, RoutedEventArgs e)
        {

            startExplorer("D:\\Downloads\\ChormeDownload\\");

        }

        private void btnOpenFile_Click_DDrive(object sender, RoutedEventArgs e)
        {


            startExplorer("D:\\");

        }
        private void btnOpenFile_Click_CDrive(object sender, RoutedEventArgs e)

        {
            startExplorer("C:\\");
        }



    }


}
