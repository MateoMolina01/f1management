using f1management.Persistence;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace proyectoExamen.persistence.manages
{
    public class UsuarioManager
    {
        public List<Usuario> ListaUsuarios { get; set; }

        public UsuarioManager()
        {
            ListaUsuarios = new List<Usuario>();
        }

        public List<Usuario> readUsuarios()
        {
            Usuario usuario = null;
            List<object> auxList;
            auxList = DBBroker.obtenerAgente().leer("SELECT * FROM usuarios");

            foreach (List<object> row in auxList)
            {
                usuario = new Usuario();

                usuario.Id = Convert.ToInt32(row[0]);
                usuario.Nombre = row[1].ToString();
                usuario.Password = row[2].ToString();
                usuario.Email = row[3].ToString();
                usuario.EsAdmin = Convert.ToInt32(row[4]) == 1;

                ListaUsuarios.Add(usuario);
            }
            return ListaUsuarios;
        }

        public int lastId()
        {
            int lastId = 0;
            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idUsuario), 0) FROM usuarios");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public void insertUsuario(Usuario usuario)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            int esAdminInt = usuario.EsAdmin ? 1 : 0;

            string passwordEncriptada = EncriptarContraseña(usuario.Password);

            string query = $"INSERT INTO usuarios (Nombre, Password, Email, esAdmin) " +
                           $"VALUES ('{usuario.Nombre}', '{passwordEncriptada}', '{usuario.Email}', {esAdminInt})";
            broker.modifier(query);
            //MessageBox.Show($"Usuario insertado: {usuario.Nombre}");
        }

        public void deleteUsuario(Usuario usuario)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM usuarios WHERE idUsuario = {usuario.Id}";
            broker.modifier(query);
            MessageBox.Show($"Usuario eliminado: {usuario.Nombre}");
        }

        public void updateUsuario(Usuario usuario)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            int esAdminInt = usuario.EsAdmin ? 1 : 0;

            //tener en cuenta que si modificamos contraseñas hay que encriptarlas

            string query = $"UPDATE usuarios SET nombre = '{usuario.Nombre}', password = '{usuario.Password}', " +
                           $"email = '{usuario.Email}', esAdmin = {esAdminInt} WHERE idUsuario = {usuario.Id}";
            broker.modifier(query);
            MessageBox.Show($"Usuario actualizado: {usuario.Nombre}");
        }

        public bool ExisteEmail(string email)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"SELECT COUNT(*) FROM usuarios WHERE email = '{email}'";
            List<object> resultado = broker.leer(query);

            if (resultado.Count > 0)
            {
                List<object> fila = (List<object>)resultado[0];
                int count = int.Parse(fila[0].ToString());
                return count > 0;
            }

            return false;
        }

        public bool ExisteNombreUsuario(string nombre)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"SELECT COUNT(*) FROM usuarios WHERE Nombre = '{nombre}'";
            List<object> resultado = broker.leer(query);

            if (resultado.Count > 0)
            {
                List<object> fila = (List<object>)resultado[0];
                int count = int.Parse(fila[0].ToString());
                return count > 0;
            }

            return false;
        }

        public string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertimos la contraseña a un array de bytes
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Convertimos el array de bytes a un string hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
