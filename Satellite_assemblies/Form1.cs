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
        // used to map the dropdown items to language codes
        private readonly Dictionary<string, string> _dropdownToLangCode = new Dictionary<string, string>()
        {
            { "English", "en-US" },
            { "Romanian", "ro" },
            { "Hungarian", "hu" },
            { "Russian", "ru" },
        };

        private readonly ResourceManager _resourceManager = new ResourceManager("Satellite_assemblies.string", Assembly.GetExecutingAssembly());

        public Form1()
        {
            InitializeComponent();
        }
        
        public void ChangeLanguage(string language)
        {
            // change the culture
            string languageCode = _dropdownToLangCode[language];
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageCode);

            // get resource depending on the current culture
            string localizedCatName = _resourceManager.GetString($"catName");
            
            label1.Text = localizedCatName;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // dropdown menu selected event
            var senderComboBox = (ComboBox) sender;

            ChangeLanguage( senderComboBox.SelectedItem.ToString() );
        }
    }
}
