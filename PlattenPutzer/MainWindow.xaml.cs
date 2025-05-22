using System;
using System.IO;
using System.IO.Packaging;
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
using static System.Environment;

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
            var pathTemp = new DirectoryInfo(@"C:\Windows\Temp").EnumerateFiles();

            foreach (FileInfo file in pathTemp)
            {
                file.Delete();
            }
            labelTemp.Content = "Temporäre Dateien gelöscht!";
        }

        public void DeleteSpotifyFiles(object sender, RoutedEventArgs e)
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string spotifyPath = System.IO.Path.Combine(localAppData, "Packages", "SpotifyAB.SpotifyMusic_zpdnekdrzrea0", "LocalCache", "Spotify", "Data");

            if (Directory.Exists(spotifyPath))
            {
                foreach (string dir in Directory.GetDirectories(spotifyPath)) // Alle Unterordner durchgehen
                {
                    try
                    {
                        // Alle Dateien im Unterordner löschen
                        foreach (string file in Directory.GetFiles(dir))
                        {
                            File.Delete(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fehler beim Löschen des Inhalts von {dir}: {ex.Message}");
                    }
                }
                labelSpot.Content = "Spotify-Müll entfernt!";
            }
            else
            {
                Console.WriteLine("Der Spotify-Ordner existiert nicht.");
            }
        }

        private void DeleteMiniaturansichten(object sender, RoutedEventArgs e)
        {
            string LocalAppDataPath = "%LOCALAPPDATA%\\Microsoft\\Windows\\Explorer";

            if (Directory.Exists(LocalAppDataPath))
            {
                foreach (string dir in Directory.GetDirectories(LocalAppDataPath)) // Alle Unterordner durchgehen
                {
                    try
                    {
                        // Alle Dateien im Unterordner löschen
                        foreach (string file in Directory.GetFiles(dir))
                        {
                            File.Delete(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fehler beim Löschen des Inhalts von {dir}: {ex.Message}");
                    }
                }
                labelMiniatur.Content = "Miniatur-Ansichten gelöscht!";
            }
            else
            {
                labelMiniatur.Content = "Keine Miniatur-Ansichten vorhanden.";
            }
        }

        private void DeleteLocalTemp(object sender, RoutedEventArgs e)
        {
            string tempPath = Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%\\Temp");

            try
            {
                // Dateien direkt im Temp-Verzeichnis löschen
                foreach (string file in Directory.GetFiles(tempPath))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fehler beim Löschen der Datei {file}: {ex.Message}");
                    }
                }

                // Unterordner mit Inhalt rekursiv löschen
                foreach (string dir in Directory.GetDirectories(tempPath))
                {
                    try
                    {
                        Directory.Delete(dir, true); // true = rekursiv löschen
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fehler beim Löschen des Ordners {dir}: {ex.Message}");
                    }
                }

                labelLocalTemp.Content = "Lokale Temp-Dateien und Ordner gelöscht!";
            }
            catch (Exception ex)
            {
                labelLocalTemp.Content = "Fehler beim Löschen.";
                Console.WriteLine($"Gesamtfehler: {ex.Message}");
            }
        }

        private void DeleteMemoryDumps(object sender, RoutedEventArgs e)
        {
            string tempPath = Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%\\CrashDumps");

                foreach (string file in Directory.GetFiles(tempPath))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fehler beim Löschen der Datei {file}: {ex.Message}");
                    }
                }
            labelMemoryDumps.Content = "Memory Dumps gelöscht!";
        }
    }
}