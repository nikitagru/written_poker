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
        List<Label> labels = new List<Label>();
        List<TextBox> playersTextbox = new List<TextBox>();

        public PlayWindow()
        {
            InitializeComponent();
        }

        private void CreatingNames(int windowWidth)
        {
            for (var i = 0; i < windowWidth / 200; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Location = new Point(i * 200 + 10, 5);
                playersTextbox.Add(textBox);
                this.Controls.Add(textBox);
            }
            playersTextbox[0].Location = new Point(30, 5);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string[] players = new string[playersTextbox.Count];

            for (var i = 0; i < players.Length; i++)
            {
                players[i] = playersTextbox[i].Text;
                playersTextbox[i].Dispose();
            }

            for (var i = 0; i < players.Length; i++)
            {
                Label name = new Label();
                name.Text = players[i];
                if (i == 0)
                {
                    name.Location = new Point(30, 5);
                } else
                {
                    name.Location = new Point(i * 200 + 10, 5);
                }
                name.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                this.Controls.Add(name);
            }
        }

        private void MakingTable(int windowWidth, int windowHeight)
        {
            var countOfIter = (36 / (windowWidth / 200)) * 2 + (windowWidth / 200) + 2;

            for (var i = 0; i <= windowWidth / 200; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Size = new Size(1, countOfIter * 30);
                pic.Location = new Point(i * 200, 0);
                this.Controls.Add(pic);
            }

            for (var j = 0; j <= countOfIter; j++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Size = new Size(windowWidth, 1);
                pic.Location = new Point(0, j * 30);
                this.Controls.Add(pic);
            }


            var maxCards = 36 / (windowWidth / 200);
            var iterations = 0;
            for (var j = 0; j < maxCards; j++)
            {
                Label label = new Label();
                label.Text = "" + j;
                label.Location = new Point(1, j * 30 + 5);
                label.Width = 19;
                this.Controls.Add(label);
                iterations++;
            }

            for (var i = 0; i < (windowWidth / 200); i++)
            {
                Label label = new Label();
                label.Text = "" + maxCards;
                label.Location = new Point(1, iterations * 30 + 5);
                label.Width = 19;
                this.Controls.Add(label);
                iterations++;
            }

            for (var i = maxCards - 1; i > 0; i--)
            {
                Label label = new Label();
                label.Text = "" + i;
                label.Location = new Point(1, iterations * 30 + 5);
                label.Width = 19;
                this.Controls.Add(label);
                iterations++;
            }

            for (var i = 0; i < 3; i++)
            {
                Label label = new Label();
                label.Text = "D";
                label.Location = new Point(1, iterations * 30 + 5);
                label.Width = 19;
                this.Controls.Add(label);
                iterations++;
            }
        }

        private void CreatingLabels(int windowWidth, List<Label> labels)
        {
            var countOfIter = (36 / (windowWidth / 200)) * 2 + (windowWidth / 200) + 2;

            for (var j = 1; j < countOfIter; j++)
            {
                for (var i = 0; i < windowWidth / 200; i++)
                {
                    Label label = new Label();
                    if (i == 0)
                    {
                        label.Location = new Point(25, j * 30 + 5);
                    } else
                    {
                        label.Location = new Point(i * 200 + 5, j * 30 + 5);
                    }
                    
                    label.Text = "" + j + "" + i;
                    this.Controls.Add(label);
                    labels.Add(label);
                }
            }
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            
            
        }

        private void PlayWindow_Load(object sender, EventArgs e)
        {
            MakingTable(this.Width, this.Height);


            var countOfIter = (36 / (this.Width / 200)) * 2 + (this.Width / 200) + 2;
            PictureBox stepColumn = new PictureBox();
            stepColumn.BackColor = Color.Black;
            stepColumn.Size = new Size(1, countOfIter * 30);
            stepColumn.Location = new Point(20, 0);
            this.Controls.Add(stepColumn);

            Button button_step = new Button();
            button_step.Text = "Next step";
            button_step.Size = new Size(100, 30);
            button_step.Location = new Point(this.Width + 20, 80);
            this.Controls.Add(button_step);

            CreatingLabels(this.Width, labels);

            CreatingNames(this.Width);
            Button button_Save = new Button();
            button_Save.Text = "Save players names";
            button_Save.Size = new Size(100, 50);
            button_Save.Location = new Point(this.Width + 20, 10);
            this.Controls.Add(button_Save);

            button_Save.Click += SaveButton_Click;

            button_step.Click += StepButton_Click;




            this.Width += 180;
            
           
        }

    }
}
