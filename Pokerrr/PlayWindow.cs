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
        List<CheckBox> darkCheck = new List<CheckBox>();
        List<TextBox> playersRequest = new List<TextBox>();
        List<TextBox> finallyRequests = new List<TextBox>();
        int[] playersScore;


        private int stepNumber = 0;
        private int playersCount = 0;

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
                playersCount++;
            }
            playersTextbox[0].Location = new Point(30, 5);
            playersScore = new int[playersCount];
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

        private void MakingTable(int windowWidth)
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
                if (j == 0) label.Text = "";
                else label.Text = "" + j;
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
                    
                    //label.Text = "" + j + "" + i;
                    this.Controls.Add(label);
                    labels.Add(label);
                }
            }
        }

        private void CreatingStepLayout(int windowWidth)
        {
            Label stepTitle = new Label();
            stepTitle.Text = "Введите количество запрашиваемых взяток";
            stepTitle.Width = 300;
            stepTitle.Location = new Point(windowWidth + 150, 10);
            this.Controls.Add(stepTitle);

            for (var i = 1; i <= windowWidth / 200; i++)
            {
                TextBox requests = new TextBox();
                requests.Location = new Point(stepTitle.Location.X, stepTitle.Location.Y + 30 * i);
                requests.Width = 50;
                playersRequest.Add(requests);
                this.Controls.Add(requests);

                CheckBox dark = new CheckBox();
                dark.Text = "Темная";
                dark.Width = 300;
                dark.Location = new Point(stepTitle.Location.X + requests.Width + 10, stepTitle.Location.Y + 30 * i);
                darkCheck.Add(dark);
                this.Controls.Add(dark);
            }

            Label subTitle = new Label();
            subTitle.Text = "Количество итоговых взяток";
            subTitle.Width = 300;
            subTitle.Location = new Point(stepTitle.Location.X, windowWidth / 200 * 50 + 20 );
            this.Controls.Add(subTitle);

            for (int i = 1; i <= windowWidth / 200; i++)
            {
                TextBox finRequest = new TextBox();
                finRequest.Location = new Point(subTitle.Location.X, subTitle.Location.Y + 30 * i);
                finRequest.Width = 50;
                finallyRequests.Add(finRequest);
                this.Controls.Add(finRequest);
            }
        }

        private string ScoreCounter(int iterationNum)
        {
            var playerReq = Convert.ToInt32(playersRequest[iterationNum].Text);
            var dark = darkCheck[iterationNum].Checked;
            var finReq = Convert.ToInt32(finallyRequests[iterationNum].Text);

            if (dark)
            {
                if (playerReq == finReq)
                {
                    var answer = ((finReq * 10) * 2).ToString();
                    return answer;
                } else if (playerReq > finReq)
                {
                    var answer = (-(((playerReq - finReq) * 10) * 2)).ToString();
                    return answer;
                } else if (playerReq < finReq)
                {
                    var answer = ((finReq * 2) * 2).ToString();
                    return answer;
                }
                return "";
            } else
            {
                if (playerReq == finReq)
                {
                    var answer = (finReq * 10).ToString();
                    return answer;
                }
                else if (playerReq > finReq)
                {
                    var answer = ((-(playerReq - finReq) * 10)).ToString();
                    return answer;
                }
                else if (playerReq < finReq)
                {
                    var answer = (finReq * 2).ToString();
                    return answer;
                }
                return "";
            }
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            var stringStep = 0;
            var step = stepNumber;
            for (var i = stepNumber; i < step + playersCount; i++)
            {
                playersScore[stringStep] += Convert.ToInt32(ScoreCounter(stringStep));
                labels[i].Text = (playersScore[stringStep]).ToString();
                stepNumber++;
                stringStep++;
            }
            
        }

        private void PlayWindow_Load(object sender, EventArgs e)
        {
            #region layout
            MakingTable(this.Width);


            var countOfIter = (36 / (this.Width / 200)) * 2 + (this.Width / 200) + 2;
            PictureBox stepColumn = new PictureBox();
            stepColumn.BackColor = Color.Black;
            stepColumn.Size = new Size(1, countOfIter * 30);
            stepColumn.Location = new Point(20, 0);
            this.Controls.Add(stepColumn);

            Button button_step = new Button();
            button_step.Text = "Посчитать";
            button_step.Size = new Size(100, 30);
            button_step.Location = new Point(this.Width + 20, 80);
            this.Controls.Add(button_step);

            CreatingLabels(this.Width, labels);

            CreatingNames(this.Width);
            Button button_Save = new Button();
            button_Save.Text = "Сохранить имена игроков";
            button_Save.Size = new Size(100, 50);
            button_Save.Location = new Point(this.Width + 20, 10);
            this.Controls.Add(button_Save);

            button_Save.Click += SaveButton_Click;
            #endregion

            CreatingStepLayout(this.Width);

            button_step.Click += StepButton_Click;

            this.WindowState = FormWindowState.Maximized;


        }

    }
}
