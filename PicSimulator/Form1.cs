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
        public static List<Label> codeRows = new List<Label>();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CodePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "TXT Files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.DefaultExt = "txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!String.Equals(Path.GetExtension(openFileDialog1.FileName), ".txt", StringComparison.OrdinalIgnoreCase))
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
                        codeLabel.Location = new Point(20, 30 * i + 20);
                        codeLabel.Text = lines[i];
                        codeLabel.AutoSize = true;
                        codeRows.Add(codeLabel);
                        CodePanel.Controls.Add(codeLabel);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("FileDialog konnte nicht geöffnet werden");
            }
        } 
    }
}
