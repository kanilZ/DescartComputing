﻿namespace DescartComputing
{
    partial class Input
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridCoords = new System.Windows.Forms.DataGridView();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridMatrix = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownXY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.labelSin = new System.Windows.Forms.Label();
            this.labelCos = new System.Windows.Forms.Label();
            this.textBoxSin = new System.Windows.Forms.TextBox();
            this.textBoxCos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCoords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXY)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCoords
            // 
            this.dataGridCoords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCoords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x,
            this.y,
            this.Z,
            this.h});
            this.dataGridCoords.Location = new System.Drawing.Point(12, 42);
            this.dataGridCoords.Name = "dataGridCoords";
            this.dataGridCoords.RowHeadersWidth = 51;
            this.dataGridCoords.RowTemplate.Height = 24;
            this.dataGridCoords.Size = new System.Drawing.Size(312, 303);
            this.dataGridCoords.TabIndex = 0;
            // 
            // x
            // 
            this.x.HeaderText = "X";
            this.x.MinimumWidth = 6;
            this.x.Name = "x";
            this.x.Width = 40;
            // 
            // y
            // 
            this.y.HeaderText = "Y";
            this.y.MinimumWidth = 6;
            this.y.Name = "y";
            this.y.Width = 40;
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.MinimumWidth = 6;
            this.Z.Name = "Z";
            this.Z.Visible = false;
            this.Z.Width = 40;
            // 
            // h
            // 
            this.h.HeaderText = "H";
            this.h.MinimumWidth = 6;
            this.h.Name = "h";
            this.h.Visible = false;
            this.h.Width = 40;
            // 
            // dataGridMatrix
            // 
            this.dataGridMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMatrix.Location = new System.Drawing.Point(497, 42);
            this.dataGridMatrix.Name = "dataGridMatrix";
            this.dataGridMatrix.RowHeadersWidth = 51;
            this.dataGridMatrix.RowTemplate.Height = 24;
            this.dataGridMatrix.Size = new System.Drawing.Size(291, 303);
            this.dataGridMatrix.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Координати";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Матриця перетворень";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Підтвердити";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(604, 352);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(85, 22);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(494, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Розмірність";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Розмірність";
            // 
            // numericUpDownXY
            // 
            this.numericUpDownXY.Location = new System.Drawing.Point(121, 352);
            this.numericUpDownXY.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownXY.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownXY.Name = "numericUpDownXY";
            this.numericUpDownXY.Size = new System.Drawing.Size(85, 22);
            this.numericUpDownXY.TabIndex = 8;
            this.numericUpDownXY.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownXY.ValueChanged += new System.EventHandler(this.numericUpDownXY_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Дистанція";
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(409, 39);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(61, 22);
            this.textBoxDistance.TabIndex = 10;
            this.textBoxDistance.Text = "1";
            // 
            // labelSin
            // 
            this.labelSin.AutoSize = true;
            this.labelSin.Location = new System.Drawing.Point(330, 73);
            this.labelSin.Name = "labelSin";
            this.labelSin.Size = new System.Drawing.Size(63, 17);
            this.labelSin.TabIndex = 11;
            this.labelSin.Text = "Sin (кут)";
            // 
            // labelCos
            // 
            this.labelCos.AutoSize = true;
            this.labelCos.Location = new System.Drawing.Point(330, 103);
            this.labelCos.Name = "labelCos";
            this.labelCos.Size = new System.Drawing.Size(67, 17);
            this.labelCos.TabIndex = 12;
            this.labelCos.Text = "Cos (кут)";
            // 
            // textBoxSin
            // 
            this.textBoxSin.Location = new System.Drawing.Point(409, 70);
            this.textBoxSin.Name = "textBoxSin";
            this.textBoxSin.Size = new System.Drawing.Size(61, 22);
            this.textBoxSin.TabIndex = 13;
            this.textBoxSin.Text = "0";
            // 
            // textBoxCos
            // 
            this.textBoxCos.Location = new System.Drawing.Point(409, 100);
            this.textBoxCos.Name = "textBoxCos";
            this.textBoxCos.Size = new System.Drawing.Size(61, 22);
            this.textBoxCos.TabIndex = 14;
            this.textBoxCos.Text = "0";
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxCos);
            this.Controls.Add(this.textBoxSin);
            this.Controls.Add(this.labelCos);
            this.Controls.Add(this.labelSin);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownXY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridMatrix);
            this.Controls.Add(this.dataGridCoords);
            this.Name = "Input";
            this.Text = "Input";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCoords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridCoords;
        private System.Windows.Forms.DataGridView dataGridMatrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownXY;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn h;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Label labelSin;
        private System.Windows.Forms.Label labelCos;
        private System.Windows.Forms.TextBox textBoxSin;
        private System.Windows.Forms.TextBox textBoxCos;
    }
}