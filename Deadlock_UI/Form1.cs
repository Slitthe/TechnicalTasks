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
            Debug.WriteLine($"---- Starting the {nameof(DoSomethingAsync)} [{Thread.CurrentThread.ManagedThreadId}]");

            await Task.Run(async () =>
            {
                await Task.Delay(500);
                Debug.WriteLine($"---- Inside the inner task [{Thread.CurrentThread.ManagedThreadId}]");
            }); // .ConfigureAwait80(false); --> will solve the issue by running the rest of the method code in another thread (via tasks)

            // cannot continue on with returning/exiting the rest of the method (even though it is empty)
            // because the rest of the code will try to run on the main thread (because of the sync context in an UI application)
            // and because the main thread is blocked it results in a beautiful DEADLOCK



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"---- Before firing the DoSomethingAsync [{Thread.CurrentThread.ManagedThreadId}]");

            // fires off the async Task method
            var t = DoSomethingAsync();

            Debug.WriteLine($"---- Before waiting the DoSomethingAsync [{Thread.CurrentThread.ManagedThreadId}]");

            // manually waits for it
            t.Wait();
        }
    }
}
