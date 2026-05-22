namespace SLHDotNetInternshipTraining.WinFormsAppSample
{
    partial class FrmBlog
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
            btnSave = new Button();
            label1 = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            label2 = new Label();
            label3 = new Label();
            bntCancel = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(375, 278);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 0;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(126, 47);
            label1.Name = "label1";
            label1.Size = new Size(60, 32);
            label1.TabIndex = 1;
            label1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(230, 44);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(321, 39);
            txtTitle.TabIndex = 2;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(230, 121);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(321, 39);
            txtAuthor.TabIndex = 3;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(230, 198);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(321, 39);
            txtContent.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 124);
            label2.Name = "label2";
            label2.Size = new Size(87, 32);
            label2.TabIndex = 5;
            label2.Text = "Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 201);
            label3.Name = "label3";
            label3.Size = new Size(100, 32);
            label3.TabIndex = 6;
            label3.Text = "Content";
            // 
            // bntCancel
            // 
            bntCancel.Location = new Point(219, 278);
            bntCancel.Name = "bntCancel";
            bntCancel.Size = new Size(150, 46);
            bntCancel.TabIndex = 7;
            bntCancel.Text = "&Cancel";
            bntCancel.UseVisualStyleBackColor = true;
            bntCancel.Click += bntCancel_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 375);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(728, 343);
            dataGridView1.TabIndex = 8;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 730);
            Controls.Add(dataGridView1);
            Controls.Add(bntCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            Load += FrmBlog_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Label label1;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Label label2;
        private Label label3;
        private Button bntCancel;
        private DataGridView dataGridView1;
    }
}