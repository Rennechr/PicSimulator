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
        List<Label> codeRows = new List<Label>();
        List<Label> Breakpoints = new List<Label>();
        List<int> backendFrontendRowConnection = new List<int>();
        bool go = false;
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
                        Zeilennummer.Text = (i+1).ToString();
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
            if (go)
            {
                buttonGo.Text = "Go";
                go = !go;
            }
            else
            {
                timer1.Start();
                buttonGo.Text = "Pause";
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
            if(go && !backend.breakpoints.Contains(backend.backendCurrentRow))
            {
                next_step();
            }
            else
            {
                //do nothing
            }
        }
        void next_step()
        {
            
            laufzeit += period;
            label1.Text = laufzeit.ToString();  //todo Laufzeittimer vom Backend updaten je nach befehl
            codeRows.ElementAt(backendFrontendRowConnection.ElementAt(backend.backendCurrentRow)).BackColor = Color.Transparent;
            backend.next();
            codeRows.ElementAt(backendFrontendRowConnection.ElementAt(backend.backendCurrentRow)).BackColor = Color.LightCoral;




        }

        private void buttonStepIn_Click(object sender, EventArgs e)
        {
            next_step();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
