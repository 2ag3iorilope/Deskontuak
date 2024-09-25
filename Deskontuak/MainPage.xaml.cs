using System;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;

namespace Deskontuak
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void Onirtenbutton(object sender, EventArgs e)
        {
            Application.Current!.Quit();
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;

            // Validar si el nuevo texto es numérico
            if (!IsTextNumeric(e.NewTextValue))
            {
                entry.Text = e.OldTextValue; // Revertir al viejo valor si no es numérico
            }
        }

        private bool IsTextNumeric(string text)
        {
            // Validar si el texto está vacío o es numérico
            return string.IsNullOrEmpty(text) || Regex.IsMatch(text, @"^-?\d+(\.\d+)?$");
        }

        // Método que calcula el total
        private void CalculateTotal()
        {
            var cantidadText = KantitateEntry.Text;
            var precioText = PrezioaEntry.Text;
            var totalEntry = DeneraKPEntry;
             
            
            if (string.IsNullOrEmpty(cantidadText) || string.IsNullOrEmpty(precioText))
            {
                totalEntry.Text = string.Empty; 
                return;
            }

            if (decimal.TryParse(cantidadText, out decimal cantidad) &&
                decimal.TryParse(precioText, out decimal precio))
            {
               
                if (cantidad >= 10 && cantidad < 100)
                {
                    Deskontuaentry.Text = "2";
                }
                else if (cantidad >= 100 && cantidad < 1000)
                {
                    Deskontuaentry.Text = "5";
                }
                else if (cantidad >= 1000)
                {
                    Deskontuaentry.Text = "10";
                }

                
              var bezkopp =  BezEntry.Text = "21";
                decimal bezkopurua;


                if (decimal.TryParse(bezkopp, out bezkopurua))
                {
                    
                    BezEntry.Text = bezkopurua.ToString(); 
                }
                else
                {
                 
                    BezEntry.Text = string.Empty; 
                }



                var dekontuakop = Deskontuaentry.Text;
                if (decimal.TryParse(dekontuakop, out decimal deskontuaakop))
                {


                    var total = cantidad * precio;

              
                    var descuentoTotal = total * (deskontuaakop / 100);

                 
                    var totalConDescuento = total - descuentoTotal;

                    var Beztotala = total * (bezkopurua / 100);

                    var totalbezarekin = total + Beztotala;

                    var totalafinala = totalbezarekin - descuentoTotal;

                    PrezioDeskontuEntry.Text = totalConDescuento.ToString("F2");

                    totalEntry.Text = total.ToString("F2");
                    BezTotalaEntry.Text=totalbezarekin.ToString("F2");
                    OrdaintzekoGuztiaEntry.Text = totalafinala.ToString("F2");
                }
                else
                {
                   
                    totalEntry.Text = string.Empty;
                }
            }
            else
            {
               
                totalEntry.Text = string.Empty;
            }
        }
    }
}
