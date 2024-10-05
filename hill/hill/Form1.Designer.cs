namespace hill
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_BanRo = new System.Windows.Forms.TextBox();
            this.txt_BanMa = new System.Windows.Forms.TextBox();
            this.txt_Khoa = new System.Windows.Forms.TextBox();
            this.btn_MaHoa = new System.Windows.Forms.Button();
            this.btn_GiaiMa = new System.Windows.Forms.Button();
            this.txt_L = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bản rõ P";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bản mã C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Khóa L";
            // 
            // txt_BanRo
            // 
            this.txt_BanRo.Location = new System.Drawing.Point(251, 69);
            this.txt_BanRo.Multiline = true;
            this.txt_BanRo.Name = "txt_BanRo";
            this.txt_BanRo.Size = new System.Drawing.Size(407, 112);
            this.txt_BanRo.TabIndex = 3;
            // 
            // txt_BanMa
            // 
            this.txt_BanMa.Location = new System.Drawing.Point(251, 201);
            this.txt_BanMa.Multiline = true;
            this.txt_BanMa.Name = "txt_BanMa";
            this.txt_BanMa.Size = new System.Drawing.Size(407, 133);
            this.txt_BanMa.TabIndex = 4;
            // 
            // txt_Khoa
            // 
            this.txt_Khoa.Location = new System.Drawing.Point(323, 389);
            this.txt_Khoa.Multiline = true;
            this.txt_Khoa.Name = "txt_Khoa";
            this.txt_Khoa.Size = new System.Drawing.Size(335, 123);
            this.txt_Khoa.TabIndex = 5;
            // 
            // btn_MaHoa
            // 
            this.btn_MaHoa.Location = new System.Drawing.Point(789, 314);
            this.btn_MaHoa.Name = "btn_MaHoa";
            this.btn_MaHoa.Size = new System.Drawing.Size(75, 69);
            this.btn_MaHoa.TabIndex = 6;
            this.btn_MaHoa.Text = "Mã hóa";
            this.btn_MaHoa.UseVisualStyleBackColor = true;
            this.btn_MaHoa.Click += new System.EventHandler(this.btn_MaHoa_Click);
            // 
            // btn_GiaiMa
            // 
            this.btn_GiaiMa.Location = new System.Drawing.Point(789, 403);
            this.btn_GiaiMa.Name = "btn_GiaiMa";
            this.btn_GiaiMa.Size = new System.Drawing.Size(75, 79);
            this.btn_GiaiMa.TabIndex = 7;
            this.btn_GiaiMa.Text = "Giải mã";
            this.btn_GiaiMa.UseVisualStyleBackColor = true;
            this.btn_GiaiMa.Click += new System.EventHandler(this.btn_GiaiMa_Click);
            // 
            // txt_L
            // 
            this.txt_L.Location = new System.Drawing.Point(161, 448);
            this.txt_L.Multiline = true;
            this.txt_L.Name = "txt_L";
            this.txt_L.Size = new System.Drawing.Size(100, 39);
            this.txt_L.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 563);
            this.Controls.Add(this.txt_L);
            this.Controls.Add(this.btn_GiaiMa);
            this.Controls.Add(this.btn_MaHoa);
            this.Controls.Add(this.txt_Khoa);
            this.Controls.Add(this.txt_BanMa);
            this.Controls.Add(this.txt_BanRo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
           // this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_BanRo;
        private System.Windows.Forms.TextBox txt_BanMa;
        private System.Windows.Forms.TextBox txt_Khoa;
        private System.Windows.Forms.Button btn_MaHoa;
        private System.Windows.Forms.Button btn_GiaiMa;
        private System.Windows.Forms.TextBox txt_L;
    }
}

