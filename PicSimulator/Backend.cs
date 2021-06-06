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
        int BoolArrayToInt(bool[] bits)
        {
            if (bits.Length > 32) throw new ArgumentException("Can only fit 32 bits in a uint");

            int r = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i]) r |= 1 << (bits.Length - i);
            }
            return r;
        }
        public bool[] IntToBoolArray(int number)
        {
            bool[] literal = new bool[8];
            string bits = Convert.ToString(number, 2);
            bits = "00000000" + bits;
            bits = bits.Substring(bits.Length - 8);
            literal = bits.Select(s => s == '1').ToArray();
            return literal;
        }
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
                                    MOVWF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16)-128);
                                    break;
                            }
                            //switch case?
                            break;
                        case "1":  //CLRF or CLRW 
                            if (Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2,1), 16) >= 8)
                            {
                                CLRF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            } else
                            {
                                CLRW();
                            }

                            break;
                        case "2":  //SUBWF
                            SUBWF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;      
                        case "3":  //DECF
                            DECF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "4": //IORWF
                            IORWF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "5": //ANDWF
                            ANDWF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "6": //XORWF
                            XORWF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "7": //ADDWF
                            ADDWF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "8": //MOVF
                            MOVF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "9": //COMF
                            COMF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "A": //INCF
                            INCF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "B": //DECFSZ
                            DECFSZ(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "C": //RRF
                            RRF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "D": //RLF
                            RLF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "E": //SWAPF
                            SWAPF(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
                            break;
                        case "F": //INCFSZ
                            INCFSZ(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
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
                            ADDLW(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2, 2), 16));
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
        void MOVWF(int position)
        {
            for(int i = 0; i < 8; i++)
            {
                storage[position, i] = WRegister[i];
            }
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
        void IORLW(bool[] literal)             
        {
            bool[] result = new bool[8];
            int count = 0;
            for(int i = 0; i < 8; i++)
            {
                if((literal[i]&&WRegister[i])||(literal[i]&&!WRegister[i])||(!literal[i]&&WRegister[i]))
                {
                    result[i] = true;
                }
                else
                {
                    result[i] = false;
                    count++;
                }
            }
            WRegister = result;
            if(count == 8)
            {
                setZeroBit(true);
            }
            else
            {
                setZeroBit(false);
            }
        }
        void ANDLW(bool[] literal)
        {
            bool[] result = new bool[8];
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                if ((literal[i] && WRegister[i]))
                {
                    result[i] = true;
                }
                else
                {
                    count++;
                    result[i] = false;
                }
            }
            WRegister = result;
            if(count == 8)
            {
                setZeroBit(true);
            }
            else
            {
                setZeroBit(false);
            }
        }
        void XORLW(bool[] literal)
        {
            bool[] result = new bool[8];
            int count = 0;

            for (int i = 0; i < 8; i++)
            {
                if ((literal[i] && !WRegister[i]) || (!literal[i] && WRegister[i]))
                {
                    result[i] = true;
                }
                else
                {
                    count++;
                    result[i] = false;
                }
            }
            WRegister = result;
            if (count == 8)
            {
                setZeroBit(true);
            }
            else
            {
                setZeroBit(false);
            }
        }
        void SUBLW(int literal)         //ask DC bit affected???
        {
            int w = BoolArrayToInt(WRegister);
            bool checkDC = WRegister[3];
            int result = w - literal;
            if (result < 0)
            {
                result = result + 256;
                WRegister = IntToBoolArray(result);
                if (result == 0)
                {
                    setZeroBit(true);
                }
                else
                {
                    setZeroBit(false);
                }
                
                setCarryBit(false);
            }
            else if(result == 0)
            {
                WRegister = IntToBoolArray(result);
                setZeroBit(true);
                setCarryBit(true);
            }
            else
            {
                WRegister = IntToBoolArray(result);                
                setZeroBit(false);
                setCarryBit(true);
            }
            if (checkDC == WRegister[3])
            {
                BCF(3, 1);      //set digit Carry bit
                BCF(131, 1);
            }
            else
            {
                BSF(3, 1);          //unset digit carry bit
                BSF(131, 1);
            }
        }

        void ADDLW(int literal)          //ask DC bit affected???
        {
            int w = BoolArrayToInt(WRegister);
            bool checkDC = WRegister[3];
            int result = w + literal;
            if (result > 255)
            {
                result = result - 256;
                WRegister = IntToBoolArray(result);
                if(result == 0)
                {
                    setZeroBit(true);
                }
                else
                {                    
                    setZeroBit(false);
                }
                setCarryBit(true);
            }
            else if (result == 0)
            {
                WRegister = IntToBoolArray(result);
                setZeroBit(true);
            }
            else
            {
                WRegister = IntToBoolArray(result);
                setZeroBit(false);
                setCarryBit(false);
            }
            if(checkDC == WRegister[3])
            {
                BCF(3, 1);      //set digit Carry bit
                BCF(131, 1);
            }
            else
            {
                BSF(3, 1);          //unset digit carry bit
                BSF(131, 1);
            }
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

        void CLRF(int addresse)
        {
            addresse = addresse - 128;
            for (int i = 0; i < 8; i++)
            {
                BCF(addresse, i);
            }
        }

        void CLRW()
        {
            for (int i = 0; i < 8; i++)
            {
                WRegister[i] = false;
            }

        }

        void SUBWF(int addresse)
        {

            if (addresse < 128)
            {
                int w = BoolArrayToInt(WRegister);
                bool checkDigitCarry = WRegister[3];

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                int result = f - w;

                if (result == 0)
                {
                    setZeroBit(true);
                    setCarryBit(true);

                } else if (result < 0)
                {
                    result = result + 256;

                    setZeroBit(false);
                    setCarryBit(false);

                } else if (result > 0)
                {
                    setZeroBit(true);
                    setCarryBit(true);
                }

                WRegister = IntToBoolArray(result);

                if (checkDigitCarry == WRegister[3])
                {
                    BCF(3, 1);
                    BCF(131, 1);
                } else
                {
                    BSF(3, 1);
                    BSF(131, 1);
                }
            } else
            {
                addresse = addresse - 128;

                int w = BoolArrayToInt(WRegister);
                bool checkDigitCarry = WRegister[3];

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                int result = f - w;

                if (result == 0)
                {
                    setZeroBit(true);
                    setCarryBit(true);

                }
                else if (result < 0)
                {
                    result = result + 256;
                    
                    setZeroBit(false);
                    setCarryBit(false);

                }
                else if (result > 0)
                {
                    setZeroBit(true);
                    setCarryBit(true);
                }

                bool[] tempBool = new bool[8];
                tempBool = IntToBoolArray(result);

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = tempBool[i];
                }
                                
                if (checkDigitCarry == WRegister[3])
                {
                    BCF(3, 1);
                    BCF(131, 1);
                }
                else
                {
                    BSF(3, 1);
                    BSF(131, 1);
                }
            }
        }


        void DECF(int addresse)
        {
            if (addresse < 128)
            {
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                f--;

                if (f == 0)
                {
                    setZeroBit(true);
                    setCarryBit(true);
                }
                else if (f < 0)
                {
                    setZeroBit(false);                    
                    setCarryBit(false);

                    f = f + 256;
                }
                else
                {
                    
                    setZeroBit(false);
                    setCarryBit(false);
                }

                WRegister = IntToBoolArray(f);
            }
            else 
            {
                addresse = addresse - 128;

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                f--;

                if (f == 0)
                {
                    setZeroBit(true);
                    setCarryBit(true);
                }
                else if (f < 0)
                {
                    setZeroBit(false);
                    setCarryBit(false);

                    f = f + 256;
                }
                else
                {
                    
                    setZeroBit(false);
                    setCarryBit(false);
                }

                bool[] tempBool = new bool[8];
                tempBool = IntToBoolArray(f);

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = tempBool[i];
                }
            }
        }

        void IORWF(int addresse)
        {
            bool[] boolresult = new bool[8];

            if (addresse < 128)
            {
                for (int i = 0; i < 8; i++)
                {

                    if (storage[addresse, i] == false && WRegister[i] == false)
                    {
                        boolresult[i] = false;
                    }
                    else
                    {
                        boolresult[i] = true;
                    }
                }

                bool tempfalse = true;
                for (int i = 0; i < 8; i++)
                {
                    if (boolresult[i] == true)
                    {
                        tempfalse = false;
                    }
                }
                if (!tempfalse)
                {
                    setZeroBit(true);
                } else
                {
                    setZeroBit(false);
                }

                WRegister = boolresult;

            }
            else
            {
                addresse = addresse - 128;

                for (int i = 0; i < 8; i++)
                {

                    if (storage[addresse, i] == false && WRegister[i] == false)
                    {
                        boolresult[i] = false;
                    }
                    else
                    {
                        boolresult[i] = true;
                    }
                }

                bool tempfalse = true;
                for (int i = 0; i < 8; i++)
                {
                    if (boolresult[i] == true)
                    {
                        tempfalse = false;
                    }
                }
                if (!tempfalse)
                {
                    setZeroBit(true);
                }
                else
                {
                    setZeroBit(false);
                }

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = boolresult[i];
                }
            }
        }
        void ANDWF(int addresse)
        {
            bool[] boolresult = new bool[8];

            if (addresse < 128)
            {
                for (int i = 0; i < 8; i++)
                {

                    if (storage[addresse, i] == true && WRegister[i] == true)
                    {
                        boolresult[i] = true;
                    }
                    else
                    {
                        boolresult[i] = false;
                    }
                }

                bool tempfalse = true;
                for (int i = 0; i < 8; i++)
                {
                    if (boolresult[i] == true)
                    {
                        tempfalse = false;
                    }
                }
                if (!tempfalse)
                {                    
                    setZeroBit(false);
                }
                else
                {
                    setZeroBit(true);
                }

                WRegister = boolresult;

            }
            else
            {
                addresse = addresse - 128;

                for (int i = 0; i < 8; i++)
                {

                    if (storage[addresse, i] == true && WRegister[i] == true)
                    {
                        boolresult[i] = true;
                    }
                    else
                    {
                        boolresult[i] = false;
                    }
                }

                bool tempfalse = true;
                for (int i = 0; i < 8; i++)
                {
                    if (boolresult[i] == true)
                    {
                        tempfalse = false;
                    }
                }
                if (!tempfalse)
                {
                    setZeroBit(false);
                }
                else
                {
                    setZeroBit(true);
                }

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = boolresult[i];
                }
            }
        }
        void XORWF(int addresse)
        {
            bool[] boolresult = new bool[8];

            if (addresse < 128)
            {
                for (int i = 0; i < 8; i++)
                {

                    if ((storage[addresse, i] == true && WRegister[i] == true) || 
                        (storage[addresse, i] == false && WRegister[i] == false))
                    {
                        boolresult[i] = false;
                    }
                    else
                    {
                        boolresult[i] = true;
                    }
                }

                bool tempfalse = true;
                for (int i = 0; i < 8; i++)
                {
                    if (boolresult[i] == true)
                    {
                        tempfalse = false;
                    }
                }
                if (!tempfalse)
                {
                    setZeroBit(false);
                }
                else
                {
                    setZeroBit(true);
                }

                WRegister = boolresult;

            }
            else
            {
                addresse = addresse - 128;

                for (int i = 0; i < 8; i++)
                {

                    if ((storage[addresse, i] == true && WRegister[i] == true) ||
                        (storage[addresse, i] == false && WRegister[i] == false))
                    {
                        boolresult[i] = false;
                    }
                    else
                    {
                        boolresult[i] = true;
                    }
                }

                bool tempfalse = true;
                for (int i = 0; i < 8; i++)
                {
                    if (boolresult[i] == true)
                    {
                        tempfalse = false;
                    }
                }
                if (!tempfalse)
                {
                    setZeroBit(false);
                }
                else
                {
                    setZeroBit(true);
                }

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = boolresult[i];
                }
            }
        }

        void ADDWF(int addresse)
        {
            if (addresse < 128)
            {
                int w = BoolArrayToInt(WRegister);
                bool checkDigitCarry = WRegister[3];

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                int result = f + w;

          
                if (result > 255)
                {
                    result = result - 256;
                  
                    setCarryBit(true);

                }
                else
                {
                    setZeroBit(true);
                    setCarryBit(false);
                }

                if (result == 0)
                {
                    setZeroBit(true);
                }
                else
                {
                    setZeroBit(false);
                }

                WRegister = IntToBoolArray(result);

                if (checkDigitCarry == WRegister[3])
                {
                    BCF(3, 1);
                    BCF(131, 1);
                }
                else
                {
                    BSF(3, 1);
                    BSF(131, 1);
                }

            }
            else
            {
                addresse = addresse - 128;

                int w = BoolArrayToInt(WRegister);
                bool checkDigitCarry = WRegister[3];

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                int result = f + w;


                if (result > 255)
                {
                    result = result - 256;


                    setCarryBit(true);

                }
                else
                {
                    setZeroBit(true);
                    setCarryBit(false);
                }

                if (result == 0)
                {
                    setZeroBit(true);
                }
                else
                {
                    setZeroBit(false);
                }

                bool[] tempBool = new bool[8];
                tempBool = IntToBoolArray(result);

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = tempBool[i];
                }

                if (checkDigitCarry == WRegister[3])
                {
                    BCF(3, 1);
                    BCF(131, 1);
                }
                else
                {
                    BSF(3, 1);
                    BSF(131, 1);
                }

            }
        }

        void MOVF(int addresse)
        {
            if (addresse < 128)
            {
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                WRegister = booltemp;

                setZeroBit(true);



            } else
            {
                addresse = addresse - 128;

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }


                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = booltemp[i];
                }

                
                setZeroBit(false);


            }
        }
        void COMF(int addresse)
        {
            if (addresse < 128)
            {
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = !storage[addresse, i];
                }

                WRegister = booltemp;
                bool tempfalse = true;
                
                for (int i = 0; i < 8; i++)
                {
                    if (booltemp[i] == true)
                    {
                        tempfalse = false;
                    }
                }
                if (!tempfalse)
                {
                    
                    setZeroBit(false);
                }
                else
                {
                    setZeroBit(true);
                }
            }
            else
            {
                addresse = addresse - 128;
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = !storage[addresse, i];
                }

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = booltemp[i];
                }

                bool tempfalse = true;

                for (int i = 0; i < 8; i++)
                {
                    if (booltemp[i] == true)
                    {
                        tempfalse = false;
                    }
                }
                if (!tempfalse)
                {
                    
                    setZeroBit(false);
                }
                else
                {
                    setZeroBit(true);
                }
            }
        }



        void INCF(int addresse)
        {
            if (addresse < 128)
            {
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                f++;

                if (f > 255)
                {
                    setZeroBit(true);
                    setCarryBit(true);

                    f = f - 256;
                }
                else
                {
                    setZeroBit(false);
                    setCarryBit(false);
                }

                WRegister = IntToBoolArray(f);
            }
            else
            {
                addresse = addresse - 128;

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                f++;

                if (f > 255)
                {
                    setZeroBit(true);
                    setCarryBit(true);

                    f = f - 256;
                }
                else
                {
                    setZeroBit(false);
                    setCarryBit(false);
                }

                booltemp = IntToBoolArray(f);

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = booltemp[i];
                }
            }
        }
        void DECFSZ(int addresse)
        {
            if (addresse < 128)
            {
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                f--;

                if (f == 0)
                {
                    backendCurrentRow++;
                }
                else if (f < 0)
                {
                    f = f + 256;
                }

                WRegister = IntToBoolArray(f);
            }
            else
            {
                addresse = addresse - 128;

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                f--;

                if (f == 0)
                {
                    backendCurrentRow++;
                }
                else if (f < 0)
                {
                    f = f + 256;
                }

                bool[] tempBool = new bool[8];
                tempBool = IntToBoolArray(f);

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = tempBool[i];
                }
            }
        }
        void RRF(int addresse)
        {
            if (addresse < 128)
            {
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                bool temp, temp2;

                temp = booltemp[0];
                booltemp[0] = false;
                
                for (int i = 1; i < 8; i++)
                {
                    temp2 = booltemp[i];
                    booltemp[i] = temp;
                    temp = temp2;
                }
                setCarryBit(false);

                WRegister = booltemp;
            }
            else
            {
                addresse = addresse - 128;

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                bool temp, temp2;

                temp = booltemp[0];
                booltemp[0] = false;

                for (int i = 1; i < 8; i++)
                {
                    temp2 = booltemp[i];
                    booltemp[i] = temp;
                    temp = temp2;
                }
                setCarryBit(false);

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = booltemp[i];
                }
            }
        }




        void RLF(int addresse)
        {
            if (addresse < 128)
            {
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                bool temp, temp2;

                temp = booltemp[7];
                booltemp[7] = false;

                for (int i = 6; i >= 0 ; i--)
                {
                    temp2 = booltemp[i];
                    booltemp[i] = temp;
                    temp = temp2;
                }
                setCarryBit(true);

                WRegister = booltemp;
            }
            else
            {
                addresse = addresse - 128;

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                bool temp, temp2;

                temp = booltemp[7];
                booltemp[7] = false;

                for (int i = 6; i >= 0; i--)
                {
                    temp2 = booltemp[i];
                    booltemp[i] = temp;
                    temp = temp2;
                }
                setCarryBit(true);

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = booltemp[i];
                }
            }

        }
        void SWAPF(int addresse)
             
        {
            if (addresse < 128)
            {
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }


                bool[] booltemp1 = new bool[4];

                for (int i = 0; i < 4; i++)
                {
                    booltemp1[i] = booltemp[i];
                }
                for (int i = 0; i < 4; i++)
                {
                    booltemp[i] = booltemp[i+4];
                }
                for (int i = 0; i < 4; i++)
                {
                    booltemp[i+4] = booltemp1[i];
                }


                WRegister = booltemp;
            }
            else
            {
                addresse = addresse - 128;

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                bool[] booltemp1 = new bool[4];

                for (int i = 0; i < 4; i++)
                {
                    booltemp1[i] = booltemp[i];
                }
                for (int i = 0; i < 4; i++)
                {
                    booltemp[i] = booltemp[i + 4];
                }
                for (int i = 0; i < 4; i++)
                {
                    booltemp[i + 4] = booltemp1[i];
                }

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = booltemp[i];
                }
            }

        }
        void INCFSZ(int addresse)
        
        {
            if (addresse < 128)
            {
                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                f++;

                if (f == 256)
                {
                    f = 0;
                    backendCurrentRow++;
                }

                WRegister = IntToBoolArray(f);
            }
            else
            {
                addresse = addresse - 128;

                bool[] booltemp = new bool[8];

                for (int i = 0; i < 8; i++)
                {
                    booltemp[i] = storage[addresse, i];
                }

                int f = BoolArrayToInt(booltemp);

                f++;

                if (f == 256)
                {
                    f = 0;
                    backendCurrentRow++;
                }

                bool[] tempBool = new bool[8];
                tempBool = IntToBoolArray(f);

                for (int i = 0; i < 8; i++)
                {
                    storage[addresse, i] = tempBool[i];
                }
            }
        }







        void setCarryBit(bool set)
        {
            if (set)
            {
                BSF(3, 0);
                BSF(131, 0);

            } else
            {
                BCF(3, 0);     
                BCF(131, 0);
            }
        }

        void setZeroBit(bool set)
        {
            if (set)
            {
                BSF(3, 2);
                BSF(131, 2);
            }
            else
            {
                BCF(3, 2);
                BCF(131, 2);
            }
        }
    }
}
