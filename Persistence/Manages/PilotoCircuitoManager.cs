namespace f1management.Persistence.Manages
{
    class PilotoCircuitoManager
    {
        public List<PilotoCircuito> ReadAll()
        {
            List<PilotoCircuito> lista = new List<PilotoCircuito>();
            List<object> datos = DBBroker.obtenerAgente().leer("SELECT * FROM pilotos_circuitos");

            foreach (List<object> row in datos)
            {
                lista.Add(new PilotoCircuito(
                    Convert.ToInt32(row[0]),
                    Convert.ToInt32(row[1]),
                    Convert.ToInt32(row[2]),
                    Convert.ToInt32(row[3])
                ));
            }

            return lista;
        }

        public List<PilotoCircuito> ReadByCircuitoYTemporada(int idCircuito, int temporada)
        {
            List<PilotoCircuito> lista = new List<PilotoCircuito>();
            string query = $"SELECT * FROM pilotos_circuitos WHERE idCircuito = {idCircuito} AND temporada = {temporada}";
            List<object> datos = DBBroker.obtenerAgente().leer(query);

            foreach (List<object> row in datos)
            {
                lista.Add(new PilotoCircuito(
                    Convert.ToInt32(row[0]),
                    Convert.ToInt32(row[1]),
                    Convert.ToInt32(row[2]),
                    Convert.ToInt32(row[3])
                ));
            }

            return lista;
        }
    }
}
