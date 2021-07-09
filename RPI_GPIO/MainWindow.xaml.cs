using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Device.Gpio;

namespace RPI_GPIO
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GpioController controller;


        public MainWindow()
        {

            

            try
            {
                controller = new GpioController();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            Console.Write("Initilized.... \n");
            InitializeComponent();
        }

        public void SetSelectedPin(int pin, Button btn)
        {
            try
            {
                if (!controller.IsPinOpen(pin))
                {
                    controller.OpenPin(pin, PinMode.Output);
                }

                string Status = controller.Read(pin).ToString();

                MessageBox.Show(Status);

                if (Status == "Low")
                {
                    controller.Write(pin, PinValue.High);
                    btn.Background = Brushes.Green;
                }
                else
                {
                    controller.Write(pin, PinValue.Low);
                    btn.Background = Brushes.Red;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Mouse_Click_Btn(object sender, MouseButtonEventArgs e)
        {
            Button BTN = (Button)sender;
            SetSelectedPin(Convert.ToInt32(BTN.Tag), BTN);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
