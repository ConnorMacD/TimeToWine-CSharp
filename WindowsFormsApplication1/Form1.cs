using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        int timeleft;
        Boolean wine = true;
        Boolean grab = false;

        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
        }


        private void countdown_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (wine)
            {
                if (timeleft > 0)
                {
                    // Display the new time left
                    // by updating the Time Left label.
                    timeleft -= 1;
                    Console.Write(timeleft);
                    wineL.Text = timeleft + "";
                }
                else
                {
                    wineL.Text = timeleft + "";
                    timer1.Stop();
                    timeleft = 3;
                    grabL.Text = timeleft + "";
                    wine = false;
                    grab = true;
                    timer1.Start();
                }
            }
            if (grab)
            {
                if (timeleft > 0)
                {
                    // Display the new time left
                    // by updating the Time Left label.
                    timeleft -= 1;
                    
                    grabL.Text = timeleft + "";
                }
                else
                {
                    grabL.Text = timeleft + "";
                    timer1.Stop();
                    timeleft = Int32.Parse(countdown.Text);
                    wineL.Text = timeleft + "";
                    wine = true;
                    grab = false;
                    timer1.Start();
                }
            }
        }
        
        //start
        private void button3_Click(object sender, EventArgs e)
        {
            timeleft = Int32.Parse(countdown.Text);
            countdown.Enabled = false;
            wineL.Text = timeleft + "";
            timer1.Interval = 1000;
            timer1.Start();
        }

        //stop
        private void button2_Click(object sender, EventArgs e)
        {
            timeleft = 0;
            wineL.Text = "0";
            grabL.Text = "0";
            Boolean wine = true;
            Boolean grab = false;
            countdown.Enabled = true;
            timer1.Stop();
        }


    }
}
