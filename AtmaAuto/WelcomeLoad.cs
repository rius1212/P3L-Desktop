using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtmaAuto
{
    public partial class WelcomeLoad : Form
    {
        int move = 2;
        public WelcomeLoad()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* panel2.Width += 2;
             if (panel2.Width > 303)
             {
                 panel2.Width = 0;
             }
             if (panel2.Width < 0)

             {
                 move = 2;
             }*/
              rider.Left += 2;
            panel2.Width += 2;
            if (rider.Left > 403 || panel2.Width > 303)
            {
                rider.Left = 82;
                panel2.Width = 10;
            }
            if (rider.Left < 150 || panel2.Width < 0)

            {
                move = 2;
            }
        }

        private void WelcomeLoad_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
