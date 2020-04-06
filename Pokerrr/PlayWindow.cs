using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokerrr
{
    public partial class PlayWindow : Form
    {
        public PlayWindow()
        {
            InitializeComponent();
        }

        private void MakingTable(int windowWidth, int windowHeight)
        {
            for (var i = 0; i < windowWidth / 200; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Size = new Size(1, windowHeight);
                pic.Location = new Point(i * 200, 0);
                this.Controls.Add(pic);
            }

            for (var j = 0; j <= 22 + ((windowWidth / 200) * 2); j++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Size = new Size(windowWidth, 1);
                pic.Location = new Point(0, j * 30);
                this.Controls.Add(pic);
            }
        }

        private void PlayWindow_Load(object sender, EventArgs e)
        {
            MakingTable(this.Width, this.Height);

            Button button_step = new Button();
            button_step.Text = "Next step";
            button_step.Size = new Size(100, 30);
            button_step.Location = new Point(this.Width + 20, 50);
            this.Controls.Add(button_step);
            this.Width += 180;
        }

    }
}
