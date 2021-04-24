using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PicSimulator
{
    class Backend
    {
        public static bool[,] storage = new bool[255,8];
        public static bool[] WRegister = new bool[8];
        public List<string> codeBackend = new List<string>();
        public List<int> breakpoints = new List<int>();
        public List<int> calls = new List<int>();
        public int backendCurrentRow = 0;

        public bool[] HexToBoolArray(string Hex)         //todo Jannick: das einfach anwenden und keine fragen stellen xD
        {
            bool[] literal = new bool[8];
            string bits = Convert.ToString(Convert.ToInt32(Hex, 16), 2);
            bits = "00000000" + bits;
            bits = bits.Substring(bits.Length - 8);            
            literal = bits.Select(s => s == '1').ToArray();
            return literal;
        }
        public void next()
        {
            switch (codeBackend.ElementAt(backendCurrentRow).Substring(0,1))
            {
                case "0":          
                    switch(codeBackend.ElementAt(backendCurrentRow).Substring(1, 1))
                    {
                        case "0":       //MOVWF or NOP or RETFIE or CLRWDT or RETURN or SLEEP
                            switch (codeBackend.ElementAt(backendCurrentRow).Substring(2, 2))
                            {
                                case "00":  //NOP
                                case "20":
                                case "40":
                                case "60":
                                    break;
                                case "08":  //RETURN
                                    RETURN();
                                    break;
                                case "09":  //RETFIE
                                    break;
                                case "54":  //CLRWDT
                                    break;
                                case "53":  //SLEEP
                                    break;
                                default:    //MOVWF
                                    break;
                            }
                            //switch case?
                            break;
                        case "1":       //CLRF or CLRW      todo Jannick
                            break;
                        case "2":       //SUBWF     todo Jannick
                            break;      
                        case "3":       //DECF       todo Jannick  
                            break;
                        case "4":       //IORWF     todo Jannick
                            break;
                        case "5":       //ANDWF     todo Jannick
                            break;
                        case "6":       //XORWF     todo Jannick
                            break;
                        case "7":       //ADDWF     todo Jannick
                            break;
                        case "8":       //MOVF     todo Jannick
                            break;
                        case "9":       //COMF     todo Jannick
                            break;
                        case "A":       //INCF     todo Jannick
                            //INCF(speicherstelle)
                            break;
                        case "B":       //DECFSZ     todo Jannick
                            break;
                        case "C":       //RRF     todo Jannick
                            break;
                        case "D":       //RLF     todo Jannick
                            break;
                        case "E":       //SWAPF     todo Jannick
                            break;
                        case "F":       //INCFSZ     todo Jannick
                            break;
                        default:
                            break;
                    }
                    break;
                case "1":
                    switch (codeBackend.ElementAt(backendCurrentRow).Substring(1, 1))
                    {
                        case "0":       //BCF
                            if(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16)< 8)
                            {
                                BCF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2,2),16), 0);
                            }
                            else
                            {
                                BCF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 1);
                            }
                            break;
                        case "1":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BCF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 2);
                            }
                            else
                            {
                                BCF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 3);
                            }
                            break;
                        case "2":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BCF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 4);
                            }
                            else
                            {
                                BCF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 5);
                            }
                            break;
                        case "3":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BCF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 6);
                            }
                            else
                            {
                                BCF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 7);
                            }
                            break;
                        case "4":       //BSF
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BSF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 0);
                            }
                            else
                            {
                                BSF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 1);
                            }
                            break;
                        case "5":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BSF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 2);
                            }
                            else
                            {
                                BSF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 3);
                            }
                            break;
                        case "6":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BSF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 4);
                            }
                            else
                            {
                                BSF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 5);
                            }
                            break;
                        case "7":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BSF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 6);
                            }
                            else
                            {
                                BSF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 7);
                            }
       
                            break;
                        case "8":       //BTFSC
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BTFSC(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 0);
                            }
                            else
                            {
                                BTFSC(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 1);
                            }
                            break;
                        case "9":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BTFSC(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 2);
                            }
                            else
                            {
                                BTFSC(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 3);
                            }
                            break;
                        case "A":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BTFSC(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 4);
                            }
                            else
                            {
                                BTFSC(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 5);
                            }
                            break;
                        case "B":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BTFSC(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 6);
                            }
                            else
                            {
                                BTFSC(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 7);
                            }
                            break;
                        case "C":       //BTFSS
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BTFSS(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 0);
                            }
                            else
                            {
                                BTFSS(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 1);
                            }
                            break;
                        case "D":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BTFSS(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 2);
                            }
                            else
                            {
                                BTFSS(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 3);
                            }
                            break;
                        case "E":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BTFSS(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 4);
                            }
                            else
                            {
                                BTFSS(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 5);
                            }
                            break;
                        case "F":
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 1), 16) < 8)
                            {
                                BTFSS(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16), 6);
                            }
                            else
                            {
                                BTFSS(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16) - 128, 7);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    switch (codeBackend.ElementAt(backendCurrentRow).Substring(1, 1))
                    {
                        case "0":       //CALL
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
                        case "7":
                            CALL(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(1, 3), 16));
                            break;
                        case "8":       //GOTO
                        case "9":
                        case "A":
                        case "B":
                        case "C":
                        case "D":
                        case "E":
                        case "F":
                            GOTO(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(1,3), 16) - 2048);
                            break;
                        default:
                            //BIG ERROR MSG
                            break;
                    }
                    break;
                case "3":
                    switch (codeBackend.ElementAt(backendCurrentRow).Substring(1, 1))
                    {
                        case "0":       //MOVLW
                        case "1":
                        case "2":
                        case "3":
                            MOVLW(HexToBoolArray(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2)));
                            break;
                        case "4":       //RETLW
                        case "5":
                        case "6":
                        case "7":
                            RETLW(HexToBoolArray(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2)));
                            break;
                        case "8":       //IORLW
                            IORLW(HexToBoolArray(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2)));
                            break;      
                        case "9":       //ANDLW
                            ANDLW(HexToBoolArray(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2)));
                            break;
                        case "A":       //XORLW
                            XORLW(HexToBoolArray(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2)));
                            break;
                        case "B":
                            break;
                        case "C":       //SUBLW
                        case "D":
                            SUBLW(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "E":       //ADDLW
                        case "F":
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            backendCurrentRow++;
        }
        void GOTO(int toRow)
        {
            backendCurrentRow = toRow;
            backendCurrentRow--;
        }
        void CALL(int toRow)
        {
            calls.Add(backendCurrentRow);
            backendCurrentRow = toRow;
            backendCurrentRow--;
        }
        void RETURN()
        {
            backendCurrentRow = calls.Last();
            calls.RemoveAt(calls.Count - 1);
            backendCurrentRow--;
        }
        void RETLW(bool[] literal)
        {
            WRegister = literal;
            backendCurrentRow = calls.Last();
            calls.RemoveAt(calls.Count - 1);
            backendCurrentRow--;
        }
        void MOVLW(bool[] literal)
        {
            WRegister = literal;
        }
        void IORLW(bool[] literal)              //Was ist mit Z bit?
        {
            bool[] result = new bool[8];
            for(int i = 0; i < 8; i++)
            {
                if((literal[i]&&WRegister[i])||(literal[i]&&!WRegister[i])||(!literal[i]&&WRegister[i]))
                {
                    result[i] = true;
                }
                else
                {
                    result[i] = false;
                }
            }
            WRegister = result;
        }
        void ANDLW(bool[] literal)
        {
            bool[] result = new bool[8];

            for (int i = 0; i < 8; i++)
            {
                if ((literal[i] && WRegister[i]))
                {
                    result[i] = true;
                }
                else
                {
                    result[i] = false;
                }
            }
            WRegister = result;
        }
        void XORLW(bool[] literal)
        {
            bool[] result = new bool[8];

            for (int i = 0; i < 8; i++)
            {
                if ((literal[i] && !WRegister[i]) || (!literal[i] && WRegister[i]))
                {
                    result[i] = true;
                }
                else
                {
                    result[i] = false;
                }
            }
            WRegister = result;
        }
        void SUBLW(int literal)
        {
            //todo
        }
        void BCF(int storagePlace, int bitNr)
        {
            storage[storagePlace, bitNr] = false;
        }
        void BSF(int storagePlace, int bitNr)
        {
            storage[storagePlace, bitNr] = true;
        }
        void BTFSC(int storagePlace, int bitNr)
        {
            if (storage[storagePlace, bitNr] == false)
            {
                backendCurrentRow++;
            }
        }
        void BTFSS(int storagePlace, int bitNr)
        {
            if (storage[storagePlace, bitNr] == true)
            {
                backendCurrentRow++;
            }
        }
    }
}
