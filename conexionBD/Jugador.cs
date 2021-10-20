using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionBD
{
    class Jugador
    {
        private int id;
        private string nombre;
        private string rut;
        private int puntaje;

        public Jugador(int id, string nombre, string rut, int puntaje)
        {
            this.id = id;
            this.nombre = nombre;
            this.rut = rut;
            this.puntaje = puntaje;
        }

        public Jugador(string nombre, string rut, int puntaje)
        {
            this.nombre = nombre;
            this.rut = rut;
            this.puntaje = puntaje;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Rut { get => rut; set => rut = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }
    }
}
