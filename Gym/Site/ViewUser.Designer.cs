namespace Gym.Site
{
    partial class ViewUser
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewUser));
            dataGridView1 = new DataGridView();
            label3 = new Label();
            txtNombreBuscar = new TextBox();
            label4 = new Label();
            btnEliminar = new Button();
            button3 = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 128, 128);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 128, 128);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Firebrick;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 192, 192);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 192, 192);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(28, 116);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(740, 282);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Desktop;
            label3.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Image = Properties.Resources._360_F_317724775_qHtWjnT8YbRdFNIuq5PWsSYypRhOmalS;
            label3.ImageAlign = ContentAlignment.TopCenter;
            label3.Location = new Point(303, 9);
            label3.Name = "label3";
            label3.Size = new Size(154, 31);
            label3.TabIndex = 2;
            label3.Text = "Energymclub";
            // 
            // txtNombreBuscar
            // 
            txtNombreBuscar.Location = new Point(626, 82);
            txtNombreBuscar.Name = "txtNombreBuscar";
            txtNombreBuscar.PlaceholderText = "Buscar...";
            txtNombreBuscar.Size = new Size(135, 22);
            txtNombreBuscar.TabIndex = 10;
            txtNombreBuscar.TextChanged += txtNombreBuscar_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(590, 85);
            label4.Name = "label4";
            label4.Size = new Size(0, 13);
            label4.TabIndex = 11;
            // 
            // btnEliminar
            // 
            btnEliminar.Image = Properties.Resources.icons8_eliminar_usuaria_48;
            btnEliminar.Location = new Point(363, 405);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(51, 48);
            btnEliminar.TabIndex = 13;
            btnEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += EliminarCredencialesbutton1_Click;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.icons8_cerrar_ventana_48;
            button3.Location = new Point(423, 405);
            button3.Name = "button3";
            button3.Size = new Size(51, 48);
            button3.TabIndex = 15;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Image = Properties.Resources.icons8_plus_emoji_48;
            btnGuardar.Location = new Point(303, 405);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(51, 48);
            btnGuardar.TabIndex = 16;
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += button1_Click_1;
            // 
            // ViewUser
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            BackgroundImage = Properties.Resources._360_F_317724775_qHtWjnT8YbRdFNIuq5PWsSYypRhOmalS;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(790, 499);
            Controls.Add(btnGuardar);
            Controls.Add(button3);
            Controls.Add(btnEliminar);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtNombreBuscar);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "ViewUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UsuariosGym";
            Load += ViewUser_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label3;
        private TextBox txtNombreBuscar;
        private Label label4;
        private Button btnEliminar;
        private Button button3;
        private Button btnGuardar;
    }
}