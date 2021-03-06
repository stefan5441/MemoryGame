using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class memoryEasy : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "b", "b", "v", "v", "w", "w", "z", "z"
        };
        List<string> iconsOpened = new List<string>();

        Label firstClicked, secondClicked;

        int time, jokersLeft, score, highscore = 0;
        bool gameOn = false;

        public memoryEasy()
        {
            InitializeComponent();
            AssignIcons();
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

            if (clickedLabel.ForeColor == Color.Black)
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;
            CheckForWinner();

            if (firstClicked.Text == secondClicked.Text)
            {
                iconsOpened.Remove(firstClicked.Text.ToString());
                if(iconsOpened.Count > 0)
                    score += 200;
                lblScore.Text = "Score: " + score.ToString();
                firstClicked = null;
                secondClicked = null;
            }
            else
            {
                score -= 10;
                lblScore.Text = "Score: " + score.ToString();
                timer1.Start();
            }
        }

        private void CheckForWinner()
        {
            Label label;
            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            if (time < 100)
                score += (100 - time) * 10;
            score += 200;
            lblScore.Text = "Score: " + score.ToString();
            timer2.Stop();
            btnJoker.Enabled = false;
            if(score > highscore)
            {
                MessageBox.Show("HIGHSCORE!!! Your set a new highscore of " + score.ToString() + "!");
                highscore = score;
                lblHighscore.Text = "Highscore: " + highscore;
            } else
                MessageBox.Show("You won! Your score is " + score.ToString() + "!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void memoryEasy_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time++;
            lblTime.Text = "Time: " + time.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (gameOn == true)
                return;

            timer3.Start();

            foreach (Label l in tableLayoutPanel1.Controls)
            {
                l.ForeColor = Color.Black;
            }

            time = 0;
            gameOn = true;
            timer2.Start();
            btnStart.Enabled = false;
            btnReset.Enabled = true;
            btnJoker.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();

            foreach (Label l in tableLayoutPanel1.Controls)
            {
                l.ForeColor = l.BackColor;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (gameOn == false)
                return;

            btnStart.Enabled = true;
            gameOn = false;
            timer2.Stop();

            foreach (Label l in tableLayoutPanel1.Controls)
            {
                l.Text = "c";
                l.ForeColor = l.BackColor;
            }
            AssignIcons();
            btnReset.Enabled = false;
            btnJoker.Enabled = false;
            lblTime.Text = "Time: 0";
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
                l.ForeColor = Color.Black;
            }
            jokersLeft--;
            lblJokersLeft.Text = "Jokers left: " + jokersLeft.ToString();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            foreach (Label l in tableLayoutPanel1.Controls)
            {
                foreach(string check in iconsOpened)
                {
                    if (l.Text == check)
                        l.ForeColor = l.BackColor;
                }
            }
        }

        private void AssignIcons()
        {
            Label label;
            int randomNumber;
            if(icons.Count == 0)
                addItems();
            for (int i=0; i < tableLayoutPanel1.Controls.Count; i++)
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
            lblJokersLeft.Text = "Jokers left: " + jokersLeft.ToString();
            score = 0;
            lblScore.Text = "Score:";
        }
    }
}
