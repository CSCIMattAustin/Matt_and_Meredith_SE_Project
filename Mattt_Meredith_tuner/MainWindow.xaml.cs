using System.Windows;
using System.Media;
using System.Windows.Controls;
using System.Timers;
using System.Threading;
//using System.Windows.Forms.Timer;


namespace MMMMM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread t;
        bool Start_Select = false;
        int bpm;
        int note_value = 0;
        System.Threading.Timer timer;
        SoundPlayer player = new SoundPlayer();
        SoundPlayer met_player = new SoundPlayer();
        public MainWindow()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer();
        }

        private void noteBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (noteBox.SelectedIndex == 0)
            {
                player.Stop();
            }
            else if (noteBox.SelectedIndex == 1)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\A_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 2)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\A#_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 3)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\B_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 4)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\C_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 5)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\C#_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 6)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\D_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 7)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\D#_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 8)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\E_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 9)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\F_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 10)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\F#_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 11)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\G_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 12)
            {
                player.Stop();
                player.SoundLocation = @"G:\CSCI352\MMMMM\G#_NOTE.wav";

            }
        }

        private void tempButton_Click(object sender, RoutedEventArgs e)
        {
            Start_Select = false;
            t.Abort();
        }

        private void noteButton_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void tempoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tempoBox.SelectedIndex == 1 || tempoBox.SelectedIndex == 0)
            {
                note_value = 1;
            }
            else if (tempoBox.SelectedIndex == 2)
            {
                note_value = 2;
            }
            else if (tempoBox.SelectedIndex == 3)
            {
                note_value = 4;
            }

        }

        private void START_Click(object sender, RoutedEventArgs e)
        {
            player.PlayLooping();
        }
        private void PlayBeat(object soundToPlay)
        {
            SoundPlayer currentSound = (SoundPlayer)soundToPlay;
            currentSound.PlaySync();
        }
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            bpm = (int)slider.Value * note_value;
            string _value = ((int)slider.Value).ToString();
            try
            {
                textBlock1.Text = _value;
            }
            catch (System.NullReferenceException NRE)
            {
                System.Console.WriteLine(NRE.Message);
            }

        }

        public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            player.PlaySync();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Start_Select = true;

            while (Start_Select)
            {
                System.Console.Beep(300, 100);
                Thread.Sleep(60000 / bpm);
            }
        }
        public void Thread_task()
        {

        }
    }
}
