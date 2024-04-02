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

namespace Gym.Site
{
    public partial class ConteoRegresivo : Form
    {
        private readonly UsuarioService _usuarioService;
        public ConteoRegresivo(string usuario)
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
            loadInitial(usuario);
        }
        private void loadInitial(string usuarioCredencial)
        {
            var response = _usuarioService.GetUsuarioByCredencial(usuarioCredencial);

            if (response.Success)
            {
                var usuario = response.Data;

                // Muestra la información del usuario en los controles correspondientes
                userNameLbl.Text = $"{usuario.Nombre} {usuario.Apellido}";
                dayDisponibleLbl.Text = $"{calculaterestantes(usuario.FechaRegistro)}";
            }
            else
            {
                // Muestra un mensaje de error si no se puede cargar el usuario
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string calculaterestantes(DateTime fechaInicial)
        {
            DateTime primerDiaMesSiguiente = fechaInicial.AddMonths(1);
            DateTime ultimoDiaMesActual = primerDiaMesSiguiente.AddDays(-1);
            DateTime toDay = DateTime.Now;

            TimeSpan diferencia = ultimoDiaMesActual - toDay;
            int diasRestantes = diferencia.Days;
            int horasRestantes = diferencia.Hours;

            string resultado = $"{diasRestantes} Días y {horasRestantes} Horas";
            return resultado;
        }

        private void ConteoRegresivo_Load(object sender, EventArgs e)
        {

        }

        private void userNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // cerrar ventana
            this.Close();
            //continuar proceso
            Login registernew = new Login();
            registernew.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dayDisponibleLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
