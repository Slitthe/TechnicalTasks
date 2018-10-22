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
        private int _maxCalculateSumValue = 1000000000;
        private int _sum = default(int);
        private bool _showProgress = true;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await CalculateAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalculateSync();
        }


        private async Task CalculateAsync()
        {
            richTextBox1.Text = "";

            var task = StartProgressBar();
            var totalSum = await PerformCalculationAsync();

            _showProgress = false;

            button1.Enabled = true;
        }

        private void CalculateSync()
        {
            richTextBox1.Text = "";

            var task = StartProgressBar();
            var totalSum = PerformCalculationSync();

            _showProgress = false;

        }

        private async Task StartProgressBar()
        {
            button1.Enabled = false;
            button2.Enabled = false;
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
                    dotsString += " • ";
                });
                richTextBox1.Text = $"{baseProgress} {dotsString}";
                
            }

            button1.Enabled = true;
            button2.Enabled = true;

            richTextBox1.Text = "\nCalculation complete.";

        }

        public async Task<int> PerformCalculationAsync()
        {
            return await Task.Run(( async () =>
            {
                var sum = 0;
                for (int i = 0; i < _maxCalculateSumValue; i++)
                {
                    sum += i;
                }

                Debug.WriteLine("calculate over");
                return sum;
                
            }));
        }

        public int PerformCalculationSync()
        {
                Task.Delay(5000).Wait();
                var sum = 0;
                for (int i = 0; i < _maxCalculateSumValue; i++)
                {
                    sum += i;
                }

                Debug.WriteLine("calculate over");
                return sum;
        }


    }
}
