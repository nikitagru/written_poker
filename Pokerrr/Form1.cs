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
    public partial class Form1 : Form
    {
        private int _numberOfPlayers;
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox_numPlayers_MouseEnter(object sender, EventArgs e)
        {
            textBox_numPlayers.Text = "";
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            var temp = textBox_numPlayers.Text;
            try
            {
                _numberOfPlayers = Convert.ToInt32(temp);

                PlayWindow playWindow = new PlayWindow();
                playWindow.Width = 200 * _numberOfPlayers;
                playWindow.Height = (22 + (_numberOfPlayers * 2)) * 40;
                
                playWindow.Show();
            }
            catch
            {
                MessageBox.Show("Invalid Type of data");
            }
            
        }
    }
}
