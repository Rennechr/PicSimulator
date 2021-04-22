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
        public static bool[,] storage = new bool[8,255] ;
        public List<string> codeBackend = new List<string>();
        public List<int> breakpoints = new List<int>();
        public int backendCurrentRow = 0;
        public void next()
        {
            switch (codeBackend.ElementAt(backendCurrentRow).Substring(0,1))
            {
                case "0":          
                    switch(codeBackend.ElementAt(backendCurrentRow).Substring(1, 2))
                    {
                        case "0":       //MOVWF or NOP or RETFIE or CLRWDT or RETURN or SLEEP
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
                    switch (codeBackend.ElementAt(backendCurrentRow).Substring(1, 2))
                    {
                        case "0":       //BCF
                        case "1":
                        case "2":
                        case "3":
                            break;
                        case "4":       //BSF
                        case "5":
                        case "6":
                        case "7":
                            break;
                        case "8":       //BTFSC
                        case "9":
                        case "A":
                        case "B":
                            break;
                        case "C":       //BTFSS
                        case "D":
                        case "E":
                        case "F":
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    switch (codeBackend.ElementAt(backendCurrentRow).Substring(1, 2))
                    {
                        case "0":       //CALL
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
                        case "7":
                            break;
                        case "8":       //GOTO
                        case "9":
                        case "A":
                        case "B":
                        case "C":
                        case "D":
                        case "E":
                            break;
                        case "F":
                            GOTO(Convert.ToInt32(codeBackend.ElementAt(backendCurrentRow).Substring(2), 16));
                            break;
                        default:
                            break;
                    }
                    break;
                case "3":
                    switch (codeBackend.ElementAt(backendCurrentRow).Substring(1, 2))
                    {
                        case "0":       //MOVLW
                        case "1":
                        case "2":
                        case "3":
                            break;
                        case "4":       //RETLW
                        case "5":
                        case "6":
                        case "7":
                            break;
                        case "8":       //IORLW
                            break;      
                        case "9":       //ANDLW
                            break;
                        case "A":       //XORLW
                            break;
                        case "B":
                            break;
                        case "C":       //SUBLW
                        case "D":
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

        }
        
    }
}
