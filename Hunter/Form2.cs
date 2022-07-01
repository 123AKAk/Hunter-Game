using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hunter
{
    public partial class Form2 : Form
    {
        private List<string> Files;

        Timer timer1 = new Timer();
        Timer timer2 = new Timer();

        private int time1 = 12;
        private int time2 = 6;
        private int time3 = 4;
        public Form2()
        {
            InitializeComponent();

            btnimage.ImageAlign = ContentAlignment.MiddleCenter;
            btnimage.BackgroundImageLayout = ImageLayout.Stretch;

            //gets username from Form1
            name.Text =  Form1.username;
        }

        int scorea = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            //btn image

            //onclick increments the score of the user
            scorea++;            

            score.Text = scorea.ToString();

            btnimage.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //restart
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            // start btn
            if (radioButton1.Checked == true)
            {
                // basic settings.
                var ext = new List<string> { ".jpg", ".gif", ".png" };

                // we use same directory where program is.
                string targetDirectory = Directory.GetCurrentDirectory();

                // Here we create our list of files
                // New list
                // Use GetFiles to getfilenames
                // Filter unwanted stuff away (like our program)
                Files = new List<string>(Directory.GetFiles(targetDirectory, "*.*", SearchOption.TopDirectoryOnly).Where(s => ext.Any(a => s.EndsWith(a))));

                // Create timer to call timer1_Tick every 3 seconds.
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 seconds
                timer1.Start();

                // Show first picture so we dont need wait 3 secs.
                ChangePicture();
                btnimage.Enabled = true;

                timer2 = new System.Windows.Forms.Timer();
                timer2.Tick += new EventHandler(timera_Tick);
                timer2.Interval = 2000; // 2 seconds
                timer2.Start();
            }
            else if (radioButton2.Checked == true)
            {
                // basic settings.
                var ext = new List<string> { ".jpg", ".gif", ".png" };

                // we use same directory where program is.
                string targetDirectory = Directory.GetCurrentDirectory();

                // Here we create our list of files
                // New list
                // Use GetFiles to getfilenames
                // Filter unwanted stuff away (like our program)
                Files = new List<string>(Directory.GetFiles(targetDirectory, "*.*", SearchOption.TopDirectoryOnly).Where(s => ext.Any(a => s.EndsWith(a))));

                // Create timer to call timer1_Tick every 3 seconds.
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer2_Tick);
                timer1.Interval = 1000; // 1 seconds
                timer1.Start();

                // Show first picture so we dont need wait 3 secs.
                ChangePicture();
                btnimage.Enabled = true;

                timer2 = new System.Windows.Forms.Timer();
                timer2.Tick += new EventHandler(timera_Tick);
                timer2.Interval = 1000; // 1 seconds
                timer2.Start();
            }
            else if (radioButton3.Checked == true)
            {
                // basic settings.
                var ext = new List<string> { ".jpg", ".gif", ".png" };

                // we use same directory where program is.
                string targetDirectory = Directory.GetCurrentDirectory();

                // Here we create our list of files
                // New list
                // Use GetFiles to getfilenames
                // Filter unwanted stuff away (like our program)
                Files = new List<string>(Directory.GetFiles(targetDirectory, "*.*", SearchOption.TopDirectoryOnly).Where(s => ext.Any(a => s.EndsWith(a))));

                // Create timer to call timer1_Tick every 3 seconds.
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer3_Tick);
                timer1.Interval = 1000; // 1 seconds
                timer1.Start();

                // Show first picture so we dont need wait 3 secs.
                ChangePicture();
                btnimage.Enabled = true;

                timer2 = new System.Windows.Forms.Timer();
                timer2.Tick += new EventHandler(timera_Tick);
                timer2.Interval = 550; // 0.8 seconds
                timer2.Start();
            }
            else
            {
                MessageBox.Show("Select Difficulty before procedding");
            }
        }
        
        //controls the movement of the picture
        int i = 0;
        private void timera_Tick(object sender, EventArgs e)
        {
            // Time to get new one.
            ChangePicture();

            //int maxLeft = Convert.ToInt32(game_form.Width - btnimage.Width);
            //int maxTop = Convert.ToInt32(game_form.Height - btnimage.Height);
            //Random rand = new Random();
            //btnimage.Margin = new Padding(rand.Next(maxLeft), rand.Next(maxTop), 0, 0);

            //changes the postion of the button at random 
            Random x = new Random();

            i++;
            Point pt = new Point(
                int.Parse(x.Next(400).ToString()),
                int.Parse(x.Next(250).ToString())
                );
            btnimage.Location = pt;

            timer2.Stop();
            timer2.Start();

            btnimage.Enabled = true;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Time to get new one.
            //ChangePicture();
            if (time1 > 0)
            {
                if (time1 <= 10)
                {
                    if (time1 % 2 == 0)
                    {
                        lblTime.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblTime.ForeColor = Color.Black;
                    }
                    time1--;
                    lblTime.Text = string.Format("00:0{0}:0{1}", time1 / 60, time1 % 60);
                }
                else
                {
                    time1--;
                    lblTime.Text = string.Format("00:0{0}:{1}", time1 / 60, time1 % 60);
                }
            }
            else
            {
                timer1.Stop();                
                timer2.Stop();
                timer1.Stop();

                scoreg.Text = score.Text;
                display.Visible = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Time to get new one.
            //ChangePicture();
            if (time2 > 0)
            {
                if (time2 <= 10)
                {
                    if (time2 % 2 == 0)
                    {
                        lblTime.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblTime.ForeColor = Color.Black;
                    }
                    time2--;
                    lblTime.Text = string.Format("00:0{0}:0{1}", time2 / 60, time2 % 60);
                }
                else
                {
                    time2--;
                    lblTime.Text = string.Format("00:0{0}:{1}", time2 / 60, time2 % 60);
                }
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                timer1.Stop();

                scoreg.Text = score.Text;
                display.Visible = true;
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            // Time to get new one.
            //ChangePicture();
            if (time3 > 0)
            {
                if (time3 <= 10)
                {
                    if (time3 % 2 == 0)
                    {
                        lblTime.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblTime.ForeColor = Color.Black;
                    }
                    time3--;
                    lblTime.Text = string.Format("00:0{0}:0{1}", time3 / 60, time3 % 60);
                }
                else
                {
                    time3--;
                    lblTime.Text = string.Format("00:0{0}:{1}", time3 / 60, time3 % 60);
                }
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                timer1.Stop();

                scoreg.Text = score.Text;
                display.Visible = true;
            }
        }
        // all timing stops here      

        private void ChangePicture()
        {
            // Do we have pictures in list?
            if (Files.Count > 0)
            {
                // OK lets grab first one
                string File = Files.First();                

                //pictureBox1.Load(File); //loads the image path into the picture box
                btnimage.BackgroundImage = Image.FromFile(File);

                // Remove file from list
                Files.RemoveAt(0);                
            }
            else
            {                
                // Out of pictures, stopping timer
                // and wait god todo someting.
                timer1.Stop();
            }
        }        

        void timer_Tick2(object sender, System.EventArgs e)
        {
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // go back to the previous page
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }
    }
}
