using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartas.Entities
{
    class Mano
    {
        public const int tamMano = 10;
        private Carta[] cartas = new Carta[tamMano];
        private int contadorCartas =0;



        public void addCartaMano(Carta repartirCarta)
        {
            if (this.contadorCartas>tamMano)
            {
                throw new Exception("Demasiadas Cartas");
            }
            this.cartas[this.contadorCartas] = repartirCarta;
            this.contadorCartas++;
        }

        public override string ToString()
        {
            String result = String.Empty;

            foreach (Carta carta in this.cartas)
            {
                result += carta.ToString() + "\n";
            }

            return result;
        }
       public Carta[]  GetCartas(){
          return this.cartas;
       }






    }
}
