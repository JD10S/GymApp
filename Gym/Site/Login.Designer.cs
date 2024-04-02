namespace Gym
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            button1 = new Button();
            txtUser = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            linkLabel1 = new LinkLabel();
            pictureBox2 = new PictureBox();
            checkBox1 = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 128);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(374, 220);
            button1.Name = "button1";
            button1.Size = new Size(70, 21);
            button1.TabIndex = 0;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtUser
            // 
            txtUser.BackColor = SystemColors.WindowFrame;
            txtUser.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            txtUser.ForeColor = SystemColors.Window;
            txtUser.Location = new Point(374, 128);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(134, 22);
            txtUser.TabIndex = 1;
            txtUser.TextChanged += txtUser_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.WindowFrame;
            txtPassword.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            txtPassword.ForeColor = SystemColors.Window;
            txtPassword.Location = new Point(374, 165);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(134, 22);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(374, 113);
            label1.Name = "label1";
            label1.Size = new Size(47, 13);
            label1.TabIndex = 3;
            label1.Text = "Usuario";
            label1.Click += Login_Load;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(374, 149);
            label2.Name = "label2";
            label2.Size = new Size(69, 13);
            label2.TabIndex = 4;
            label2.Text = "Contraseña ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 272);
            panel1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(80, 196);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(107, 13);
            label4.TabIndex = 2;
            label4.Text = "Por Cuerpo y Salud";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(58, 165);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(154, 31);
            label3.TabIndex = 1;
            label3.Text = "Energymclub";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cuantas_calorias_se_queman_en_el_gym_48685_600;
            pictureBox1.Location = new Point(31, 29);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(213, 118);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            linkLabel1.LinkColor = Color.Red;
            linkLabel1.Location = new Point(421, 250);
            linkLabel1.Margin = new Padding(2, 0, 2, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(53, 13);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Registrar";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.CI4ThitFOqF157_2;
            pictureBox2.Location = new Point(326, 0);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(233, 108);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.Location = new Point(374, 189);
            checkBox1.Margin = new Padding(2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(111, 16);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Mostrar Contraseña";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 274);
            Controls.Add(checkBox1);
            Controls.Add(pictureBox2);
            Controls.Add(linkLabel1);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUser);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EnergymApp";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtUser;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox2;
        private CheckBox checkBox1;
    }
}
