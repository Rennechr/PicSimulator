using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PicSimulator
{
    public partial class Form1 : Form
    {
        //test
        List<Label> codeRows = new List<Label>();
        List<Label> Breakpoints = new List<Label>();
        List<int> backendFrontendRowConnection = new List<int>();
        bool go = false;
        bool breakpointOccured = false;
        public static float laufzeit = 0;
        public static float period = 1;
        int startRow = 0;
        Backend backend = new Backend();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string temp;
            bool[] tempArray = new bool[8];
            temp = this.sendValueToBackend("Storage");
            if (temp != "Error")
            {
                tempArray = backend.IntToBoolArray(Int32.Parse(temp, System.Globalization.NumberStyles.HexNumber));
                for (int i = 0; i < 8; i++)
                {
                    backend.storage[(e.RowIndex * 8) + (e.ColumnIndex), i] = tempArray[i];
                }
            }

            updateGUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int anz_Zeilen_Datagridview = 32;
            dataGridView1.Rows.Add(anz_Zeilen_Datagridview);
            this.dataGridView1.RowHeadersWidth = 50; //Header width
            for (int i = 0; i < anz_Zeilen_Datagridview; i++)     //Setzen der Headerwerte jeder Zeile
            {

                if (i % 2 == 0)
                {
                    this.dataGridView1.Rows[i].HeaderCell.Value = (i / 2).ToString("X") + "0";
                }
                else
                {
                    this.dataGridView1.Rows[i].HeaderCell.Value = (i / 2).ToString("X") + "8";
                }
            }

            //load 1 to TO and PD
            backend.storage[3, 3]=true;
            backend.storage[3, 4] = true;

            // Initialisierung der Pins
            for (int i = 6; i < 10; i++)
            {
                backend.storage[i, 7] = true;
            }

            for (int i = 0; i < 8; i++)
            {
                backend.storage[129, i] = true;
            }

            //init TRISB
            for (int i = 0; i < 8; i++)
            {
                backend.storage[134, i] = true;
            }

            int anz_Zeilen_Datagridview2 = 15;
            dataGridView2.Rows.Add(anz_Zeilen_Datagridview2);
            this.dataGridView2.RowHeadersWidth = 50; //Header width
            for (int i = 0; i < anz_Zeilen_Datagridview2; i = i + 3)
            {
                switch (i)
                {
                    case 0:
                        this.dataGridView2.Rows[i].HeaderCell.Value = "RA";
                        break;
                    case 3:
                        this.dataGridView2.Rows[i].HeaderCell.Value = "RB";
                        break;
                    case 6:
                        this.dataGridView2.Rows[i].HeaderCell.Value = "RC";
                        break;
                    case 9:
                        this.dataGridView2.Rows[i].HeaderCell.Value = "RD";
                        break;
                    case 12:
                        this.dataGridView2.Rows[i].HeaderCell.Value = "RE";
                        break;
                    default:
                        break;

                }

                this.dataGridView2.Rows[i + 1].HeaderCell.Value = "Tris";
                this.dataGridView2.Rows[i + 2].HeaderCell.Value = "Pin";

                int z = 7;
                for (int j = 0; j < 8; j++)
                {
                    this.dataGridView2[j, i].Value = z.ToString();
                    z--;
                    if (i < 5)
                    {
                        this.dataGridView2[j, i + 1].Value = "i";
                    }
                    else
                    {
                        this.dataGridView2[j, i + 1].Value = "o";
                    }
                    this.dataGridView2[j, i + 2].Value = "0";
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "LST Files (*.lst)|*.lst";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.DefaultExt = "lst";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!String.Equals(Path.GetExtension(openFileDialog1.FileName), ".lst", StringComparison.OrdinalIgnoreCase))
                {           // Invalid file type selected; display an error.
                    MessageBox.Show("Der Typ der ausgewählten Datei wird von dieser Anwendung nicht unterstützt. Sie müssen eine TXT-Datei auswählen.", "Ungültiger Dateityp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // If the file name is not an empty string open it for saving.
                    var lines = File.ReadAllLines(openFileDialog1.FileName);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        Label codeLabel = new Label();
                        Label LblBreakpoint = new Label();
                        Label Zeilennummer = new Label();
                        Label Strich = new Label();
                        Strich.Text = "________________________________________________________________________";
                        Strich.AutoSize = true;
                        Strich.BackColor = Color.Transparent;
                        Strich.Location = new Point(0, 30 * i + 30);
                        LblBreakpoint.Location = new Point(20, 30 * i + 20);
                        Zeilennummer.Location = new Point(40, 30 * i + 20);
                        Zeilennummer.Text = (i + 1).ToString();
                        Zeilennummer.AutoSize = true;
                        LblBreakpoint.Text = "  ";
                        LblBreakpoint.ForeColor = Color.Red;
                        LblBreakpoint.AutoSize = true;
                        LblBreakpoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        codeLabel.Location = new Point(60, 30 * i + 20);
                        codeLabel.Text = lines[i];
                        codeLabel.AutoSize = true;
                        codeRows.Add(codeLabel);
                        Breakpoints.Add(LblBreakpoint);
                        CodePanel.Controls.Add(LblBreakpoint);
                        CodePanel.Controls.Add(Zeilennummer);
                        CodePanel.Controls.Add(codeLabel);
                        CodePanel.Controls.Add(Strich);

                        AddEventhandler(i);
                    }
                    setBackendCode();
                }
            }
            else
            {
                MessageBox.Show("FileDialog konnte nicht geöffnet werden");
            }
        }
        public void setBackendCode()
        {
            bool CodeStarted = false;

            for (int i = 0; i < codeRows.Count(); i++)
            {
                if (codeRows.ElementAt(i).Text.StartsWith("0000"))
                {
                    backend.codeBackend.Add(codeRows.ElementAt(i).Text.Substring(5, 4));
                    backendFrontendRowConnection.Add(i);
                    CodeStarted = true;
                    startRow = i;
                }
                else
                {
                    char testchar = codeRows.ElementAt(i).Text.ElementAt(8);
                    if (CodeStarted && (testchar == '0' || testchar == '1' || testchar == '2' || testchar == '3' || testchar == '4' || testchar == '5' || testchar == '6' || testchar == '7' || testchar == '8' || testchar == '9' || testchar == 'A' || testchar == 'B' || testchar == 'C' || testchar == 'D' || testchar == 'E' || testchar == 'F'))
                    {
                        backend.codeBackend.Add(codeRows.ElementAt(i).Text.Substring(5, 4));
                        backendFrontendRowConnection.Add(i);
                    }
                }
            }

        }
        void AddEventhandler(int i)
        {
            Breakpoints.ElementAt(i).Click += (sender2, e2) => ChangeBreakpoint(sender2, e2, i);
        }

        void ChangeBreakpoint(object sender, EventArgs e, int i)
        {

            if (Breakpoints.ElementAt(i).Text == "  ")
            {
                Breakpoints.ElementAt(i).Text = "⬤";
                backend.breakpoints.Add(i);
            }
            else
            {
                Breakpoints.ElementAt(i).Text = "  ";
                backend.breakpoints.Remove(i);
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            
            if (!go)
            {
                timer1.Start();
                buttonGo.Text = "Pause";
                go = !go;
            }
            else
            {
                buttonGo.Text = "Go";
                go = !go;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "0,00";
            laufzeit = 0;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            float flt1 = float.Parse(textBox1.Text);
            flt1 = flt1 / 4;
            flt1 = 1 / flt1;
            label3.Text = flt1.ToString();
            period = flt1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(go && ((!backend.breakpoints.Contains(backendFrontendRowConnection.ElementAt(backend.backendCurrentRow)))||breakpointOccured))
            {
                breakpointOccured = false;
                next_step();
            }
            else if(go && !breakpointOccured)
            {
                buttonGo.Text = "Go On";
                go = !go;
                breakpointOccured = true;
            }
            else
            {
                //do nothing

            }
        }
        void next_step()
        {
            long wdt_reset_bed = 18000;
            if(backend.storage[129, 3])
            {
                wdt_reset_bed = (18000 * backend.prescaler) / 2;
            }
            if (backend.WatchDogTimer < wdt_reset_bed)
            {
                codeRows.ElementAt(backendFrontendRowConnection.ElementAt(backend.backendCurrentRow)).BackColor = Color.Transparent;

                int timeUnits = backend.next();
                laufzeit += period * timeUnits;
                label1.Text = laufzeit.ToString();
                updateGUI();


                codeRows.ElementAt(backendFrontendRowConnection.ElementAt(backend.backendCurrentRow)).BackColor = Color.LightCoral;
                bool[] temp = new bool[8];
                for (int i = 0; i < 8; i++)
                {
                    temp[i] = backend.storage[6, i];
                }
                backend.RB_prev = temp;
                backend.RA4_prev = backend.storage[5, 4];
            }
            else          //WDT timeout occured
            {
                reset();
            }

            
        }
        void updateGUI()
        {
            bool[] temp = new bool[8];
            for (int i = 0; i < 255; i++)
            {
                for (int ii = 0; ii < 8; ii++)
                {
                    temp[ii] = backend.storage[i, ii];
                }
                string hexValue = FillZero(backend.BoolArrayToIntReverse(temp).ToString("X"));
                dataGridView1[(i % 8), (i / 8)].Value = hexValue;
            }

            lblSFR_WDT.Text = backend.WatchDogTimer.ToString();

            int j = 7;
            for (int i = 0; i < 8; i++)
            {
                //PORT-Register
                if (backend.storage[5 + 128, j] == false)
                {
                    dataGridView2[i, 2].Value = Convert.ToString(Convert.ToInt32(backend.storage[5, j]));
                }
                if (backend.storage[6 + 128, j] == false)
                {
                    dataGridView2[i, 5].Value = Convert.ToString(Convert.ToInt32(backend.storage[6, j]));
                }
                if (backend.storage[7 + 128, j] == false)
                {
                    dataGridView2[i, 8].Value = Convert.ToString(Convert.ToInt32(backend.storage[7, j]));
                }
                if (backend.storage[8 + 128, j] == false)
                {
                    dataGridView2[i, 11].Value = Convert.ToString(Convert.ToInt32(backend.storage[8, j]));
                }
                if (backend.storage[9 + 128, j] == false)
                {
                    dataGridView2[i, 14].Value = Convert.ToString(Convert.ToInt32(backend.storage[9, j]));
                }

                //TRIS-Register
                dataGridView2[i, 1].Value = ConvertToIO(backend.storage[5 + 128, j]);
                dataGridView2[i, 4].Value = ConvertToIO(backend.storage[6 + 128, j]);
                dataGridView2[i, 7].Value = ConvertToIO(backend.storage[7 + 128, j]);
                dataGridView2[i, 10].Value = ConvertToIO(backend.storage[8 + 128, j]);
                dataGridView2[i, 13].Value = ConvertToIO(backend.storage[9 + 128, j]);

                j--;
            }


            // sichtbares SFR-Register
            lblSFR_WREG.Text = FillZero(backend.BoolArrayToIntReverse(backend.WRegister).ToString("X"));
            for (int i = 0; i < 8; i++)
            {
                temp[i] = backend.storage[3, i];
            }
            lblSFR_STATUS.Text = FillZero(backend.BoolArrayToIntReverse(temp).ToString("X"));
            for (int i = 0; i < 8; i++)
            {
                temp[i] = backend.storage[2, i];
            }
            lblSFR_PCL.Text = FillZero(backend.BoolArrayToIntReverse(temp).ToString("X"));
            for (int i = 0; i < 8; i++)
            {
                temp[i] = backend.storage[4, i];
            }
            lblSFR_FSR.Text = FillZero(backend.BoolArrayToIntReverse(temp).ToString("X"));
            for (int i = 0; i < 8; i++)
            {
                temp[i] = backend.storage[10, i];
            }
            lblSFR_PCLATH.Text = FillZero(backend.BoolArrayToIntReverse(temp).ToString("X"));

            // unsichtbares SFR-Register
            for (int i = 0; i < 8; i++)
            {
                temp[i] = backend.storage[2, i];
            }
            lblSFR_PC.Text = "00" + FillZero(backend.BoolArrayToIntReverse(temp).ToString("X"));
            lblSFR_Stackpointer.Text = backend.stackpointer.ToString();


            // STATUS-Register
            lblSFR_C.Text = Convert.ToInt32(backend.storage[3, 0]).ToString();
            lblSFR_DC.Text = Convert.ToInt32(backend.storage[3, 1]).ToString();
            lblSFR_Z.Text = Convert.ToInt32(backend.storage[3, 2]).ToString();
            lblSFR_PD.Text = Convert.ToInt32(backend.storage[3, 3]).ToString();
            lblSFR_TO.Text = Convert.ToInt32(backend.storage[3, 4]).ToString();
            lblSFR_RP0.Text = Convert.ToInt32(backend.storage[3, 5]).ToString();
            lblSFR_RP1.Text = Convert.ToInt32(backend.storage[3, 6]).ToString();
            lblSFR_IRP.Text = Convert.ToInt32(backend.storage[3, 7]).ToString();


            // OPTION-Register
            for (int i = 0; i < 8; i++)
            {
                temp[i] = backend.storage[129, i];
            }
            lblSFR_OPTION.Text = backend.BoolArrayToInt(temp).ToString("X");

            lblSFR_RBP.Text = Convert.ToInt32(backend.storage[129, 7]).ToString();
            lblSFR_IntEdg.Text = Convert.ToInt32(backend.storage[129, 6]).ToString();
            lblSFR_T0CS.Text = Convert.ToInt32(backend.storage[129, 5]).ToString();
            lblSFR_T0SE.Text = Convert.ToInt32(backend.storage[129, 3]).ToString();
            lblSFR_PSA.Text = Convert.ToInt32(backend.storage[129, 3]).ToString();
            lblSFR_PS2.Text = Convert.ToInt32(backend.storage[129, 2]).ToString();
            lblSFR_PS1.Text = Convert.ToInt32(backend.storage[129, 1]).ToString();
            lblSFR_PS0.Text = Convert.ToInt32(backend.storage[129, 0]).ToString();

            // INTCON-Register
            for (int i = 0; i < 8; i++)
            {
                temp[i] = backend.storage[11, i];
            }
            lblSFR_INTCON.Text = backend.BoolArrayToInt(temp).ToString("X");

            lblSFR_GIE.Text = Convert.ToInt32(backend.storage[11, 7]).ToString();
            lblSFR_PIE.Text = Convert.ToInt32(backend.storage[11, 6]).ToString();
            lblSFR_T0IE.Text = Convert.ToInt32(backend.storage[11, 5]).ToString();
            lblSFR_INTE.Text = Convert.ToInt32(backend.storage[11, 4]).ToString();
            lblSFR_RBIE.Text = Convert.ToInt32(backend.storage[11, 3]).ToString();
            lblSFR_T0IF.Text = Convert.ToInt32(backend.storage[11, 2]).ToString();
            lblSFR_INTF.Text = Convert.ToInt32(backend.storage[11, 1]).ToString();
            lblSFR_RBIF.Text = Convert.ToInt32(backend.storage[11, 0]).ToString();

            // Update Stack Visualisierung
            lbl_Stack0.Text = backend.calls.ElementAtOrDefault(0).ToString();
            lbl_Stack1.Text = backend.calls.ElementAtOrDefault(1).ToString();
            lbl_Stack2.Text = backend.calls.ElementAtOrDefault(2).ToString();
            lbl_Stack3.Text = backend.calls.ElementAtOrDefault(3).ToString();
            lbl_Stack4.Text = backend.calls.ElementAtOrDefault(4).ToString();
            lbl_Stack5.Text = backend.calls.ElementAtOrDefault(5).ToString();
            lbl_Stack6.Text = backend.calls.ElementAtOrDefault(6).ToString();
            lbl_Stack7.Text = backend.calls.ElementAtOrDefault(7).ToString();

        }

        private void buttonStepIn_Click(object sender, EventArgs e)
        {
            buttonGo.Text = "Go";
            next_step();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void lblSFR_PCL_Click(object sender, EventArgs e)
        {
            string temp;
            bool[] tempArray = new bool[8];
            temp = this.sendValueToBackend("PCL");
            if (temp != "Error")
            {
                tempArray = backend.IntToBoolArray(Int32.Parse(temp, System.Globalization.NumberStyles.HexNumber));
                for (int i = 0; i < 7; i++)
                {
                    backend.storage[2, i] = tempArray[i];
                }
                updateGUI();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        public void reset()
        {
            backend.sleeping = false;
            backend.WatchDogTimer = 0;
            //load 1 to TO and PD
            backend.storage[3, 3] = true;
            backend.storage[3, 4] = true;

            // Initialisierung des WRegisters
            for (int i = 0; i < 8; i++)
            {
                backend.WRegister[i] = false;
            }

            // Initialisierung des Storage
            for (int i = 0; i < 256; i++)
            {
                for (int ii = 0; ii < 8; ii++)
                {
                    backend.storage[i, ii] = false;
                }
            }

            // Setzen der initialen Pins
            for (int i = 6; i < 10; i++)
            {
                backend.storage[i, 7] = true;
            }
            // Initialisierung des OPTION-Registers
            for (int i = 0; i < 8; i++)
            {
                backend.storage[129, i] = true;
            }
            // Initialisierung DataLetch
            for (int i = 0; i < backend.dataLetch.Length; i++)
            {
                backend.dataLetch[i / 8, i % 8] = false;
            }

            // Zurücksetzen des Stackpointers
            backend.stackpointer = 0;

            codeRows.ElementAt(backendFrontendRowConnection.ElementAt(backend.backendCurrentRow)).BackColor = Color.Transparent;
            backend.calls.Clear();
            backend.backendCurrentRow = 0;
            backend.WatchDogTimer = 0;
            updateGUI();
        }
        // Umstellen der PINS zwischen 1 und 0
        private void datagridview2_onCellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = (string)this.dataGridView2[e.ColumnIndex, e.RowIndex].Value;


            if (value == "0")
            {
                setPin(e.RowIndex, e.ColumnIndex, true);
                this.dataGridView2[e.ColumnIndex, e.RowIndex].Value = "1";
            }
            if (value == "1")
            {
                setPin(e.RowIndex, e.ColumnIndex, false);
                this.dataGridView2[e.ColumnIndex, e.RowIndex].Value = "0";
            }

            updateGUI();
        }

        // Setzen des PINS im Backend
        private void setPin(int row, int col, bool value)
        {
            int port = (row / 3) + 5;
            int bit = 7 - col;

            backend.storage[port, bit] = value;
        }

        // Umwandlung Bool-Wert zu i oder o
        private string ConvertToIO(bool input)
        {
            if (input)
            {
                return "i";
            }
            else
            {
                return "o";
            }
        }

        private string FillZero(string input)
        {
            string output;

            if (input.Length == 1)
            {
                output = "0" + input;
            }
            else
            {
                output = input;
            }

            return output;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblSFR_WREG_Click(object sender, EventArgs e)
        {
            string temp;
            temp = this.sendValueToBackend("W-Register");
            if (temp != "Error")
            {
                backend.WRegister = backend.IntToBoolArray(Int32.Parse(temp, System.Globalization.NumberStyles.HexNumber));
                updateGUI();
            }
        }

        private string sendValueToBackend(string input)
        {
            string answer = "Error";
            using (var frm = new EingabeFenster(input))
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    answer = frm.ReturnValue;

                }
            }
            return answer;
        }

        public string getValueFromEingabe(string input)
        {
            return input;
        }

        private void lblSFR_FSR_Click(object sender, EventArgs e)
        {
            string temp;
            bool[] tempArray = new bool[8];
            temp = this.sendValueToBackend("FSR");
            if (temp != "Error")
            {
                tempArray = backend.IntToBoolArray(Int32.Parse(temp, System.Globalization.NumberStyles.HexNumber));
                for (int i = 0; i < 7; i++)
                { 
                    backend.storage[4,i] = tempArray[i];
                }
                updateGUI();
            }
        }

        private void lblSFR_STATUS_Click(object sender, EventArgs e)
        {
            string temp;
            bool[] tempArray = new bool[8];
            temp = this.sendValueToBackend("Status");
            if (temp != "Error")
            {
                tempArray = backend.IntToBoolArray(Int32.Parse(temp, System.Globalization.NumberStyles.HexNumber));
                for (int i = 0; i < 7; i++)
                {
                    backend.storage[3, i] = tempArray[i];
                    backend.storage[3 + 128, i] = tempArray[i];
                }
                updateGUI();
            }
        }

        private void lblSFR_PCLATH_Click(object sender, EventArgs e)
        {
            string temp;
            bool[] tempArray = new bool[8];
            temp = this.sendValueToBackend("PCLATH");
            if (temp != "Error")
            {
                tempArray = backend.IntToBoolArray(Int32.Parse(temp, System.Globalization.NumberStyles.HexNumber));
                for (int i = 0; i < 7; i++)
                {
                    backend.storage[10, i] = tempArray[i];
                }
                updateGUI();
            }
        }

        private void lblSFR_C_Click(object sender, EventArgs e)
        {
            if (lblSFR_C.Text == "0")
            {
                backend.storage[3, 0] = true;
                backend.storage[3 + 128, 0] = true;
            }
            else
            {
                backend.storage[3, 0] = false;
                backend.storage[3 + 128, 0] = false;
            }
            updateGUI();
        }

        private void lblSFR_DC_Click(object sender, EventArgs e)
        {
            if (lblSFR_DC.Text == "0")
            {
                backend.storage[3, 1] = true;
                backend.storage[3 + 128, 1] = true;
            }
            else
            {
                backend.storage[3, 1] = false;
                backend.storage[3 + 128, 1] = false;
            }
            updateGUI();
        }

        private void lblSFR_Z_Click(object sender, EventArgs e)
        {
            if (lblSFR_Z.Text == "0")
            {
                backend.storage[3, 2] = true;
                backend.storage[3 + 128, 2] = true;
            }
            else
            {
                backend.storage[3, 2] = false;
                backend.storage[3 + 128, 2] = false;
            }
            updateGUI();
        }

        private void lblSFR_PD_Click(object sender, EventArgs e)
        {
            if (lblSFR_PD.Text == "0")
            {
                backend.storage[3, 3] = true;
                backend.storage[3 + 128, 3] = true;
            }
            else
            {
                backend.storage[3, 3] = false;
                backend.storage[3 + 128, 3] = false;
            }
            updateGUI();
        }

        private void lblSFR_TO_Click(object sender, EventArgs e)
        {
            if (lblSFR_TO.Text == "0")
            {
                backend.storage[3, 4] = true;
                backend.storage[3 + 128, 4] = true;
            }
            else
            {
                backend.storage[3, 4] = false;
                backend.storage[3 + 128, 4] = false;
            }
            updateGUI();
        }

        private void lblSFR_RP0_Click(object sender, EventArgs e)
        {
            if (lblSFR_RP0.Text == "0")
            {
                backend.storage[3, 5] = true;
                backend.storage[3 + 128, 5] = true;
            }
            else
            {
                backend.storage[3, 5] = false;
                backend.storage[3 + 128, 5] = false;
            }
            updateGUI();
        }

        private void lblSFR_RP1_Click(object sender, EventArgs e)
        {
            if (lblSFR_RP1.Text == "0")
            {
                backend.storage[3, 6] = true;
                backend.storage[3 + 128, 6] = true;
            }
            else
            {
                backend.storage[3, 6] = false;
                backend.storage[3 + 128, 6] = false;
            }
            updateGUI();
        }

        private void lblSFR_IRP_Click(object sender, EventArgs e)
        {
            if (lblSFR_Z.Text == "0")
            {
                backend.storage[3, 7] = true;
                backend.storage[3 + 128, 7] = true;
            }
            else
            {
                backend.storage[3, 7] = false;
                backend.storage[3 + 128, 7] = false;
            }
            updateGUI();
        }

        private void cbSFR_WDTE_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSFR_WDTE.Checked)
            {
                backend.WDTE = true;
                lblSFR_WDT.Visible = true;
                label45.Visible = true;
            }
            else
            {
                backend.WDTE = false;
                lblSFR_WDT.Visible = false;
                label45.Visible = true;
            }
        }
    }
}
