using Gym.Logic;
using Gym.Site;

namespace Gym
{
    public partial class Login : Form
    {
        private readonly CredentialService _service;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
                return true; // Indica que el evento ha sido manejado
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public Login()
        {
            _service = new CredentialService();
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private bool validade()
        {
            if (txtUser.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Verifique los campos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validade())
            {
                var respuesta = _service.Login(txtUser.Text, txtPassword.Text);
                if (respuesta.Success)
                {


                    MessageBox.Show(respuesta.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form form = (respuesta.Data.Rol == "admin") ?
                        new ViewUser() : new ConteoRegresivo(respuesta.Data.NombreUsuario);
                    form.Show();
                }
                else
                {
                    MessageBox.Show(respuesta.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox) c.Text = "";
                if (c.Controls.Count > 0) LimpiarCampos(c);
            }
            txtUser.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUser registroUser = new RegisterUser();

            registroUser.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = checkBox1.Checked;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
