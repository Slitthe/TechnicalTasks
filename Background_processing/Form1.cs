using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Background_processing
{
    public partial class Form1 : Form
    {
        private int _maxCalculateSumValue = 10000;
        private int _sum = default(int);
        private bool _showProgress = true;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            var task = StartProgressBar();
            var totalSum = await DoSomethingOnBackground();
            _showProgress = false;

            await task;

            richTextBox1.Text += "\nCalculation complete, the final answer is: 42";
            button1.Enabled = true;
        }


        private async Task StartProgressBar()
        {
            button1.Enabled = false;
            _showProgress = true;

            string baseProgress = "Loading";
            int maxDots = 7;
            int currentDots = 0;
            string dotsString = "";

            while (_showProgress)
            {
                await Task.Delay(400);
                currentDots++;
                if (currentDots > maxDots)
                {
                    currentDots = 0;
                }

                dotsString = "";
                Enumerable.Range(0, currentDots).ToList().ForEach((item) =>
                {
                    dotsString += " . ";
                });
                richTextBox1.Text = $"{baseProgress} {dotsString}";
                
            }

            button1.Enabled = false;

        }

        public async Task<int> DoSomethingOnBackground()
        {
            return await Task.Run(( async () =>
            {
                await Task.Delay(5000);
                var sum = 0;
                for (int i = 0; i < _maxCalculateSumValue; i++)
                {
                    sum += i;
                }

                Debug.WriteLine("calculate over");
                return sum;
                
            }));
        }
    }
}
