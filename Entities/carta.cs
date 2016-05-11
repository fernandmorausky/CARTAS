using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartas.Entities
{
    class Carta
    {
        private readonly Palo palo;
        private readonly Valor valor;

        public Carta(Palo palo, Valor valor)
        {
            this.palo = palo;
            this.valor = valor;
        }
        public override string ToString()
        {
            return this.palo.ToString() + this.valor.ToString();
        }
        public Palo paloBaraja()
        {
            return this.palo;
        }
        public Valor valorBaraja()
        {
            return this.valor;
        }


    }
}
