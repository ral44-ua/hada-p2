using Susing System;
using System.Collections.Generic;

namespace Hada
{
    internal class Barco
    {
        public Dictionary<Coordenada, string> CoordenadasBarco { get; private set; }
        public string Nombre { get; private set; }
        public int NumDanyos { get; private set; }

        public event EventHandler<TocadoArgs> eventoTocado;
        public event EventHandler<HundidoArgs> eventoHundido;

        public Barco(string nombre, int longitud, char orientacion, Coordenada coordenadaInicio)
        {
            Nombre = nombre;
            NumDanyos = 0;
            this.CoordenadasBarco = new Dictionary<Coordenada, string>();

            Coordenada coordActual = new Coordenada(coordenadaInicio);
            this.CoordenadasBarco.Add(coordActual, nombre);

            for (int i = 1; i < longitud; i++)
            {
                if (orientacion == 'h')
                {
                    coordActual = new Coordenada(coordActual.Fila, coordActual.Columna + 1);
                }
                else if (orientacion == 'v')
                {
                    coordActual = new Coordenada(coordActual.Fila + 1, coordActual.Columna);
                }
                this.CoordenadasBarco.Add(coordActual, nombre);
            }
        }

        public void Disparo(Coordenada c)
        {
            if (this.CoordenadasBarco.ContainsKey(c))
            {
                if (!this.CoordenadasBarco[c].EndsWith("_T"))
                {
                    this.CoordenadasBarco[c] = this.CoordenadasBarco[c] + "_T";
                    this.NumDanyos++;

                    eventoTocado?.Invoke(this, new TocadoArgs(this.Nombre, c));

                    if (hundido())
                    {
                        eventoHundido?.Invoke(this, new HundidoArgs(this.Nombre));
                    }
                }
            }
        }

        public bool hundido()
        {
            foreach (string etiqueta in this.CoordenadasBarco.Values)
            {
                if (!etiqueta.EndsWith("_T"))
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string infoBarco = $"[{this.Nombre}] - DAÑOS: [{this.NumDanyos}] - HUNDIDO: [{this.hundido()}] - COORDENADAS: ";
            List<string> listaCoordenadas = new List<string>();
            foreach (KeyValuePair<Coordenada, string> par in this.CoordenadasBarco)
            {
                listaCoordenadas.Add($"[{par.Key.ToString()} :{par.Value}]");
            }
            return infoBarco + string.Join(" ", listaCoordenadas);
        }
    }
}
