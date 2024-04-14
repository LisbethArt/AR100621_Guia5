using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios
{
    internal class UsuarioDto
    {
        private int id; // Campo
        public int Id // Property
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre; // Campo
        public string Nombre // Property
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido; // Campo
        public string Apellido // Property
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string email; // Campo
        public string Email // Property
        {
            get { return email; }
            set { email = value; }
        }

        private int pais; // Campo
        public int Pais // Property
        {
            get { return pais; }
            set { pais = value; }
        }

        // Nueva propiedad para almacenar el nombre del país
        private string nombrePais; // Campo
        public string NombrePais // Property
        {
            get { return nombrePais; }
            set { nombrePais = value; }
        }
    }
}