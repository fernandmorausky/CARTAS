using Cartas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cartas
{ 
    public partial class MainWindow : Window
    {

        public const int numManos = 4;
        private Pack pack = null;
        private Mano[] manos = { new Mano(), new Mano(), new Mano(), new Mano() };
        public MainWindow()
        {
            InitializeComponent();
        } 

        private void btnRepartir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pack = new Pack();
                for (int numMano = 0; numMano < numManos; numMano++)
                {
                    manos[numMano] = new Mano();
                    for (int numCartas = 0; numCartas < Mano.tamMano; numCartas++)
                    {
                        Carta repartirCarta = pack.repartirCarta();
                        manos[numMano].addCartaMano(repartirCarta);
                    }

                    
                }
                txt1.Text = manos[0].ToString();
                txt2.Text = manos[1].ToString();
                txt3.Text = manos[2].ToString();
                txt4.Text = manos[3].ToString();
            }
            catch (Exception ex )
            {

                MessageBox.Show("Message : "+ ex.Message + " StackTrace : " + ex.StackTrace);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
        
    }
}
