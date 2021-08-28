using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class memoryMedium : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "b", "b", "v", "v", "w", "w", "z", "z","m","m",".",".","p","p","@","@","%","%","+","+","G","G"
        };
        List<string> iconsOpened = new List<string>();
        Label firstClicked, secondClicked;
        int time, jokersLeft, score, highscore = 0;
        bool gameOn = false;

        public memoryMedium()
        {
            InitializeComponent();
            AssignIcons2();
        }

        private void label_click(object sender, EventArgs e)
        {
            if (!gameOn)
            {
                return;
            }
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
                iconsOpened.Remove(firstClicked.Text.ToString());
                if (iconsOpened.Count > 0)
                    score += 200;
                lblScore.Text = "Score: " + score.ToString();
                firstClicked = null;
                secondClicked = null;
            }
            else
            {
                score -= 10;
                lblScore.Text = "Score: " + score.ToString();
                timer2.Start();
            }
        }

        private void CheckForWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            if (time < 150)
                score += (150 - time) * 10;
            score += 200;
            lblScore.Text = "Score: " + score.ToString();
            timer1.Stop();
            btnJoker.Enabled = false;
            if (score > highscore)
            {
                MessageBox.Show("HIGHSCORE!!! Your set a new highscore of " + score.ToString() + "!");
                highscore = score;
                lblHighscore.Text = "Highscore: " + highscore;
            }
            else
                MessageBox.Show("You won! Your score is " + score.ToString() + "!");
        }

       

        private void memoryMedium_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void btnJoker_Click(object sender, EventArgs e)
        {
            if (jokersLeft == 0)
                return;
            if (jokersLeft == 1)
                btnJoker.Enabled = false;
            timer4.Start();
            foreach (Label l in tableLayoutPanel1.Controls)
            {
                l.ForeColor = Color.GhostWhite;
            }
            jokersLeft--;
            lblJoker.Text = "Jokers left: " + jokersLeft.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (gameOn == true)
                return;

            timer3.Start();

            foreach (Label l in tableLayoutPanel1.Controls)
            {
                l.ForeColor = Color.GhostWhite;
            }

            time = 0;
            gameOn = true;
            timer1.Start();
            btnStart.Enabled = false;
            btnReset.Enabled = true;
            btnJoker.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (gameOn == false)
                return;

            btnStart.Enabled = true;
            gameOn = false;
            timer1.Stop();

            foreach (Label l in tableLayoutPanel1.Controls)
            {
                l.Text = "c";
                l.ForeColor = l.BackColor;
            }
            AssignIcons2();
            btnReset.Enabled = false;
            btnJoker.Enabled = false;
            lblTime.Text = "Time: 0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            lblTime.Text = "Time: " + time.ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();

            foreach (Label l in tableLayoutPanel1.Controls)
            {
                l.ForeColor = l.BackColor;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            foreach (Label l in tableLayoutPanel1.Controls)
            {
                foreach (string check in iconsOpened)
                {
                    if (l.Text == check)
                        l.ForeColor = l.BackColor;
                }
            }
        }

        private void AssignIcons2()
        {
            Label label;
            int randomNumber;
            if (icons.Count == 0)
                addItems();
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
            }
            addIconsOpened();
            jokersLeft = 3;
            lblJoker.Text = "Jokers left: " + jokersLeft.ToString();
            score = 0;
            lblScore.Text = "Score:";
        }

        private void addItems()
        {
            icons.Add("!");
            icons.Add("!");
            icons.Add("N");
            icons.Add("N");
            icons.Add(",");
            icons.Add(",");
            icons.Add("k");
            icons.Add("k");
            icons.Add("b");
            icons.Add("b");
            icons.Add("v");
            icons.Add("v");
            icons.Add("w");
            icons.Add("w");
            icons.Add("z");
            icons.Add("z");
            icons.Add("m");
            icons.Add("m");
            icons.Add(".");
            icons.Add(".");
            icons.Add("p");
            icons.Add("p");
            icons.Add("@");
            icons.Add("@");
            icons.Add("%");
            icons.Add("%");
            icons.Add("+");
            icons.Add("+");
            icons.Add("G");
            icons.Add("G");
        }

        private void addIconsOpened()
        {
            iconsOpened.Add("!");
            iconsOpened.Add("N");
            iconsOpened.Add(",");
            iconsOpened.Add("k");
            iconsOpened.Add("b");
            iconsOpened.Add("v");
            iconsOpened.Add("w");
            iconsOpened.Add("z");
            iconsOpened.Add("m");
            iconsOpened.Add(".");
            iconsOpened.Add("p");
            iconsOpened.Add("@");
            iconsOpened.Add("%");
            iconsOpened.Add("+");
            iconsOpened.Add("G");
        }
    }
}
