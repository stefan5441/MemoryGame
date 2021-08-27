using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class memoryHard : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "b", "b", "v", "v", "w", "w", "z", "z", 
            "m", "m", ".", ".", "p", "p", "@", "@", "%", "%", "+", "+", "G", "G",
            "o", "o", "Y", "Y", "V", "V", "O", "O", "L", "L", "Z", "Z"
        };

        Label firstClicked, secondClicked;

        public memoryHard()
        {
            InitializeComponent();
            AssignIcons();
        }

        private void label_click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.GhostWhite)
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.GhostWhite;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.GhostWhite;

            CheckForWinner();

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }
            else
                timer1.Start();
        }

        private void CheckForWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel2.Controls.Count; i++)
            {
                label = tableLayoutPanel2.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("You won!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void AssignIcons()
        {
            Label label;
            int randomNumber;
            for (int i = 0; i < tableLayoutPanel2.Controls.Count; i++)
            {
                if (tableLayoutPanel2.Controls[i] is Label)
                    label = (Label)tableLayoutPanel2.Controls[i];
                else
                    continue;
                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
            }
        }
    }
}
