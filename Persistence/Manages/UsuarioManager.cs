using f1management.Persistence;
using System;
using System.Collections.Generic;
using System.Windows;

namespace proyectoExamen.persistence.manages
{
    internal class UsuarioManager
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

            string query = $"INSERT INTO Usuario (Nombre, Password, Email, esAdmin) " +
                           $"VALUES ('{usuario.Nombre}', '{usuario.Password}', '{usuario.Email}', {esAdminInt})";
            broker.modifier(query);
            MessageBox.Show($"Usuario insertado: {usuario.Nombre}");
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

            string query = $"UPDATE usuarios SET nombre = '{usuario.Nombre}', password = '{usuario.Password}', " +
                           $"email = '{usuario.Email}', esAdmin = {esAdminInt} WHERE idUsuario = {usuario.Id}";
            broker.modifier(query);
            MessageBox.Show($"Usuario actualizado: {usuario.Nombre}");
        }
    }
}
