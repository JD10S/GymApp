using Gym.Entity;
using Gym.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gym.Site
{
    public partial class RegisterUser : Form
    {
        private readonly UsuarioService _usuarioService;
        private readonly CredentialService _credencialService;
        public RegisterUser()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
            _credencialService = new CredentialService();
        }

        private bool validade()
        {
            if (txtApellido.Text.Equals("") ||
                txtDireccion.Text.Equals(""))
            {
                MessageBox.Show("Verifique los campos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                var usuario = new Usuario()
                {
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    Eps = txtEPS.Text,
                    Identificacion = txtIdentificacion.Text,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    FechaNacimiento = txtNacimiento.Value,
                    FechaRegistro = txtRegistro.Value,
                    Credencial = txtUsuario.Text,
                    NombreUsuario = txtContrasenia.Text,
                };


                var respuestaCrdential = _credencialService.RegisterUsuario(txtUsuario.Text, txtContrasenia.Text);

                if (respuestaCrdential.Success)
                {
                    var respuesta = _usuarioService.InsertUsuario(usuario);
                    if (respuesta.Success)
                    {
                        MessageBox.Show(respuesta.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(respuesta.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(respuestaCrdential.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private bool CamposEstanLlenos()
        {
            // Verificar si los campos requeridos están llenos
            return !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                   !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                   !string.IsNullOrWhiteSpace(txtDireccion.Text) &&
                   !string.IsNullOrWhiteSpace(txtEPS.Text) &&
                   !string.IsNullOrWhiteSpace(txtIdentificacion.Text) &&
                   !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                   !string.IsNullOrWhiteSpace(txtContrasenia.Text);
        }


        private void LimpiarCampos()
        {
            // Establecer el texto de los TextBox a cadena vacía
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEPS.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtIdentificacion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtNacimiento.Value = DateTime.Now; // O establecer una fecha predeterminada
            txtRegistro.Value = DateTime.Now; // O establecer una fecha predeterminada
            txtContrasenia.Text = string.Empty;


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbIdentificacion_Click(object sender, EventArgs e)
        {

        }

        private void txtRegistro_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
    
