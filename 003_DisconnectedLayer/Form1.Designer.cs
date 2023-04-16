namespace _003_DisconnectedLayer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Query = new System.Windows.Forms.TextBox();
            this.dataGridView_Results = new System.Windows.Forms.DataGridView();
            this.button_Execute = new System.Windows.Forms.Button();
            this.button_ExecDataSet = new System.Windows.Forms.Button();
            this.comboBox_selectDB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Results)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Query
            // 
            this.textBox_Query.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Query.Location = new System.Drawing.Point(13, 13);
            this.textBox_Query.Multiline = true;
            this.textBox_Query.Name = "textBox_Query";
            this.textBox_Query.Size = new System.Drawing.Size(664, 83);
            this.textBox_Query.TabIndex = 0;
            // 
            // dataGridView_Results
            // 
            this.dataGridView_Results.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Results.Location = new System.Drawing.Point(13, 103);
            this.dataGridView_Results.Name = "dataGridView_Results";
            this.dataGridView_Results.ReadOnly = true;
            this.dataGridView_Results.Size = new System.Drawing.Size(664, 335);
            this.dataGridView_Results.TabIndex = 1;
            // 
            // button_Execute
            // 
            this.button_Execute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Execute.Location = new System.Drawing.Point(684, 103);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(135, 63);
            this.button_Execute.TabIndex = 2;
            this.button_Execute.Text = "Fill DataTable";
            this.button_Execute.UseVisualStyleBackColor = true;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // button_ExecDataSet
            // 
            this.button_ExecDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ExecDataSet.Location = new System.Drawing.Point(684, 172);
            this.button_ExecDataSet.Name = "button_ExecDataSet";
            this.button_ExecDataSet.Size = new System.Drawing.Size(135, 64);
            this.button_ExecDataSet.TabIndex = 3;
            this.button_ExecDataSet.Text = "Fill DataSet";
            this.button_ExecDataSet.UseVisualStyleBackColor = true;
            this.button_ExecDataSet.Click += new System.EventHandler(this.button_ExecDataSet_Click);
            // 
            // comboBox_selectDB
            // 
            this.comboBox_selectDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox_selectDB.FormattingEnabled = true;
            this.comboBox_selectDB.Location = new System.Drawing.Point(684, 13);
            this.comboBox_selectDB.Name = "comboBox_selectDB";
            this.comboBox_selectDB.Size = new System.Drawing.Size(135, 28);
            this.comboBox_selectDB.TabIndex = 4;
            this.comboBox_selectDB.Text = "Select table";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.comboBox_selectDB);
            this.Controls.Add(this.button_ExecDataSet);
            this.Controls.Add(this.button_Execute);
            this.Controls.Add(this.dataGridView_Results);
            this.Controls.Add(this.textBox_Query);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiconnectedLayer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Results)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Query;
        private System.Windows.Forms.DataGridView dataGridView_Results;
        private System.Windows.Forms.Button button_Execute;
        private System.Windows.Forms.Button button_ExecDataSet;
        private System.Windows.Forms.ComboBox comboBox_selectDB;
    }
}

