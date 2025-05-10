using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace f1management.Persistence.Manages
{
    class PilotoManager
    {

        public List<Piloto> ListaPilotos { get; set; }

        public PilotoManager()
        {
            ListaPilotos = new List<Piloto>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idPiloto),0) FROM pilotos");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Piloto> readPilotos()
        {
            Piloto piloto = null;
            List<object> auxList = DBBroker.obtenerAgente().leer("SELECT * FROM pilotos");

            foreach (List<object> row in auxList)
            {
                piloto = new Piloto();

                piloto.Id = Convert.ToInt32(row[0]);
                piloto.Nombre = row[1].ToString();
                piloto.Edad = Convert.ToInt32(row[2]);
                piloto.Experiencia = Convert.ToInt32(row[3]);
                piloto.Dorsal = Convert.ToInt32(row[4]);
                piloto.ContratoActivo = Convert.ToInt32(row[5]) == 1;
                piloto.Campeonatos = Convert.ToInt32(row[6]);
                piloto.Victorias = Convert.ToInt32(row[7]);
                piloto.Poles = Convert.ToInt32(row[8]);
                piloto.FinContrato = Convert.ToInt32(row[9]);
                piloto.IdPais = Convert.ToInt32(row[10]);

                ListaPilotos.Add(piloto);
            }

            return ListaPilotos;
        }
        public void insertPiloto(Piloto piloto)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO pilotos (nombre, edad, experiencia, dorsal, contratoActivo, campeonatosGanados, victorias, poles, finContrato, idPais) " +
                           $"VALUES ('{piloto.Nombre}', {piloto.Edad}, {piloto.Experiencia}, {piloto.Dorsal}, {(piloto.ContratoActivo ? 1 : 0)}, " +
                           $"{piloto.Campeonatos}, {piloto.Victorias}, {piloto.Poles}, {piloto.FinContrato}, {piloto.IdPais})";
            broker.modifier(query);
            MessageBox.Show($"Piloto insertado: {piloto.Nombre}");
        }

        public void deletePiloto(Piloto piloto)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM pilotos WHERE idPiloto = {piloto.Id}";
            broker.modifier(query);
            MessageBox.Show($"Piloto eliminado: {piloto.Nombre}");
        }

        public void updatePiloto(Piloto piloto)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE pilotos SET nombre = '{piloto.Nombre}', edad = {piloto.Edad}, experiencia = {piloto.Experiencia}, dorsal = {piloto.Dorsal}, " +
                           $"contratoActivo = {(piloto.ContratoActivo ? 1 : 0)}, campeonatosGanados = {piloto.Campeonatos}, victorias = {piloto.Victorias}, " +
                           $"poles = {piloto.Poles}, finContrato = {piloto.FinContrato}, idPais = {piloto.IdPais} WHERE idPiloto = {piloto.Id}";
            broker.modifier(query);
        }
    }
}