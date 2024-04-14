using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionUsuarios
{
    /// <summary>
    /// Lógica de interacción para FrmUsuario.xaml
    /// </summary>
    public partial class FrmUsuario : Window
    {
        private int? Id;
        public FrmUsuario(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
            CargarPaises("");
            if (this.Id != null) CargarDatos();
        }

        private void CargarDatos()
        {
            UsuarioDao daoUsuario = new UsuarioDao();
            UsuarioDto usuario = daoUsuario.Obtener(this.Id);
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email;

            // Convertir el ID del país a una cadena
            string idPais = usuario.Pais.ToString();

            // Seleccionar el país en el ComboBox cmbPais
            cmbPais.SelectedValue = idPais;
        }


        private void CargarPaises(string idPais)
        {
            PaisDao daoPais = new PaisDao();
            List<PaisDto> paises = daoPais.Obtener();
            cmbPais.ItemsSource = paises;
            cmbPais.DisplayMemberPath = "Nombre";
            cmbPais.SelectedValuePath = "Id";

            // Verificar si el idPais no es nulo o vacío y si es un número válido
            if (!string.IsNullOrEmpty(idPais) && int.TryParse(idPais, out int idPaisInt))
            {
                // Encontrar el país correspondiente al ID del usuario
                PaisDto paisSeleccionado = paises.FirstOrDefault(p => p.Id == idPaisInt);
                if (paisSeleccionado != null)
                {
                    // Seleccionar el país encontrado
                    cmbPais.SelectedItem = paisSeleccionado;
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                UsuarioDao daoUsuario = new UsuarioDao();
                try
                {
                    if (this.Id == null)
                        daoUsuario.Agregar(txtNombre.Text, txtApellido.Text, txtEmail.Text, ((PaisDto)cmbPais.SelectedItem).Id);
                    else
                        daoUsuario.Actualizar(txtNombre.Text, txtApellido.Text, txtEmail.Text, ((PaisDto)cmbPais.SelectedItem).Id, (int)Id);
                    this.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese datos válidos en los campos del formulario.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarCampos()
        {
            // Expresión regular para validar solo caracteres de la a-z o A-Z
            Regex regexSoloLetras = new Regex(@"^[a-zA-Z]+$");
            // Expresión regular para validar el formato de una dirección de correo electrónico
            Regex regexEmail = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            bool camposValidos = true;

            // Validar nombre
            if (!regexSoloLetras.IsMatch(txtNombre.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                camposValidos = false;
            }

            // Validar apellido
            if (!regexSoloLetras.IsMatch(txtApellido.Text))
            {
                MessageBox.Show("El apellido solo puede contener letras.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                camposValidos = false;
            }

            // Validar email
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("El formato del correo electrónico es inválido.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                camposValidos = false;
            }

            return camposValidos;
        }
    }
}