﻿namespace PicSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Col0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodePanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.buttonStepIn = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblSFR_C = new System.Windows.Forms.Label();
            this.lblSFR_DC = new System.Windows.Forms.Label();
            this.lblSFR_Z = new System.Windows.Forms.Label();
            this.lblSFR_PD = new System.Windows.Forms.Label();
            this.lblSFR_TO = new System.Windows.Forms.Label();
            this.lblSFR_RP0 = new System.Windows.Forms.Label();
            this.lblSFR_RP1 = new System.Windows.Forms.Label();
            this.lblSFR_IRP = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSFR_WREG = new System.Windows.Forms.Label();
            this.lblSFR_FSR = new System.Windows.Forms.Label();
            this.lblSFR_PCL = new System.Windows.Forms.Label();
            this.lblSFR_PCLATH = new System.Windows.Forms.Label();
            this.lblSFR_STATUS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col0,
            this.Col1,
            this.Col2,
            this.Col3,
            this.Col4,
            this.Col5,
            this.Col6,
            this.Col7});
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(413, 470);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Col0
            // 
            this.Col0.HeaderText = "00";
            this.Col0.MinimumWidth = 6;
            this.Col0.Name = "Col0";
            this.Col0.ReadOnly = true;
            this.Col0.Width = 30;
            // 
            // Col1
            // 
            this.Col1.HeaderText = "01";
            this.Col1.MinimumWidth = 6;
            this.Col1.Name = "Col1";
            this.Col1.ReadOnly = true;
            this.Col1.Width = 30;
            // 
            // Col2
            // 
            this.Col2.HeaderText = "02";
            this.Col2.MinimumWidth = 6;
            this.Col2.Name = "Col2";
            this.Col2.ReadOnly = true;
            this.Col2.Width = 30;
            // 
            // Col3
            // 
            this.Col3.HeaderText = "03";
            this.Col3.MinimumWidth = 6;
            this.Col3.Name = "Col3";
            this.Col3.ReadOnly = true;
            this.Col3.Width = 30;
            // 
            // Col4
            // 
            this.Col4.HeaderText = "04";
            this.Col4.MinimumWidth = 6;
            this.Col4.Name = "Col4";
            this.Col4.ReadOnly = true;
            this.Col4.Width = 30;
            // 
            // Col5
            // 
            this.Col5.HeaderText = "05";
            this.Col5.MinimumWidth = 6;
            this.Col5.Name = "Col5";
            this.Col5.ReadOnly = true;
            this.Col5.Width = 30;
            // 
            // Col6
            // 
            this.Col6.HeaderText = "06";
            this.Col6.MinimumWidth = 6;
            this.Col6.Name = "Col6";
            this.Col6.ReadOnly = true;
            this.Col6.Width = 30;
            // 
            // Col7
            // 
            this.Col7.HeaderText = "07";
            this.Col7.MinimumWidth = 6;
            this.Col7.Name = "Col7";
            this.Col7.ReadOnly = true;
            this.Col7.Width = 30;
            // 
            // CodePanel
            // 
            this.CodePanel.AutoScroll = true;
            this.CodePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CodePanel.Location = new System.Drawing.Point(442, 41);
            this.CodePanel.Name = "CodePanel";
            this.CodePanel.Size = new System.Drawing.Size(580, 470);
            this.CodePanel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Öffnen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(17, 57);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 4;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // buttonStepIn
            // 
            this.buttonStepIn.Location = new System.Drawing.Point(17, 86);
            this.buttonStepIn.Name = "buttonStepIn";
            this.buttonStepIn.Size = new System.Drawing.Size(75, 23);
            this.buttonStepIn.TabIndex = 5;
            this.buttonStepIn.Text = "Step In";
            this.buttonStepIn.UseVisualStyleBackColor = true;
            this.buttonStepIn.Click += new System.EventHandler(this.buttonStepIn_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(17, 28);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonStepIn);
            this.groupBox1.Controls.Add(this.buttonGo);
            this.groupBox1.Location = new System.Drawing.Point(1042, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 121);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Steuerpult";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(1042, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Laufzeit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "µs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "0,00";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "zurücksetzen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(1167, 274);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 100);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quarzfrequenz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "µs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "1,00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "MHz";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "4,000";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.lblSFR_C);
            this.groupBox4.Controls.Add(this.lblSFR_DC);
            this.groupBox4.Controls.Add(this.lblSFR_Z);
            this.groupBox4.Controls.Add(this.lblSFR_PD);
            this.groupBox4.Controls.Add(this.lblSFR_TO);
            this.groupBox4.Controls.Add(this.lblSFR_RP0);
            this.groupBox4.Controls.Add(this.lblSFR_RP1);
            this.groupBox4.Controls.Add(this.lblSFR_IRP);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(13, 518);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(412, 213);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SFR";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "IRP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "RP1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "RP0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(126, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "TO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(160, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "PD";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "Z";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(216, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "DC";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(249, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 17);
            this.label13.TabIndex = 18;
            this.label13.Text = "C";
            // 
            // lblSFR_C
            // 
            this.lblSFR_C.AutoSize = true;
            this.lblSFR_C.Location = new System.Drawing.Point(249, 187);
            this.lblSFR_C.Name = "lblSFR_C";
            this.lblSFR_C.Size = new System.Drawing.Size(16, 17);
            this.lblSFR_C.TabIndex = 26;
            this.lblSFR_C.Text = "0";
            // 
            // lblSFR_DC
            // 
            this.lblSFR_DC.AutoSize = true;
            this.lblSFR_DC.Location = new System.Drawing.Point(216, 187);
            this.lblSFR_DC.Name = "lblSFR_DC";
            this.lblSFR_DC.Size = new System.Drawing.Size(16, 17);
            this.lblSFR_DC.TabIndex = 25;
            this.lblSFR_DC.Text = "0";
            // 
            // lblSFR_Z
            // 
            this.lblSFR_Z.AutoSize = true;
            this.lblSFR_Z.Location = new System.Drawing.Point(193, 187);
            this.lblSFR_Z.Name = "lblSFR_Z";
            this.lblSFR_Z.Size = new System.Drawing.Size(16, 17);
            this.lblSFR_Z.TabIndex = 24;
            this.lblSFR_Z.Text = "0";
            // 
            // lblSFR_PD
            // 
            this.lblSFR_PD.AutoSize = true;
            this.lblSFR_PD.Location = new System.Drawing.Point(160, 187);
            this.lblSFR_PD.Name = "lblSFR_PD";
            this.lblSFR_PD.Size = new System.Drawing.Size(16, 17);
            this.lblSFR_PD.TabIndex = 23;
            this.lblSFR_PD.Text = "0";
            // 
            // lblSFR_TO
            // 
            this.lblSFR_TO.AutoSize = true;
            this.lblSFR_TO.Location = new System.Drawing.Point(126, 187);
            this.lblSFR_TO.Name = "lblSFR_TO";
            this.lblSFR_TO.Size = new System.Drawing.Size(16, 17);
            this.lblSFR_TO.TabIndex = 22;
            this.lblSFR_TO.Text = "0";
            // 
            // lblSFR_RP0
            // 
            this.lblSFR_RP0.AutoSize = true;
            this.lblSFR_RP0.Location = new System.Drawing.Point(85, 187);
            this.lblSFR_RP0.Name = "lblSFR_RP0";
            this.lblSFR_RP0.Size = new System.Drawing.Size(16, 17);
            this.lblSFR_RP0.TabIndex = 21;
            this.lblSFR_RP0.Text = "0";
            // 
            // lblSFR_RP1
            // 
            this.lblSFR_RP1.AutoSize = true;
            this.lblSFR_RP1.Location = new System.Drawing.Point(44, 187);
            this.lblSFR_RP1.Name = "lblSFR_RP1";
            this.lblSFR_RP1.Size = new System.Drawing.Size(16, 17);
            this.lblSFR_RP1.TabIndex = 20;
            this.lblSFR_RP1.Text = "0";
            // 
            // lblSFR_IRP
            // 
            this.lblSFR_IRP.AutoSize = true;
            this.lblSFR_IRP.Location = new System.Drawing.Point(6, 187);
            this.lblSFR_IRP.Name = "lblSFR_IRP";
            this.lblSFR_IRP.Size = new System.Drawing.Size(16, 17);
            this.lblSFR_IRP.TabIndex = 19;
            this.lblSFR_IRP.Text = "0";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblSFR_STATUS);
            this.groupBox5.Controls.Add(this.lblSFR_PCLATH);
            this.groupBox5.Controls.Add(this.lblSFR_PCL);
            this.groupBox5.Controls.Add(this.lblSFR_FSR);
            this.groupBox5.Controls.Add(this.lblSFR_WREG);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Location = new System.Drawing.Point(6, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 146);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "sichtbar";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "W-REG";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "FSR";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 17);
            this.label16.TabIndex = 2;
            this.label16.Text = "PCL";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 17);
            this.label17.TabIndex = 3;
            this.label17.Text = "PCLATH";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 90);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 17);
            this.label18.TabIndex = 4;
            this.label18.Text = "STATUS";
            // 
            // lblSFR_WREG
            // 
            this.lblSFR_WREG.AutoSize = true;
            this.lblSFR_WREG.Location = new System.Drawing.Point(105, 22);
            this.lblSFR_WREG.Name = "lblSFR_WREG";
            this.lblSFR_WREG.Size = new System.Drawing.Size(24, 17);
            this.lblSFR_WREG.TabIndex = 5;
            this.lblSFR_WREG.Text = "00";
            // 
            // lblSFR_FSR
            // 
            this.lblSFR_FSR.AutoSize = true;
            this.lblSFR_FSR.Location = new System.Drawing.Point(105, 39);
            this.lblSFR_FSR.Name = "lblSFR_FSR";
            this.lblSFR_FSR.Size = new System.Drawing.Size(24, 17);
            this.lblSFR_FSR.TabIndex = 6;
            this.lblSFR_FSR.Text = "00";
            // 
            // lblSFR_PCL
            // 
            this.lblSFR_PCL.AutoSize = true;
            this.lblSFR_PCL.Location = new System.Drawing.Point(105, 56);
            this.lblSFR_PCL.Name = "lblSFR_PCL";
            this.lblSFR_PCL.Size = new System.Drawing.Size(24, 17);
            this.lblSFR_PCL.TabIndex = 7;
            this.lblSFR_PCL.Text = "00";
            // 
            // lblSFR_PCLATH
            // 
            this.lblSFR_PCLATH.AutoSize = true;
            this.lblSFR_PCLATH.Location = new System.Drawing.Point(105, 73);
            this.lblSFR_PCLATH.Name = "lblSFR_PCLATH";
            this.lblSFR_PCLATH.Size = new System.Drawing.Size(24, 17);
            this.lblSFR_PCLATH.TabIndex = 8;
            this.lblSFR_PCLATH.Text = "00";
            // 
            // lblSFR_STATUS
            // 
            this.lblSFR_STATUS.AutoSize = true;
            this.lblSFR_STATUS.Location = new System.Drawing.Point(105, 90);
            this.lblSFR_STATUS.Name = "lblSFR_STATUS";
            this.lblSFR_STATUS.Size = new System.Drawing.Size(24, 17);
            this.lblSFR_STATUS.TabIndex = 9;
            this.lblSFR_STATUS.Text = "00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 743);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CodePanel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col7;
        private System.Windows.Forms.Panel CodePanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonStepIn;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblSFR_C;
        private System.Windows.Forms.Label lblSFR_DC;
        private System.Windows.Forms.Label lblSFR_Z;
        private System.Windows.Forms.Label lblSFR_PD;
        private System.Windows.Forms.Label lblSFR_TO;
        private System.Windows.Forms.Label lblSFR_RP0;
        private System.Windows.Forms.Label lblSFR_RP1;
        private System.Windows.Forms.Label lblSFR_IRP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblSFR_STATUS;
        private System.Windows.Forms.Label lblSFR_PCLATH;
        private System.Windows.Forms.Label lblSFR_PCL;
        private System.Windows.Forms.Label lblSFR_FSR;
        private System.Windows.Forms.Label lblSFR_WREG;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}

