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
        public MainWindow()
        {
            InitializeComponent();
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

                    if(confirmedbyte && Found != Save)
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
    }
}
