using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;

namespace oobTranslator
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer reader = new SpeechSynthesizer();
        oobClass oob = new oobClass();
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            txtOutput.Text = oob.oobifyString(txtInput.Text);
        }

        private void ReaderClick(object sender, RoutedEventArgs e)
        {
            reader.SpeakAsync(txtOutput.Text);
        }
    }
}
