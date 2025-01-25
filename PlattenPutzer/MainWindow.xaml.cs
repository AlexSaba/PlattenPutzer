using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlattenPutzer
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

        private void DeleteTempFiles(object sender, RoutedEventArgs e)
        {
            var pathTemp = new DirectoryInfo(@"C:\Windows\Temp").EnumerateFiles();//
            //.Where(f => File.ReadLines(f.FullName).ElementAtOrDefault(0)?.Contains(".lock") == false);

            foreach (FileInfo file in pathTemp)
            {
                file.Delete();
            }
            labelTemp.Content = "Temporäre Dateien gelöscht!";
        }

        public void DeleteSpotifyFiles(object sender, RoutedEventArgs e)
        {
            //var pathSpot = new DirectoryInfo(@"C:\Windows\Temp").EnumerateFiles();
            
            var dername = System.IO.Path.GetRelativePath;

        }
    }
}