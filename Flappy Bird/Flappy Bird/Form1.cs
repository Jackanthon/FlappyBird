using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int mountainSpeed = 1;
        int gravity = 5;
        int score = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            bird.Top += gravity;
            bottomPipe.Left -= pipeSpeed;
            topPipe.Left -= pipeSpeed;
            mountains.Left -= mountainSpeed;
            scoreText.Text = "Score: " + score;

            if(bottomPipe.Left < -88)
            {
                bottomPipe.Left = 666;
                score++;
                if (score == 10 || score == 20) 
                {
                    pipeSpeed *= 2;
                }
            }
            if(topPipe.Left < - 120)
            {
                topPipe.Left = 450;
                score++;
                if (score == 10 || score == 20)
                {
                    pipeSpeed *= 2;
                }
            }
            if(bird.Bounds.IntersectsWith(bottomPipe.Bounds) ||
                bird.Bounds.IntersectsWith(topPipe.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds))
                {
                endGame();
                }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -25;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over!!";
            
        }
        private void restart()
        {
            Application.Restart();
        }

    }
}
