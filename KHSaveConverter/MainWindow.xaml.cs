using KHSaveConverter.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

namespace KHSaveConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KHSaveType SaveType;

        List<string> SaveItems = new List<string>() {
        "Replace All",
        "Slot 1",
        "Slot 2",
        "Slot 3",
        "Slot 4",
        "Slot 5",
        "Slot 6",
        "Slot 7",
        "Slot 8",
        "Slot 9",
        "Slot 10",

        "Slot 11",
        "Slot 12",
        "Slot 13",
        "Slot 14",
        "Slot 15",
        "Slot 16",
        "Slot 17",
        "Slot 18",
        "Slot 19",
        "Slot 20",

        "Slot 21",
        "Slot 22",
        "Slot 23",
        "Slot 24",
        "Slot 25",
        "Slot 26",
        "Slot 27",
        "Slot 28",
        "Slot 29",
        "Slot 30",

        "Slot 31",
        "Slot 32",
        "Slot 33",
        "Slot 34",
        "Slot 35",
        "Slot 36",
        "Slot 37",
        "Slot 38",
        "Slot 39",
        "Slot 40",

        "Slot 41",
        "Slot 42",
        "Slot 43",
        "Slot 44",
        "Slot 45",
        "Slot 46",
        "Slot 47",
        "Slot 48",
        "Slot 49",
        "Slot 50",

        "Slot 51",
        "Slot 52",
        "Slot 53",
        "Slot 54",
        "Slot 55",
        "Slot 56",
        "Slot 57",
        "Slot 58",
        "Slot 59",
        "Slot 60",

        "Slot 61",
        "Slot 62",
        "Slot 63",
        "Slot 64",
        "Slot 65",
        "Slot 66",
        "Slot 67",
        "Slot 68",
        "Slot 69",
        "Slot 70",

        "Slot 71",
        "Slot 72",
        "Slot 73",
        "Slot 74",
        "Slot 75",
        "Slot 76",
        "Slot 77",
        "Slot 78",
        "Slot 79",
        "Slot 80",

        "Slot 81",
        "Slot 82",
        "Slot 83",
        "Slot 84",
        "Slot 85",
        "Slot 86",
        "Slot 87",
        "Slot 88",
        "Slot 89",
        "Slot 90",

        "Slot 91",
        "Slot 92",
        "Slot 93",
        "Slot 94",
        "Slot 95",
        "Slot 96",
        "Slot 97",
        "Slot 98",
        "Slot 99"
        };
        Dictionary<int, int> KH1PNGBegin = new Dictionary<int, int>();
        Dictionary<int, int> KH1PNGEnd = new Dictionary<int, int>();
        Dictionary<int, int> KH1DATBegin = new Dictionary<int, int>();
        Dictionary<int, int> KH1DATEnd = new Dictionary<int, int>();

        public MainWindow()
        {
            InitializeComponent();

            SaveIndex.ItemsSource = SaveItems;

        }

        private void ConvertKH1_Click(object sender, RoutedEventArgs e)
        {
            byte[] BinFile = File.ReadAllBytes(FilePathKH1Bin.Text);
            byte[] PNG = File.ReadAllBytes(FilePathKH1PNG.Text);

            char[] MagicString = "GUMI".ToCharArray();

            //Bin Search
            int BinIndex = 0;
            for (int i = 0; i < BinFile.Length; i++)
            {
                if (BinFile[i] == MagicString[0])
                {
                    bool confirmedbyte = true;
                    int j = i;
                    for (int k = 0; k < MagicString.Length; j++)
                    {
                        if (BinFile[j] != MagicString[k])
                        {
                            confirmedbyte = false;
                            break;
                        }
                        k++;
                    }


                    if (confirmedbyte)
                    {
                        BinIndex = i;
                        break;
                    }
                }
            }






            int PNGIndex = 0;
            for (int i = 0; i < PNG.Length; i++)
            {
                if (PNG[i] == MagicString[0])
                {
                    bool confirmedbyte = true;
                    int j = i;
                    for (int k = 0; k < MagicString.Length; j++)
                    {
                        if (PNG[j] != MagicString[k])
                        {
                            confirmedbyte = false;
                            break;
                        }
                        k++;
                    }


                    if (confirmedbyte)
                    {
                        PNGIndex = i;
                        break;
                    }
                }


            }


            PNGIndex -= (BinIndex);
            BinIndex = 0;


            while (BinIndex < BinFile.Length)
            {
                PNG[PNGIndex] = BinFile[BinIndex];
                PNGIndex++;
                BinIndex++;
            }

            System.IO.File.Move(FilePathKH1PNG.Text, FilePathKH1PNG.Text + ".BACKUP");

            File.WriteAllBytes(FilePathKH1PNG.Text, PNG);





        }

        private void BrowseKH1PNG_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "PNG File | *.png" };
            if (openFileDialog.ShowDialog() ?? true)
                FilePathKH1PNG.Text = openFileDialog.FileName;
        }

        private void BrowseKH1DAT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "DAT File | *.bin" };
            if (openFileDialog.ShowDialog() ?? true)
                FilePathKH1Bin.Text = openFileDialog.FileName;
        }


        private void ConvertKH2_Click(object sender, RoutedEventArgs e)
        {
            byte[] BinFile = File.ReadAllBytes(FilePathKH2Bin.Text);
            byte[] PNG = File.ReadAllBytes(FilePathKH2PNG.Text);

            char[] MagicString = "KH2J:".ToCharArray();

            //Bin Search
            int BinIndex = 0;
            for (int i = 0; i < BinFile.Length; i++)
            {
                if (BinFile[i] == MagicString[0])
                {
                    bool confirmedbyte = true;
                    int j = i;
                    for (int k = 0; k < MagicString.Length; j++)
                    {
                        if (BinFile[j] != MagicString[k])
                        {
                            confirmedbyte = false;
                            break;
                        }
                        k++;
                    }


                    if (confirmedbyte)
                    {
                        BinIndex = i;
                        break;
                    }
                }
            }






            int PNGIndex = 0;
            for (int i = 0; i < PNG.Length; i++)
            {
                if (PNG[i] == MagicString[0])
                {
                    bool confirmedbyte = true;
                    int j = i;
                    for (int k = 0; k < MagicString.Length; j++)
                    {
                        if (PNG[j] != MagicString[k])
                        {
                            confirmedbyte = false;
                            break;
                        }
                        k++;
                    }


                    if (confirmedbyte)
                    {
                        PNGIndex = i;
                        break;
                    }
                }


            }


            PNGIndex -= (BinIndex);
            BinIndex = 0;


            while (BinIndex < BinFile.Length)
            {
                PNG[PNGIndex] = BinFile[BinIndex];
                PNGIndex++;
                BinIndex++;
            }

            System.IO.File.Move(FilePathKH2PNG.Text, FilePathKH2PNG.Text + ".BACKUP");

            File.WriteAllBytes(FilePathKH2PNG.Text, PNG);





        }

        private void BrowseKH2PNG_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "PNG File | *.png" };
            if (openFileDialog.ShowDialog() ?? true)
                FilePathKH2PNG.Text = openFileDialog.FileName;
        }

        private void BrowseKH2DAT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "bin File | *.bin" };
            if (openFileDialog.ShowDialog() ?? true)
                FilePathKH2Bin.Text = openFileDialog.FileName;
        }


        private void ConvertCoM_Click(object sender, RoutedEventArgs e)
        {
            byte[] BinFile = File.ReadAllBytes(FilePathCoMBin.Text);
            byte[] PNG = File.ReadAllBytes(FilePathCoMPNG.Text);

            char[] MagicString = "Deck 1".ToCharArray();

            int Save = 1;

            if (!int.TryParse(SaveFileCoM.Text, out Save))
            {
                Save = 1;
            }

            //Bin Search
            int BinIndex = 0;
            for (int i = 0; i < BinFile.Length; i++)
            {
                if (BinFile[i] == MagicString[0])
                {
                    bool confirmedbyte = true;
                    int j = i;
                    for (int k = 0; k < MagicString.Length; j++)
                    {
                        if (BinFile[j] != MagicString[k])
                        {
                            confirmedbyte = false;
                            break;
                        }
                        k++;
                    }


                    if (confirmedbyte)
                    {
                        BinIndex = i;
                        break;
                    }
                }
            }






            int PNGIndex = 0;
            int Found = 1;
            for (int i = 0; i < PNG.Length; i++)
            {
                if (PNG[i] == MagicString[0])
                {
                    bool confirmedbyte = true;
                    int j = i;
                    for (int k = 0; k < MagicString.Length; j++)
                    {
                        if (PNG[j] != MagicString[k])
                        {
                            confirmedbyte = false;
                            break;
                        }
                        k++;
                    }

                    if (confirmedbyte && Found != Save)
                    {
                        Found++;
                        confirmedbyte = false;
                        continue;
                    }

                    if (confirmedbyte)
                    {
                        PNGIndex = i;
                        break;
                    }
                }


            }


            PNGIndex -= (BinIndex);
            BinIndex = 0;


            while (BinIndex < BinFile.Length)
            {
                PNG[PNGIndex] = BinFile[BinIndex];
                PNGIndex++;
                BinIndex++;
            }

            System.IO.File.Move(FilePathCoMPNG.Text, FilePathCoMPNG.Text + ".BACKUP" + Save);

            File.WriteAllBytes(FilePathCoMPNG.Text, PNG);





        }

        private void BrowseCoMPNG_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "PNG File | *.png" };
            if (openFileDialog.ShowDialog() ?? true)
                FilePathCoMPNG.Text = openFileDialog.FileName;
        }

        private void BrowseCoMDAT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "bin File | *.bin" };
            if (openFileDialog.ShowDialog() ?? true)
                FilePathCoMBin.Text = openFileDialog.FileName;
        }


        private void ConvertBBS_Click(object sender, RoutedEventArgs e)
        {
            byte[] BinFile = File.ReadAllBytes(FilePathBBSBin.Text);
            byte[] PNG = File.ReadAllBytes(FilePathBBSPNG.Text);

            char[] MagicString = "BBSD".ToCharArray();

            int Save = 1;

            if (!int.TryParse(SaveFileBBS.Text, out Save))
            {
                Save = 1;
            }

            //Bin Search
            int BinIndex = 0;
            for (int i = 0; i < BinFile.Length; i++)
            {
                if (BinFile[i] == MagicString[0])
                {
                    bool confirmedbyte = true;
                    int j = i;
                    for (int k = 0; k < MagicString.Length; j++)
                    {
                        if (BinFile[j] != MagicString[k])
                        {
                            confirmedbyte = false;
                            break;
                        }
                        k++;
                    }


                    if (confirmedbyte)
                    {
                        BinIndex = i;
                        break;
                    }
                }
            }






            int PNGIndex = 0;
            int Found = 1;
            for (int i = 0; i < PNG.Length; i++)
            {
                if (PNG[i] == MagicString[0])
                {
                    bool confirmedbyte = true;
                    int j = i;
                    for (int k = 0; k < MagicString.Length; j++)
                    {
                        if (PNG[j] != MagicString[k])
                        {
                            confirmedbyte = false;
                            break;
                        }
                        k++;
                    }

                    if (confirmedbyte && Found != Save)
                    {
                        Found++;
                        confirmedbyte = false;
                        continue;
                    }

                    if (confirmedbyte)
                    {
                        PNGIndex = i;
                        break;
                    }
                }


            }


            PNGIndex -= (BinIndex);
            BinIndex = 0;


            while (BinIndex < BinFile.Length)
            {
                PNG[PNGIndex] = BinFile[BinIndex];
                PNGIndex++;
                BinIndex++;
            }

            System.IO.File.Move(FilePathBBSPNG.Text, FilePathBBSPNG.Text + ".BACKUP" + Save);

            File.WriteAllBytes(FilePathBBSPNG.Text, PNG);





        }

        private void BrowseBBSPNG_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "PNG File | *.png" };
            if (openFileDialog.ShowDialog() ?? true)
                FilePathBBSPNG.Text = openFileDialog.FileName;
        }

        private void BrowseBBSDAT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "DAT File | *.DAT" };
            if (openFileDialog.ShowDialog() ?? true)
                FilePathBBSBin.Text = openFileDialog.FileName;
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            byte[] PNG = File.ReadAllBytes(FilePathPNG.Text);

            int Save = 1;


            if (!SaveType.Full)
            {

            }


            for(int i = 0; i + SaveType.DataBeginOffset < (SaveType.Data.Length ); i++)
            {
                PNG[SaveType.PNGBeginOffset + i] = SaveType.Data[SaveType.DataBeginOffset + i];
            }

            System.IO.File.Move(FilePathPNG.Text, FilePathPNG.Text + ".BACKUP" + Save);

            File.WriteAllBytes(FilePathPNG.Text, PNG);





        }

        private void BrowsePNG_Click(object sender, RoutedEventArgs e)
        {

            if (NewSave.IsChecked ?? true)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "PNG File | *.png" };
                if (openFileDialog.ShowDialog() ?? true)
                {
                    FilePathPNG.Text = openFileDialog.FileName;
                }
            }

        }

        private void BrowseDAT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "DAT File|*.DAT|BIN File|*.bin" };
            if (openFileDialog.ShowDialog() ?? true)
            {
                FilePathBin.Text = openFileDialog.FileName;
                byte[] BinFile = File.ReadAllBytes(openFileDialog.FileName);

                SaveType = new KHSaveType()
                {
                    FilePath = openFileDialog.FileName,
                    Data = BinFile
                };
                SaveType.DetermineGame();
                

                RadioButton Selected = (RadioButton)this.FindName(SaveType.SelectedGame.ToString());
                if(Selected != null)
                {
                    Selected.IsChecked = true;
                }
                

            }
        }
    }
}
