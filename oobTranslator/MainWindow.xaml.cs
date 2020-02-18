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
        bool isReading = false;
       
        public MainWindow()
        {
            InitializeComponent();
            reader.SpeakCompleted += OnDoneSpeaking;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            txtOutput.Text = oob.oobifyString(txtInput.Text);
        }

        private void ReaderClick(object sender, RoutedEventArgs e)
        {
            if (isReading == false)
            {
                reader.SpeakAsync(txtOutput.Text);
                isReading = true;
            } else
            {
                chkLoop.IsChecked = false;
                reader.SpeakAsyncCancelAll();
                OnDoneSpeaking(this, new EventArgs());
            }
            btnReadOob.Content = "Stop Reading OOb";
        }

        private void OnDoneSpeaking(object sender, EventArgs e)
        {
            if (chkLoop.IsChecked == true)
            {
                reader.SpeakAsync(txtOutput.Text);
            } else
            {
                isReading = false;
                btnReadOob.Content = "Read Oob";
            }
        }
    }
}
