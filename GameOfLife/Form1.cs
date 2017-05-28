using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Generator;
namespace GameOfLife
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            int y = Convert.ToInt32(Math.Round(numericUpDown2.Value, 0));
            Generator.Generator.firstGen(30, 30);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Generator.Generator.Generate(30, 30);
        }
    }
}
