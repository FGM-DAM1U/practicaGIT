using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            char tipoTelegrama = 'o';//Los telegramas son ordinarios por defecto
            int numPalabras = 1; //Inicializado a 1 en vez de 0 para el contador de palabras
            double coste = 0;
            int i = 0; //Para arreglar el contador de palabras

            //Leo el telegrama
            textoTelegrama = txtTelegrama.Text;
            //Por si se pulsa Calcular con el texto vacío (único caso de Coste=0...)
            if (txtTelegrama.Text != "")
            {
                // telegrama urgente?
                if (rbUrgente.Checked)
                    tipoTelegrama = 'u';
                if (rbOrdinario.Checked) // Redundante puesto que los telegramas son ordinarios por defecto, pero lo añado para justificar el cambio de checkbox a radiobutton.
                    tipoTelegrama = 'o';
                //Obtengo el número de palabras que forma el telegrama, ahora CORRECTAMENTE
                //(siempre que no se introduzcan varios espacios o saltos de línea seguidos...)
                while (i < textoTelegrama.Length)
                {
                    if (textoTelegrama[i] == ' ' || textoTelegrama[i] == '\n' || textoTelegrama[i] == '\t')
                        numPalabras++;
                    i++;
                }
                //Si el telegrama es ordinario
                if (tipoTelegrama == 'o')
                {
                    if (numPalabras <= 10)
                        coste = 2.5;
                    else
                        coste = 2.5 + 0.5 * (numPalabras - 10);
                }
                //Si el telegrama es urgente
                if (tipoTelegrama == 'u')
                {
                    if (numPalabras <= 10)
                        coste = 5;
                    else
                        coste = 5 + 0.75 * (numPalabras - 10);
                }
            }
            txtPrecio.Text = coste.ToString() + " Euros";
        }
    }
}
