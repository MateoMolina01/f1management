using f1management.Persistence.Manages;

namespace f1management.Persistence
{
    class PilotoCircuito
    {
        public int IdPiloto { get; set; }
        public int IdCircuito { get; set; }
        public int Puntos { get; set; }
        public int Temporada { get; set; }

        public PilotoCircuitoManager pcm { get; set; }

        public PilotoCircuito()
        {
            pcm = new PilotoCircuitoManager();
        }

        public PilotoCircuito(int idPiloto, int idCircuito, int puntos, int temporada)
        {
            IdPiloto = idPiloto;
            IdCircuito = idCircuito;
            Puntos = puntos;
            Temporada = temporada;
            pcm = new PilotoCircuitoManager();
        }

        public List<PilotoCircuito> LeerTodos()
        {
            return pcm.ReadAll();
        }

        public List<PilotoCircuito> ObtenerPorCircuitoYTemporada(int idCircuito, int temporada)
        {
            return pcm.ReadByCircuitoYTemporada(idCircuito, temporada);
        }
    }
}
