using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaserGame
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Size = new Size(525, 590);

            MirrorCounter.Value = 10;
            TargetCounter.Value = 5;
        }


        private void btn_Click(object sender, EventArgs e)
        {
            GameForm gameform = new GameForm();
            gameform.mirrorCount = (int)MirrorCounter.Value;
            gameform.targetCount = (int)TargetCounter.Value;
            gameform.Show();
            Hide();
        }

        private void btn_MouseHover(object sender, EventArgs e)
        {
            btn.Image = LaserGame.Properties.Resources.btn_hover;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            btn.Image = LaserGame.Properties.Resources.btn;
        }
    }
}
