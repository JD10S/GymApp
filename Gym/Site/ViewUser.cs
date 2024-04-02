using Gym.Entity;
using Gym.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.Site
{
    public partial class ViewUser : Form
    {
        private readonly UsuarioService _services = new UsuarioService();
        private readonly CredentialService _credencialService = new CredentialService();
        private string textoBusqueda = string.Empty;
        private bool edicionActiva = false;
        public ViewUser()
        {
            
            _services = new UsuarioService();
            InitializeComponent();
            LoaderTablet(GetDataGridView1());
            // Configura la propiedad EditMode del DataGridView
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;


        }

        private DataGridView GetDataGridView1()
        {
            return dataGridView1;
        }

        private void LoaderTablet(DataGridView dataGridView1)
        {
            var response = _services.GetAllUsuarios();

            if (response.Success)
            {
                dataGridView1.DataSource = response.Data.ToList();
            }
            else
            {
                MessageBox.Show(response.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool confirmacionEdicion = false;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                Usuario usuarioSeleccionado = (Usuario)row.DataBoundItem;

                DialogResult confirmacion = MessageBox.Show($"¿Estás seguro de editar al usuario:\nNombre: {usuarioSeleccionado.Nombre}\nApellido: {usuarioSeleccionado.Apellido}?", "Confirmar Edición",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Activa la edición directa solo para la fila seleccionada
                    edicionActiva = true;
                    dataGridView1.Rows[e.RowIndex].ReadOnly = false;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("CellEndEdit Event Called");

            // Verifica si la edición está activa
            if (edicionActiva)
            {
                try
                {
                    // Obtiene el usuario seleccionado
                    Usuario usuarioSeleccionado = (Usuario)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                    // Llama al servicio para guardar los cambios en la base de datos
                    var respuesta = _services.UpdateUsuario(usuarioSeleccionado);

                    // Verifica si la actualización fue exitosa
                    if (respuesta.Success)
                    {
                        // Mostrar un mensaje de éxito
                        MessageBox.Show(respuesta.Message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Restaura el estado original después de la edición
                        dataGridView1.Rows[e.RowIndex].ReadOnly = true;

                        // Desactiva la edición
                        edicionActiva = false;

                        // Recargar el DataGridView con la lista actualizada de usuarios
                        LoaderTablet(dataGridView1);
                    }
                    else
                    {
                        // Mostrar un mensaje de error si la actualización falló
                        MessageBox.Show(respuesta.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir durante la actualización
                    MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dataGridView1_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            Debug.WriteLine("CellBeginEdit Event Called");

            // Establece la confirmación predeterminada en falso
            confirmacionEdicion = false;

            // Pregunta al usuario si realmente desea editar la celda
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea editar esta celda?", "Confirmar Edición",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Establece la confirmación en verdadero solo si el usuario elige "Sí"
            confirmacionEdicion = (resultado == DialogResult.Yes);
            // Cancela la edición si no hay confirmación
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = !confirmacionEdicion;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login salirUser = new Login();
            salirUser.Show();
            // Cerrar la ventana actual
            this.Close();
        }

        private void ViewUser_Load(object sender, EventArgs e)
        {

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Filtrar la lista de usuarios basándose en el texto de búsqueda
            var usuariosFiltrados = _services.GetAllUsuarios().Data
        .Where(u =>
            u.Nombre.Contains(textoBusqueda) ||
            u.Apellido.Contains(textoBusqueda) ||
            u.Identificacion.Contains(textoBusqueda)
        ).ToList();

            // Actualizar el DataGridView con los resultados de la búsqueda
            dataGridView1.DataSource = usuariosFiltrados;
        }

        private void txtNombreBuscar_TextChanged(object sender, EventArgs e)
        {
            // Obtener el texto de búsqueda
            textoBusqueda = txtNombreBuscar.Text;

            // Realizar la búsqueda y actualizar el DataGridView
            btnBuscar_Click(sender, e);
        }

        private void EliminarCredencialesbutton1_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado un usuario en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el usuario seleccionado
                
                Usuario usuarioSeleccionado = (Usuario)dataGridView1.SelectedRows[0].DataBoundItem;

                // Mostrar un cuadro de diálogo de confirmación
                DialogResult resultado = MessageBox.Show($"¿Estás seguro de eliminar las credenciales del usuario {usuarioSeleccionado.NombreUsuario}?",
                                                          "Confirmar Eliminación de Credenciales",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                // Verificar si el usuario confirmó la eliminación
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al servicio para eliminar las credenciales
                        var respuesta = _services.EliminarUsuario(usuarioSeleccionado.Id);

                        if (respuesta.Success)
                        {
                            
                            // Mostrar un mensaje de éxito
                            MessageBox.Show(respuesta.Message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar el DataGridView con la lista actualizada de usuarios
                            LoaderTablet(dataGridView1);
                        }
                        else
                        {
                            // Mostrar mensaje de error si falla la eliminación de las credenciales
                            MessageBox.Show($"Error al eliminar las credenciales: {respuesta.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Mostrar mensaje de error si ocurre una excepción
                        MessageBox.Show($"Error al eliminar las credenciales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Mostrar mensaje si no se ha seleccionado ningún usuario
                MessageBox.Show("Por favor, seleccione un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GuardarCambios();
        }
        private void GuardarCambios()
        {
            try
            {
                // Guardar cambios en la base de datos
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.ReadOnly)
                    {
                        Usuario usuarioSeleccionado = (Usuario)row.DataBoundItem;
                        var respuesta = _services.UpdateUsuario(usuarioSeleccionado);

                        // Verifica si la actualización fue exitosa
                        if (!respuesta.Success)
                        {
                            // Mostrar un mensaje de error y salir del bucle si hay un problema
                            MessageBox.Show(respuesta.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }

                // Desactivar la edición directa y recargar el DataGridView
                edicionActiva = false;
                dataGridView1.ReadOnly = true;
                LoaderTablet(dataGridView1);

                // Opcional: Mostrar un mensaje de éxito
                MessageBox.Show("Cambios guardados exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}