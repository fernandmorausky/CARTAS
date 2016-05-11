using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartas.Entities
{
    class Pack
    {
        public const int NumPalos= 4;
        public const int CartasXPalos = 13;
        private Carta[,] packCarta;
        private Random selectorCartas = new Random();

        public Pack()
        {
            this.packCarta = new Carta[NumPalos, CartasXPalos];
            for (Palo palo  =Palo.Cocos ; palo <= Palo.Corazones; palo++)
            {
                for (Valor valor  = Valor.Dos;  valor  <= Valor.AS;  valor ++)
                {
                    this.packCarta[(int)palo, (int)valor] = new Carta(palo, valor);

                }
            }
        }
        public Carta repartirCarta()
        {
            Palo palo;
            Valor valor;
            Carta carta;


            do
            {
                palo = (Palo)selectorCartas.Next(NumPalos);
            } while (paloIsEmpty(palo) );
            do
            {
                valor = (Valor)selectorCartas.Next(CartasXPalos);
            } while (valorIsEmpty(valor));
            carta= this.packCarta[(int)palo,(int)valor];
            //this.packCarta[(int)palo,(int) valor] = null;
            return carta;   
        }

        private bool valorIsEmpty(Valor valor)
        {
            bool resultado = true;
            for (Palo palo= Palo.Cocos;  palo < Palo.Corazones;  palo++)
            {
                if (!cartaYaRepartida(palo,valor))
                {
                    resultado = false;
                    break;
                }
            }


            return resultado;
        }

        private bool cartaYaRepartida(Palo palo, Valor valor)
        {
            return (this.packCarta[(int)palo,(int) valor] == null);
        }

        private bool paloIsEmpty(Palo palo)
        {
            bool resultado = true;
            for (Valor valor = Valor.Dos; valor < Valor.AS; valor++)
            {
                if (!cartaYaRepartida(palo, valor))
                {
                    resultado = false;
                    break;
                }
            }


            return resultado;
        }
    }
}
