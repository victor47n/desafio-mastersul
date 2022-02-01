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

namespace TesteDeLogicaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cbSensor2.IsChecked = true;
            cbSensor4.IsChecked = true;
        }

        private void HandleSensors(object sender, RoutedEventArgs e)
        {
            bool sensor1 = cbSensor1.IsChecked ?? false;
            bool sensor2 = cbSensor2.IsChecked ?? false;
            bool sensor3 = cbSensor3.IsChecked ?? false;
            bool sensor4 = cbSensor4.IsChecked ?? false;

            try
            {
                if (sensor1 && !sensor2)
                {
                    if (sensor3 && !sensor4)
                    {
                        throw new Exception("Os sensores 2 e 4 estão com problema");
                    }

                    throw new Exception("Sensor 2 está com problema");
                }
                else if (sensor3 && !sensor4)
                {
                    throw new Exception("Sensor 4 está com problema");
                }

                bool caixaUmCheia = sensor1 && sensor2;
                bool caixaDoisCheia = sensor3 && sensor4;

                bool valvula = false;
                bool bomba = false;

                if (!caixaDoisCheia)
                {
                    valvula = !sensor4;
                    bomba = false;
                }
                if (!caixaUmCheia && caixaDoisCheia)
                {
                    bomba = !sensor2;
                }

                tbException.Text = "";
                tbBomba.Text = bomba ? "Ativada" : "Desativada";
                tbBomba.Foreground = bomba ? Brushes.Green : Brushes.Red;
                tbValvula.Text = valvula ? "Ativada" : "Desativada";
                tbValvula.Foreground = valvula ? Brushes.Green : Brushes.Red;
            }
            catch (Exception ex)
            {
                tbException.Text = ex.Message;
            }
        }
    }
}
