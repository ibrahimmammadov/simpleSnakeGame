using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Snake snake;
        Direction dir;
        PictureBox[] pb_snakeparts;
        bool cube = false;
        Random random = new Random();
        PictureBox pbcube;
        int point = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
        }
        private void NewGame()
        {
            cube = false;
            point = 0;
            snake = new Snake();
            dir = new Direction(10, 0);
            pb_snakeparts = new PictureBox[0];
            for (int i = 0; i < 2; i++)
            {
                Array.Resize(ref pb_snakeparts, pb_snakeparts.Length + 1);
                pb_snakeparts[i] = pb_add();
            }
            timer1.Start();
            button1.Enabled = false;
        }

        private PictureBox pb_add()
        {
            
            PictureBox pb = new PictureBox();
            pb.Size = new Size(10, 10);
            pb.BackColor = Color.Wheat;
            pb.Location = snake.GetDir(pb_snakeparts.Length - 1);
            panel1.Controls.Add(pb);
            return pb;
        }

        private void pb_update()
        {
            for (int i = 0; i < pb_snakeparts.Length; i++)
            {
                pb_snakeparts[i].Location = snake.GetDir(i);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Up||e.KeyCode==Keys.W)
            {
                if (dir._y!=10)
                {
                    dir = new Direction(0, -10);
                }
                e.SuppressKeyPress = true;
               
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (dir._y!=-10)
                {
                    dir = new Direction(0, 10);
                }
                e.SuppressKeyPress = true;

            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (dir._x != 10)
                {
                    dir = new Direction(-10, 0);
                }
                e.SuppressKeyPress = true;

            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (dir._x != -10)
                {
                    dir = new Direction(10, 0);
                }
                e.SuppressKeyPress = true;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Score: " + point.ToString();
            snake.move(dir);
            pb_update();
            createCube();
            EatCube();
            SnakeCrahshHimSelf();
            SnakeCrashWall();
        }

        public void createCube()
        {
            if (cube == false)
            {
                PictureBox pb = new PictureBox();
                pb.BackColor = Color.FromArgb(random.Next(20, 256), random.Next(20, 256), random.Next(20, 256));
                pb.Size = new Size(10, 10);
                pb.Location = new Point(random.Next(panel1.Width / 10) * 10, random.Next(panel1.Height / 10) * 10);
                pbcube = pb;
                cube = true;
                panel1.Controls.Add(pb);
            }
                
            
           
        }

        public void EatCube()
        {
            if (snake.GetDir(0) == pbcube.Location)
            {
                point += 10;
                snake.grow();
                Array.Resize(ref pb_snakeparts, pb_snakeparts.Length + 1);
                pb_snakeparts[pb_snakeparts.Length - 1] = pb_add();
                cube = false;
                panel1.Controls.Remove(pbcube);

            }
        }

        public void SnakeCrahshHimSelf()
        {
            for (int i = 1; i < snake.SnakeLong; i++)
            {
                if (snake.GetDir(0)==snake.GetDir(i))
                {
                    timer1.Stop();
                    MessageBox.Show("Game Over","Try Again",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    button1.Enabled = true;
                }
            }
        }


        public void SnakeCrashWall()
        {
            Point point1 = snake.GetDir(0);
            if (point1.X<0||point1.X>panel1.Width-10||point1.Y<0||point1.Y>panel1.Height-10)
            {
                timer1.Stop();
                MessageBox.Show("Game Over", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                button1.Enabled = true;
            }
        }

      
        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            NewGame();
        }
    }
}
