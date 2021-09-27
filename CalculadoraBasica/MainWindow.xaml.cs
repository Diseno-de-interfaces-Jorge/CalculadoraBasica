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
using System.Diagnostics;

namespace CalculadoraBasica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float operadorUno = float.Parse(OperadorUno.Text);
                float operadorDos = float.Parse(OperadorDos.Text);
                string operador = Operador.Text;
                float resultado = 0;


                switch (operador)
                {
                    case "+":
                        resultado = operadorUno + operadorDos;
                        break;
                
                    case "-":
                        resultado = operadorUno - operadorDos;
                        break;
                
                    case "*":
                        resultado = operadorUno * operadorDos;
                        break;
                
                    case "/":
                        resultado = operadorUno / operadorDos;
                        break;

                    default:
                        throw new FormatException("Formato de operador incorecto");//Esta linea no se deberia de ejecutar nunca pero por si acaso la pongo.
                        break;
                }
                Resultado.Text = resultado.ToString();
            }
            catch (FormatException error)
            {
                MessageBox.Show("Formato erroneo");
                Debug.WriteLine("Error: " + error.Message);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
                Debug.WriteLine("Error: " + error.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OperadorUno.Clear();
            OperadorDos.Clear();
            Operador.Clear();
            Resultado.Clear();
        }

        private void Operador_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Operador.Text.Equals("+") || Operador.Text.Equals("-") || Operador.Text.Equals("*") || Operador.Text.Equals("/"))
            {
                BotonCalcular.IsEnabled = true;
            }
            else
            {
                BotonCalcular.IsEnabled = false;
                MessageBox.Show("Operador no valido");//Deberia de lanzar una excepcion aqui?? pero no podria poner eltry en el mismo metodo o eso se supone

            }
        }
    }
}
