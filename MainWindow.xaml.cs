using Cartas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

         setRowsAndColumns(grid1);
         setRowsAndColumns(grid2);
         setRowsAndColumns(grid3);
         setRowsAndColumns(grid4);

         addGrids(grid1);
         addGrids(grid2);
         addGrids(grid3);
         addGrids(grid4);
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
            setCellImage(grid1, manos[0].GetCartas());
            setCellImage(grid2, manos[1].GetCartas());
            setCellImage(grid3, manos[2].GetCartas());
            setCellImage(grid4, manos[3].GetCartas());
         }
         catch (Exception ex)
         {

            MessageBox.Show("Message : " + ex.Message + " StackTrace : " + ex.StackTrace);
         }
      }

      private void btnSalir_Click(object sender, RoutedEventArgs e)
      {
         this.Close();
      }
      #region functions
      private void setCellImage(Grid g,Carta[] cartas)
      {
         int column = 0;
         int row = 0;
 
         foreach (Carta carta in cartas)
         {
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(@"C:\Users\fernandojosemaria\Documents\Visual Studio 2015\Projects\Cartas\Cartas\Resources\" + carta.ToString() + ".png");
            var outPutDirectory = Assembly.GetExecutingAssembly().CodeBase;
            //MessageBox.Show(outPutDirectory.ToString());
            //Uri dd = new Uri(Properties.Resources.ResourceManager.GetObject(carta.ToString() + ".png").ToString);
           // b.UriSource = dd;
            //b.UriSource = new Uri(outPutDirectory + carta.ToString() + ".png");
            b.EndInit();
            Image _img = new Image();
            _img.Source = b;

            Grid.SetColumn(_img, column);
            Grid.SetRow(_img, row);
             
            if (!g.Children.Contains(_img))
               g.Children.Add(_img);
             
            column++;

            if (column == 2)
            {
               row++;
               column = 0;
            }
             
         } 
         g.UpdateLayout();
      }

      private void addGrids( Grid g)
      {
         for (int i = 0; i < 4; i++)
         {
            for (int j   = 0; j < 2; j++)
            {
               Grid DynamicGrid = new Grid();
               DynamicGrid.Width = 400;
               DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
               DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
               DynamicGrid.ShowGridLines = true;
               DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);



               Grid.SetRow(DynamicGrid, i);
               Grid.SetColumn(DynamicGrid, j);
               g.Children.Add(DynamicGrid);
            }
         }
      }


      private void setRowsAndColumns(Grid grid)
      {
         int iLengthRow = 83;

         ColumnDefinition gridCol1 = new ColumnDefinition();
         ColumnDefinition gridCol2 = new ColumnDefinition(); 
         grid.ColumnDefinitions.Add(gridCol1);
         grid.ColumnDefinitions.Add(gridCol2); 

         // Create Rows
         RowDefinition gridRow1 = new RowDefinition();
         gridRow1.Height = new GridLength(iLengthRow);
         RowDefinition gridRow2 = new RowDefinition();
         gridRow2.Height = new GridLength(iLengthRow);
         RowDefinition gridRow3 = new RowDefinition();
         gridRow3.Height = new GridLength(iLengthRow);
         RowDefinition gridRow4 = new RowDefinition();
         gridRow3.Height = new GridLength(iLengthRow); 

         grid.RowDefinitions.Add(gridRow1);
         grid.RowDefinitions.Add(gridRow2);
         grid.RowDefinitions.Add(gridRow3);
         grid.RowDefinitions.Add(gridRow4);
      }
      #endregion

   }
}
