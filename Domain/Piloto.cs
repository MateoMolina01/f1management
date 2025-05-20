using f1management.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence
{
    class Piloto
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Experiencia { get; set; }
        public int Dorsal { get; set; }
        public bool ContratoActivo { get; set; }
        public int Campeonatos { get; set; }
        public int Victorias { get; set; }
        public int Poles { get; set; }
        public int FinContrato { get; set; }
        public int IdPais { get; set; }

        public PilotoManager pm { get; set; }

        public Piloto()
        {
            pm = new PilotoManager();
        }

        public Piloto(int id, string nombre, int edad, int experiencia, int dorsal, bool contratoActivo, int campeonatos, int victorias, int poles, int finContrato, int pais)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Edad = edad;
            this.Experiencia = experiencia;
            this.Dorsal = dorsal;
            this.ContratoActivo = contratoActivo;
            this.Campeonatos = campeonatos;
            this.Victorias = victorias;
            this.Poles = poles;
            this.FinContrato = finContrato;
            this.IdPais = pais;

            pm = new PilotoManager();
        }

        public Piloto(string nombre, int edad, int experiencia, int dorsal, bool contratoActivo, int campeonatos, int victorias, int poles, int finContrato, int pais)
        {

            pm = new PilotoManager();

            Id = pm.lastId();
            this.Nombre = nombre;
            this.Edad = edad;
            this.Experiencia = experiencia;
            this.Dorsal = dorsal;
            this.ContratoActivo = contratoActivo;
            this.Campeonatos = campeonatos;
            this.Victorias = victorias;
            this.Poles = poles;
            this.FinContrato = finContrato;
            this.IdPais = pais;

        }

        public void insert()
        {
            pm.insertPiloto(this);
        }

        public void update()
        {
            pm.updatePiloto(this);
        }

        public void delete()
        {
            pm.deletePiloto(this);
        }

        public List<Piloto> leerPilotos()
        {
            return pm.readPilotos();
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
