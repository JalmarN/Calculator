using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitenRäknare
{
    public partial class Liten_Räknare : Form
    {
        Double värde = 0;
        String symbol = "";
        bool klickad_symbol = false;
        bool passerad_symbol = false;
        bool pressad_likamed = false;
        private void button_Click(object sender, EventArgs e)
        {
            if ((klickad_symbol) || (Resultat.Text == "0"))
                Resultat.Clear();

            //Detta tillsammans med "boolen klickad symbol gör så att resultatrutan töms då du skriver något efter du klickat på någon av symbolerna som plus, minus osv...
            klickad_symbol = false;
            Button b = (Button)sender;
            //Detta gör så att istället för att jag ger ett värde till knappen i koden genom "Resultat.Text + 1.Text kan jag bara ta värdet knappen fick redan under den grafiska processen så det inte behövs skrivas igen.

            Resultat.Text = Resultat.Text + b.Text;
        }

        public Liten_Räknare()
        {
            InitializeComponent();
        }


        private void Resultat_TextChanged(object sender, EventArgs e)
        {

        }

        private void CE_Click(object sender, EventArgs e)
        {
            Resultat.Clear();
            Resultat.Text = "0";
        }


        private void symbol_Click(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            Button b = (Button)sender;
            symbol = b.Text;

            if (!klickad_symbol && passerad_symbol)
            {
                likamed();  //valde att göra en ny private void av likamed så att jag lätt kan länka denna funktionen och likamed knappens funktion till samma.
            }
            else
            {
                värde = Double.Parse(Resultat.Text);
            }
            klickad_symbol = true;
            passerad_symbol = true;
            // dessa hjälper mig att få en tom ruta varje gång jag klickar på ett räknetecken och att räkna ut resultatet av att klicka på ett räcknetecken tre gånger. 

        }

        private void likamed_Click(object sender, EventArgs e)
        {
            likamed();

        }

        private void C_Click(object sender, EventArgs e)
        {
            Resultat.Text = "0";
            värde = 0;
            klickad_symbol = false;
            passerad_symbol = false;
        }

        private void Radera_Click(object sender, EventArgs e)
        {
            if (Resultat.Text.Length <= 0)
            {
                //Well.. den gör inget i detta fallet ju.
            }
            else if (Resultat.Text.Length > 0)
            {
                Resultat.Text = Resultat.Text.Remove(Resultat.Text.Length - 1);
            }
            //If satsen eftersom annars kraschar programmet ifall man försöker radera.
        }

        private void RotenUr_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            symbol = b.Text;
            värde = Double.Parse(Resultat.Text);
            klickad_symbol = true;
            Resultat.Text = (Math.Pow(värde, 0.5)).ToString();
            klickad_symbol = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (Resultat.Text == "0")
            {
                Resultat.Text = "Gör inte en Anton nu..";
            }
            else
            {
                Button b = (Button)sender;
                symbol = b.Text;
                värde = Double.Parse(Resultat.Text);
                klickad_symbol = true;
                Resultat.Text = (1 / värde).ToString();
                klickad_symbol = false;
            }
        }

        private void comma_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Resultat.Text = Resultat.Text + b.Text;

        }

        private void reverse_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            symbol = b.Text;
            värde = Double.Parse(Resultat.Text);
            klickad_symbol = true;
            Resultat.Text = (Double.Parse(Resultat.Text) * -1).ToString();
            klickad_symbol = false;

        }
        private void likamed()
        {
            if (pressad_likamed)
            {
                switch (symbol)
                {
                    case "+":
                        Resultat.Text = (värde + Double.Parse(Resultat.Text)).ToString();
                        break;
                    case "-":
                        Resultat.Text = (värde - Double.Parse(Resultat.Text)).ToString();
                        break;
                    case "x":
                        Resultat.Text = (värde * Double.Parse(Resultat.Text)).ToString();
                        break;
                    case "/":
                        Resultat.Text = (värde / Double.Parse(Resultat.Text)).ToString();
                        break;

                }
            }
            else
            {
                switch (symbol)
                {
                    case "+":
                        Resultat.Text = (värde + Double.Parse(Resultat.Text)).ToString();
                        break;
                    case "-":
                        Resultat.Text = (värde - Double.Parse(Resultat.Text)).ToString();
                        break;
                    case "x":
                        Resultat.Text = (värde * Double.Parse(Resultat.Text)).ToString();
                        break;
                    case "/":
                        Resultat.Text = (värde / Double.Parse(Resultat.Text)).ToString();
                        break;


                }
                värde = Double.Parse(Resultat.Text);
            }
            //Finns kanske snyggare sätt att göra dett på men har denna if satsen så att när jag klickar =, = så tar den det senaste värdet jag skrev in och gångar det med resultatet.


            klickad_symbol = false;
            passerad_symbol = false;

        }

    
    }
}