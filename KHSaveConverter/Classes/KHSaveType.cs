using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHSaveConverter.Classes
{
    public class KHSaveType
    {
        public bool Full = false;
        public enum Game
        {
            UNKNOWN = 0,
            KH1 = 1,
            KHCoM = 2,
            KH2 = 3,
            KHBBS = 4,
            KHDDD = 5,
            KHFP = 6,
            KH3 = 7
        }

        public Game SelectedGame { get; set; }
        public string FilePath { get; set; }

        public byte[] Data { get; set; }

        public int DataBeginOffset { get; set; }
        public int PNGBeginOffset { get; set; }
        public int PNGOffsetStep { get; set; }

        public string MatchingString { get; set; }
        public void DetermineGame()
        {
            List<string> KeyStrings = new List<string>()
                {
                    "BISLPS-25198-01",
                    "GUMI",
                    "Deck 1",
                    "KH2J:",
                    "BBSD"
                };
            SelectedGame = Game.UNKNOWN;
            string Text = Encoding.Default.GetString(Data);
            foreach(string s in KeyStrings)
            {
                if (Text.Contains(s))
                {
                    MatchingString = s;
                    switch (MatchingString)
                    {
                        case "BISLPS-25198-01":
                            DataBeginOffset = 17600;
                            PNGBeginOffset = 68912;
                            Full = true;
                            SelectedGame = Game.KH1;
                            break;
                        case "GUMI":
                            DataBeginOffset = 0;
                            PNGBeginOffset = 68912;
                            Full = false;
                            SelectedGame = Game.KH1;
                            break;
                        case "Deck 1":
                            Full = false;
                            SelectedGame = Game.KHCoM;
                            break;
                        case "KH2J:":
                            Full = false;
                            SelectedGame = Game.KH2;
                            break;
                        case "BBSD":
                            Full = false;
                            SelectedGame = Game.KHBBS;
                            break;
                    }
                    break;

                }
            }
            /*
            for (int i = 0; i < Data.Length; i++)
            {
                for (int j = 0; j < KeyStrings.Count; j++)
                {

                    if (Data[i] == KeyStrings[j].ToCharArray()[0])
                    {
                        bool confirmedbyte = true;
                        int l = i;
                        for (int k = 0; k < KeyStrings[j].Length; l++)
                        {
                            if (Data[l] != KeyStrings[j].ToCharArray()[k])
                            {
                                confirmedbyte = false;
                                break;
                            }
                            k++;
                        }


                        if (confirmedbyte)
                        {
                            switch (KeyStrings[j])
                            {
                                case "-01/system.bin":
                                    Full = true;
                                    SelectedGame = Game.KH1;
                                    break;
                                case "GUMI":
                                    Full = false;
                                    SelectedGame = Game.KH1;
                                    break;
                                case "Deck 1":
                                    Full = false;
                                    SelectedGame = Game.KHCoM;
                                    break;
                                case "KH2J:":
                                    Full = false;
                                    SelectedGame = Game.KH2;
                                    break;
                                case "BBSD":
                                    Full = false;
                                    SelectedGame = Game.KHBBS;
                                    break;
                            }
                            break;
                        }
                    }
                }*/
                if (SelectedGame != Game.UNKNOWN)
                {
                    //break;
                }
            //}
        }
    }
}
