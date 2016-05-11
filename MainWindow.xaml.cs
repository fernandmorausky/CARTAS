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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public const int numManos = 4;
        private Pack pack = null;
        private Mano[] manos = { new Mano(), new Mano(), new Mano(), new Mano() };
        public MainWindow()
        {
            InitializeComponent();
        }
        //int LoadCards()
        //{
        //    int frecuencia1 = 0;
        //    int frecuencia2 = 0;
        //    int frecuencia3 = 0;
        //    int frecuencia4 = 0;
        //    int frecuencia5 = 0;
        //    int frecuencia6 = 0;
        //    int cara;
        //    Random rd = new Random();
        //    for (int tiro = 1; tiro <= 6000; tiro++)
        //    {
        //        cara = 1 + rd.Next(0,59) % 6;
        //        switch (cara)
        //        {
        //            case 1:
        //                ++frecuencia1;
        //                break;
        //            case 2:
        //                ++frecuencia2;
        //                break;
        //            case 3:
        //                ++frecuencia3;
        //                break;
        //            case 4:
        //                ++frecuencia4;
        //                break;
        //            case 5:
        //                ++frecuencia5;
        //                break;
        //            case 6:
        //                ++frecuencia6;
        //                break;
        //            default:
        //                 MessageBox.Show("¡El programa no debe llegar hasta aquí!");
        //                break;
        //        }
        //    }
        //    MessageBox.Show("Cara     Frecuencia");
        //    MessageBox.Show("\n 1" +frecuencia1 );
        //    MessageBox.Show("\n 2"  + frecuencia2);
        //    MessageBox.Show("\n 3" + frecuencia3);
        //    MessageBox.Show("\n 4" + frecuencia4);
        //    MessageBox.Show("\n 5" + frecuencia5);
        //    MessageBox.Show("\n 6" + frecuencia6);
        //    return 0;
        //}


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
    }
}
