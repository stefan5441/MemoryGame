using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            new memoryEasy().Show();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            new memoryMedium().Show();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            new memoryHard().Show();
        }
    }
}
