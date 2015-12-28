using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test str 
            MessageBox.Show("2015. 12. 28 GitHub 생성.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("버튼 추가");
        }
    }
}
