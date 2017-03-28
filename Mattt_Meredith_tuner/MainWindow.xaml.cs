using System.Windows;
using System.Media;
using System.Windows.Controls;
using System.Timers;
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;
using System;
//using System.Windows.Forms.Timer;


namespace MMMMM
{
    public delegate void MET();
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Thread t;
        public Thread NOTE;
        bool Start_Select = false;
        int bpm;
        int note_value = 0;
        int beep_value = 0;

        // System.Threading.Timer timer;
        SoundPlayer player = new SoundPlayer();
        public MainWindow()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer();
            t = new Thread(() => { Thread_task(); });
            NOTE = new Thread(() => { NoteGenerator(); });
        }

        private void noteBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (noteBox.SelectedIndex == 0)
            {
                player.Stop();
            }
            else if (noteBox.SelectedIndex == 1)
            {

                beep_value = 220;
            }
            else if (noteBox.SelectedIndex == 2)
            {
                beep_value = 223;

                // player.Stop();
                //player.SoundLocation = @"G:\CSCI352\MMMMM\A#_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 3)
            {
                beep_value = 246;
                //player.Stop();
                // player.SoundLocation = @"G:\CSCI352\MMMMM\B_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 4)
            {
                beep_value = 261;
                //player.Stop();
                // player.SoundLocation = @"G:\CSCI352\MMMMM\C_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 5)
            {
                beep_value = 277;
                //player.Stop();
                //player.SoundLocation = @"G:\CSCI352\MMMMM\C#_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 6)
            {
                beep_value = 293;
                // player.Stop();
                //player.SoundLocation = @"G:\CSCI352\MMMMM\D_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 7)
            {
                beep_value = 311;
                //player.Stop();
                //player.SoundLocation = @"G:\CSCI352\MMMMM\D#_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 8)
            {
                beep_value = 329;
                // player.Stop();
                //player.SoundLocation = @"G:\CSCI352\MMMMM\E_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 9)
            {
                beep_value = 349;
                ////player.Stop();
                // player.SoundLocation = @"G:\CSCI352\MMMMM\F_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 10)
            {
                beep_value = 369;
                // player.Stop();
                //player.SoundLocation = @"G:\CSCI352\MMMMM\F#_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 11)
            {
                beep_value = 391;
                //player.Stop();
                //player.SoundLocation = @"G:\CSCI352\MMMMM\G_NOTE.wav";

            }
            else if (noteBox.SelectedIndex == 12)
            {
                beep_value = 415;
                // player.Stop();
                //player.SoundLocation = @"G:\CSCI352\MMMMM\G#_NOTE.wav";

            }
        }

        //                while (noteButton.IsPressed != true)
        // {
        //     Console.Beep(220, 10);
        //player.Stop();
        //player.SoundLocation = @"G:\CSCI352\MMMMM\A_NOTE.wav";
        //  }

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
            NOTE.Start();
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

            // START.Dispatcher.BeginInvoke(DispatcherPriority.SystemIdle,
            //  new MET(Thread_task));
            t.Start();

        }
        private void Thread_task()
        {
            t.Join();
            while (Start_Select)
            {
                System.Console.Beep(300, 100);
                Thread.Sleep(60000 / bpm);
            }
        }
        private void NoteGenerator()
        {
            NOTE.Join();
            while (noteButton.IsPressed != true)  //comment//comment/////
            {
                Console.Beep(beep_value, 10);
            }
            NOTE.Abort();
        }
    }
}
