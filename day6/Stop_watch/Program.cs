using System;
using System.Windows.Forms;

namespace stopwatch1
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int totalSeconds = 0;

        public Form1()
        {
            InitializeComponent();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            // Set starting values
            richTextBox1.Text = "00"; // hours
            richTextBox2.Text = "00"; // minutes
            richTextBox3.Text = "00"; // seconds

            // Wire up the buttons
            button1.Click += button1_Click; // start
            button2.Click += button2_Click; // stop
            button3.Click += button3_Click; // reset
            button4.Click += button4_Click; // save
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            totalSeconds++;
            int h = totalSeconds / 3600;
            int m = (totalSeconds % 3600) / 60;
            int s = totalSeconds % 60;

            richTextBox1.Text = h.ToString("00");
            richTextBox2.Text = m.ToString("00");
            richTextBox3.Text = s.ToString("00");
        }

        private void button1_Click(object sender, EventArgs e) // start
        {
            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e) // stop
        {
            timer.Stop();
        }

        private void button3_Click(object sender, EventArgs e) // reset
        {
            timer.Stop();
            totalSeconds = 0;
            richTextBox1.Text = "00";
            richTextBox2.Text = "00";
            richTextBox3.Text = "00";
        }

        private void button4_Click(object sender, EventArgs e) // save
        {
            MessageBox.Show(
                "Saved Time: " +
                richTextBox1.Text + ":" +
                richTextBox2.Text + ":" +
                richTextBox3.Text
            );
        }
    }
}
