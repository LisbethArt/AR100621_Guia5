using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionUsuarios
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            UsuarioDao daoUsuario = new UsuarioDao();
            var usuarios = daoUsuario.Obtener();

            // Iterar sobre cada usuario y asignar el nombre del país
            foreach (var usuario in usuarios)
            {
                usuario.NombrePais = daoUsuario.ObtenerNombrePaisPorId(usuario.Pais);
            }

            dgUsuarios.ItemsSource = usuarios;

            // Ocultar la columna de país
            foreach (var column in dgUsuarios.Columns)
            {
                if (column.Header.ToString() == "Pais")
                {
                    column.Visibility = Visibility.Collapsed;
                    break;
                }
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            FrmUsuario frm = new FrmUsuario();
            frm.ShowDialog();
            CargarDatos();
        }

        private int ObtenerIdSeleccionado()
        {
            var selected = dgUsuarios.SelectedItems;
            foreach (var item in selected )
            {
                var usr = item as UsuarioDto;
                return usr.Id;
            }
            return -1; // No ha seleccionado fila
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            int id = ObtenerIdSeleccionado();
            if (id == -1) 
            {
                MessageBox.Show("No ha seleccionado registro a editar");
            }
            else
            {
                FrmUsuario frmEditar = new FrmUsuario(id);
                frmEditar.ShowDialog();
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = ObtenerIdSeleccionado();
            if (id == -1)
            {
                MessageBox.Show("No ha seleccionado registro a eliminar");
            }
            else
            {
                try
                {
                    var Result = MessageBox.Show("¿Desea eliminar el registro seleccionado?",
                        "Gestión de Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (Result == MessageBoxResult.Yes)
                    {
                        UsuarioDao daoUsuario = new UsuarioDao();
                        daoUsuario.Eliminar(id);
                        MessageBox.Show("Registro eliminado con éxito");
                        CargarDatos();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }
    }
}