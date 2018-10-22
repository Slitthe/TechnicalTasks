using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deadlock_UI
{
    public partial class Form1 : Form
    {
        public string ResOne = "resource one";
        public string ResTwo = "resource two";

        public string GetSomeRes()
        {
            return "Some res";
        }

        public Form1()
        {
            InitializeComponent();
        }


        public async Task DoSomethingAsync()
        {
            Debug.WriteLine($"Start of the do something async [{Thread.CurrentThread.ManagedThreadId}]");

            await Task.Run(() => 
                {
                    Debug.WriteLine($"Inside the inner task[{Thread.CurrentThread.ManagedThreadId}]");
                }    
            );

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoSomethingAsync().Wait();
        }
    }
}
