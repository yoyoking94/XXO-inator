using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true;           //true = x & false = O
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright 2021 © Yovish MOONESAMY\n" + "Developped in 2021\n" + "Why ? because i'm bored\n");
            // print message through a box
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();         // exit program
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;  //don't understand ask aaron 
            if (turn)                   // if turn = player 1
            {
                b.Text = "X";           // button text = X
            }
            else
            {
                b.Text = "O";           // button text = )
            }

            turn = !turn;               // change the turn X / O
            b.Enabled = false;          // desable the button
            turnCount++;
            
            verif();
        }

        private void verif()
        {
            bool winner = false;

            //horizontal verif
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                winner = true;
            }

            //vertical verif
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                winner = true;
            }

            //diagonal verif
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                winner = true;
            }

            if (winner)
            {
                desableButtons();
                String winnerP = "";
                if (turn)
                {
                    winnerP = "O";
                }
                else
                {
                    winnerP = "X";
                }
                MessageBox.Show(winnerP + " player win !");
            }
            else
            {
                if(turnCount == 9)
                {
                    MessageBox.Show("No Winner !");
                }
            }
        }

        private void desableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

    }
}
