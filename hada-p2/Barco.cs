using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hada;

namespace Hada
{
    internal class Barco
    {
        public Dictionary<Coordenada, String> CoordenadasBarco;
        public string Nombre;
        public int NumDanyos;

        public event EventHandler<TocadoArgs> eventoTocado;
        public event EventHandler<HundidoArgs> eventoHundido;

        public Barco(string nombre, int longitud, char orientacion, Coordenada coordenadaInicio)
        {
            Nombre = nombre;
            NumDanyos = 0;
            this.CoordenadasBarco = new Dictionary<Coordenada, string>();
            for (int i = 0; i < longitud; i++)
            {
                int filaActual = coordenadaInicio.Fila;
                int columnaActual = coordenadaInicio.Columna;

                if (orientacion == 'h')
                {
                    columnaActual += 1;
                }
                else if (orientacion == 'v')
                {
                    filaActual += 1;
                }

                    // Instanciamos la nueva coordenada para esta posición
                    Coordenada nuevaCoordenada = new Coordenada(filaActual, columnaActual);

                // Añadimos la clave (nuevaCoordenada) y el valor (el Nombre del barco) al diccionario
                this.CoordenadasBarco.Add(nuevaCoordenada, this.Nombre);
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
