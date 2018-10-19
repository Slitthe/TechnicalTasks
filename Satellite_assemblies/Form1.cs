using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Threading;

namespace Satellite_assemblies
{
    public partial class Form1 : Form
    {
        // long language code to code
        private Dictionary<string, string> _dropdownToLangCode = new Dictionary<string, string>()
        {
            { "English", "en-US" },
            { "Romanian", "ro" },
            { "Hungarian", "hu" },
            { "Russian", "ru" },
        };


        
        private ResourceManager _resourceManager =
            new ResourceManager("Satellite_assemblies.string", Assembly.GetExecutingAssembly());


        public Form1()
        {
            InitializeComponent();
        }

        public void ChangeLanguage(string language)
        {

            // change culture
            string languageCode = _dropdownToLangCode[language];
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageCode);

            // get resource depending on the localization
            string localizedCatName = _resourceManager.GetString($"catName");
            label1.Text = localizedCatName;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cast the dropdown and get its value
            var senderCasted = (ComboBox) sender;
            ChangeLanguage(senderCasted.SelectedItem.ToString());
        }
    }
}
