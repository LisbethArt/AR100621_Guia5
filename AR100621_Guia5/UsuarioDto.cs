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

        private string pais; // Campo
        public string Pais // Property
        {
            get { return pais; }
            set { pais = value; }
        }
    }
}