using f1management.Persistence.Manages;
using proyectoExamen.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EsAdmin { get; set; }

        public UsuarioManager um { get; set; }

        public Usuario()
        {
            um = new UsuarioManager();
        }

        public Usuario(int id, string nombre, string password, string email, bool esAdmin, UsuarioManager um)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Password = password;
            this.Email = email;
            this.EsAdmin = esAdmin;

            um = new UsuarioManager();
        }

        public Usuario(string nombre, string password, string email, bool esAdmin, UsuarioManager um)
        {
            um = new UsuarioManager();

            Id = um.lastId();
            this.Nombre = nombre;
            this.Password = password;
            this.Email = email;
            this.EsAdmin = esAdmin;
        }

        public List<Usuario> leerUsuarios()
        {
            return um.readUsuarios();
        }

        public void insert()
        {
            um.insertUsuario(this);
        }

        public void delete()
        {
            um.deleteUsuario(this);
        }

        public void update()
        {
            um.updateUsuario(this);
        }

        public bool existeMail(string email)
        {
            return um.ExisteEmail(email);
        }

        public bool existeNombre(string nombre)
        {
            return um.ExisteNombreUsuario(nombre);
        }

        public string encriptar(string password)
        {
            return um.EncriptarContraseña(password);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
