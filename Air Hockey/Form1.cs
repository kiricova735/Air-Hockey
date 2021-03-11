/*Kiril Covaliov
 03/11/21
 Air Hockey Summative */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Air_Hockey
{
    public partial class Form1 : Form
    {   //Audio
        SoundPlayer puckhit1 = new SoundPlayer(Properties.Resources.puckhit1);
        SoundPlayer score = new SoundPlayer(Properties.Resources.score);
        SoundPlayer win = new SoundPlayer(Properties.Resources.win);
        SoundPlayer bounceOffWall = new SoundPlayer(Properties.Resources.bounceOffWall);

        //Global variables
        int stick1X = 10;
        int stick1Y = 200;
        int player1Score = 0;

        int stick2X = 770;
        int stick2Y = 200;
        int player2Score = 0;

        int stickWidth = 25;
        int stickHeight = 25;
        int stickSpeed = 6;

        int puckX = 396;
        int puckY = 220;
        int puckXSpeed = 5;
        int puckYSpeed = 5;
        int puckWidth = 12;
        int puckHeight = 12;

        int goal1X = 5;
        int goal1Y = 140;
        int goal2X = 785;
        int goal2Y = 140;

        int goalWidth = 10;
        int goalHeight = 180;

        int topBorderX = 0;
        int topBorderY = 50;
        int topBorderWidth = 800;
        int topBorderHeight = 10;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush maroonBrush = new SolidBrush(Color.Maroon);
        Pen maroonPen = new Pen(Color.Maroon, 2);
        Pen redPen = new Pen(Color.Red, 2);
        Pen bigRedPen = new Pen(Color.Red, 5);
        Pen blackPen = new Pen(Color.Black, 2);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {   
            //center line
            e.Graphics.DrawRectangle(redPen, 400, 50, 5, 360);
            e.Graphics.FillRectangle(redBrush, 400, 50, 5, 360);
            //center circle
            e.Graphics.DrawEllipse(bigRedPen, 325, 160, 150, 150);           
            //player 1 stick
            e.Graphics.DrawEllipse(blackPen, stick1X, stick1Y, stickWidth, stickHeight);
            e.Graphics.FillEllipse(blackBrush, stick1X, stick1Y, stickWidth, stickHeight);
            //player 2 stick
            e.Graphics.DrawEllipse(blackPen, stick2X, stick2Y, stickWidth, stickHeight);
            e.Graphics.FillEllipse(blackBrush, stick2X, stick2Y, stickWidth, stickHeight);
            //puck
            e.Graphics.DrawEllipse(maroonPen, puckX, puckY, puckWidth, puckHeight);
            e.Graphics.FillEllipse(maroonBrush, puckX, puckY, puckWidth, puckHeight);
            //top border
            e.Graphics.DrawRectangle(redPen, topBorderX, topBorderY, topBorderWidth, topBorderHeight);
            e.Graphics.FillRectangle(redBrush, topBorderX, topBorderY, topBorderWidth, topBorderHeight);
            //bottom border
            e.Graphics.DrawRectangle(redPen, 0, 400, 800, 10);
            e.Graphics.FillRectangle(redBrush, 0, 400, 800, 10);
            //bottom left net border
            e.Graphics.DrawRectangle(redPen, 0, 50, 10, 90);
            e.Graphics.FillRectangle(redBrush, 0, 50, 10, 90);
            //top left net border
            e.Graphics.DrawRectangle(redPen, 0, 320, 10, 90);
            e.Graphics.FillRectangle(redBrush, 0, 320, 10, 90);
            //bottom right net border
            e.Graphics.DrawRectangle(redPen, 790, 320, 10, 90);
            e.Graphics.FillRectangle(redBrush, 790, 320, 10, 90);
            //top right net border
            e.Graphics.DrawRectangle(redPen, 790, 50, 10, 90);
            e.Graphics.FillRectangle(redBrush, 790, 50, 10, 90);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e) //When pressing down keys
        {
            switch (e.KeyCode)
            {

                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e) //When keys are not pressed
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }
        private void Timer1_Tick(object sender, EventArgs e) //Game engine
        {
            //move ball 

            puckX += puckXSpeed;
            puckY += puckYSpeed;

            //move player 1 
            if (wDown == true && stick1Y > 60)
            {
                stick1Y -= stickSpeed;
            }

            if (sDown == true && stick1Y < 370)
            {
                stick1Y += stickSpeed;
            }
            if (aDown == true && stick1X > 10)
            {
                stick1X -= stickSpeed;
            }
            if (dDown == true && stick1X > 0)
            {
                stick1X += stickSpeed;
            }

            //move player 2 
            if (upArrowDown == true && stick2Y > 60)
            {
                stick2Y -= stickSpeed;
            }

            if (downArrowDown == true && stick2Y < 370)
            {
                stick2Y += stickSpeed;
            }
            if (leftArrowDown == true && stick2X < 800)
            {
                stick2X -= stickSpeed;
            }
            if (rightArrowDown == true && stick2X < this.Width - stickWidth - 10)
            {
                stick2X += stickSpeed;
            }

            //checking for ball to wall collision
            if (puckY < 60)
            {
                puckYSpeed *= -1;
                bounceOffWall.Play();
            }
            if (puckY > 390)
            {
                puckYSpeed *= -1;
                bounceOffWall.Play();
            }
            if (puckX < 10)
            {
                puckXSpeed *= -1;
                bounceOffWall.Play();
            }
            if (puckX > 780)
            {
                puckXSpeed *= -1;
                bounceOffWall.Play();
            }

            //create Rectangles of objects on screen to be used for collision detection 
            Rectangle player1Rec = new Rectangle(stick1X, stick1Y, stickWidth, stickHeight);
            Rectangle player2Rec = new Rectangle(stick2X, stick2Y, stickWidth, stickHeight);
            Rectangle ballRec = new Rectangle(puckX, puckY, puckWidth, puckHeight);
            Rectangle goalNetLeft = new Rectangle(goal1X, goal1Y, goalWidth, goalHeight);
            Rectangle goalNetRight = new Rectangle(goal2X, goal2Y, goalWidth, goalHeight);
            
            //check if ball hits either stick. If it does change the direction 
            //and place the ball in front of the stick hit 

            if (player1Rec.IntersectsWith(ballRec))
            {
                puckXSpeed *= -1;
                puckX = stick1X + stickWidth + 1;
                puckhit1.Play();

            }

            if (player2Rec.IntersectsWith(ballRec))
            {
                puckXSpeed *= -1;
                puckX = stick2X + puckWidth + 1;
                puckhit1.Play();
            }

            if (ballRec.IntersectsWith(goalNetLeft))
            {
                player2Score++;

                playerScore2.Text = $"{player2Score}";

                puckX = 396;
                puckY = 220;

                stick1Y = 200;
                stick1X = 10;
                stick2Y = 200;
                stick2X = 770;
                score.Play();
            }
            if (ballRec.IntersectsWith(goalNetRight))
            {
                player1Score++;

                playerScore1.Text = $"{player1Score}";

                puckX = 396;
                puckY = 220;

                stick1Y = 200;
                stick1X = 10;
                stick2Y = 200;
                stick2X = 770;
                score.Play();
            }
       
            //check if either player won     

            if (player1Score == 3)
            {
                playerScore1.Text = "Player 1 Wins!";
                timer1.Enabled = false;
                win.Play();
            }
            if (player2Score == 3)
            {
                playerScore2.Text = "Player 2 Wins!";
                timer1.Enabled = false;
                win.Play();
            }
            Refresh();
        }
    }
}

