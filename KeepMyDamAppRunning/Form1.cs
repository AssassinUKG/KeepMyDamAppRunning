using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepMyDamAppRunning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Exe's (*.exe)|*.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                }
            }
        }

        private Runcl run;
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateStatusStrip("Running...");
            //if (textBox2.Text.Length <= 0)
            //{
            //    MessageBox.Show("Please enter the processname!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
                 run = new Runcl(textBox1.Text);
                run.Start();
           // }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            run?.Stop();
            UpdateStatusStrip("not running...");
        }



        private void UpdateStatusStrip(string message)
        {
            this.Invoke(new MethodInvoker(() =>
            {

                toolStripStatusLabel2.Text = message;

            }));

        }


    }
}
