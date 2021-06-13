using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicSimulator
{
    public partial class EingabeFenster : Form
    {
        public string value = "Error";
        public string ReturnValue {get; set;}

        public EingabeFenster(string input)
        {
            InitializeComponent();
            this.value = input;
            this.label1.Text = (input + ":");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxValid(this.textBox1.Text)) 
            { 
                this.ReturnValue = this.textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool textBoxValid(string input)
        {
            bool valid = true;
            if (!(input.Length == 2))
            {
                valid = false;
            }
            else
            {
                if (!(input.ElementAt(0) == '0' ||
                      input.ElementAt(0) == '1' ||
                      input.ElementAt(0) == '2' ||
                      input.ElementAt(0) == '3' ||
                      input.ElementAt(0) == '4' ||
                      input.ElementAt(0) == '5' ||
                      input.ElementAt(0) == '6' ||
                      input.ElementAt(0) == '7' ||
                      input.ElementAt(0) == '8' ||
                      input.ElementAt(0) == '9' ||
                      input.ElementAt(0) == 'A' ||
                      input.ElementAt(0) == 'B' ||
                      input.ElementAt(0) == 'C' ||
                      input.ElementAt(0) == 'D' ||
                      input.ElementAt(0) == 'E' ||
                      input.ElementAt(0) == 'F'))
                {
                    valid = false;
                }
                if (!(input.ElementAt(1) == '0' ||
                      input.ElementAt(1) == '1' ||
                      input.ElementAt(1) == '2' ||
                      input.ElementAt(1) == '3' ||
                      input.ElementAt(1) == '4' ||
                      input.ElementAt(1) == '5' ||
                      input.ElementAt(1) == '6' ||
                      input.ElementAt(1) == '7' ||
                      input.ElementAt(1) == '8' ||
                      input.ElementAt(1) == '9' ||
                      input.ElementAt(1) == 'A' ||
                      input.ElementAt(1) == 'B' ||
                      input.ElementAt(1) == 'C' ||
                      input.ElementAt(1) == 'D' ||
                      input.ElementAt(1) == 'E' ||
                      input.ElementAt(1) == 'F'))
                {
                    valid = false;
                }
            }
            return valid;
        }
    }
}
