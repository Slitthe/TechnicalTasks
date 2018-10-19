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
            await Task.Delay(1000).ConfigureAwait(false);

            await Task.Run(
                async () =>
                {
                    await DoSomethingAsync().ConfigureAwait(false);
                }    
            ).ConfigureAwait(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoSomethingAsync().Wait();
        }
    }
}
