using System.Windows;
using System.Windows.Controls;
using System.Timers;
using System.Threading;
using System;
using System.Diagnostics;
using System.ComponentModel;


namespace MMMMM
{
    public delegate void MET2();

    public partial class version2 : Window
    {
        bool NOTE_SELECT2 = false;
        public Thread t2;
        public Thread NOTE2;
        bool Start_Select2 = false;
        int bpm2;
        int note_value2 = 0;
        int beep_value2 = 0;

        public version2()
        {
            InitializeComponent();
            t2 = new Thread(() => { Thread_task2(); });
            NOTE2 = new Thread(() => { NoteGenerator2(); });
            Closing += CLOSE_WINDOW2();
        }

        private CancelEventHandler CLOSE_WINDOW2()
        {
            return OnWindowClosing;
        }

        private void noteBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (noteBox.SelectedIndex == 0)
            {
                beep_value2 = 0;
            }

            else if (noteBox.SelectedIndex == 1)
            {
                beep_value2 = 220;
            }

            else if (noteBox.SelectedIndex == 2)
            {
                beep_value2 = 223;

            }

            else if (noteBox.SelectedIndex == 3)
            {
                beep_value2 = 246;

            }

            else if (noteBox.SelectedIndex == 4)
            {
                beep_value2 = 261;

            }

            else if (noteBox.SelectedIndex == 5)
            {
                beep_value2 = 277;

            }

            else if (noteBox.SelectedIndex == 6)
            {
                beep_value2 = 293;

            }

            else if (noteBox.SelectedIndex == 7)
            {
                beep_value2 = 311;

            }

            else if (noteBox.SelectedIndex == 8)
            {
                beep_value2 = 329;

            }

            else if (noteBox.SelectedIndex == 9)
            {
                beep_value2 = 349;

            }

            else if (noteBox.SelectedIndex == 10)
            {
                beep_value2 = 369;

            }

            else if (noteBox.SelectedIndex == 11)
            {
                beep_value2 = 391;

            }

            else if (noteBox.SelectedIndex == 12)
            {
                beep_value2 = 415;

            }
        }

        private void tempButton_Click(object sender, RoutedEventArgs e)
        {
            Start_Select2 = false;
        }
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            t2.Abort();
            NOTE2.Abort();
            NOTE2.Interrupt();

            if (beep_value2 > 36)
            {
                Console.Beep(beep_value2, 1);
            }

            else
            {
                Console.Beep(37, 1);
            }

            NOTE2.Abort();
            NOTE2.Interrupt();
        }
        private void noteButton_Click(object sender, RoutedEventArgs e)
        {
            NOTE_SELECT2 = false;
        }

        private void tempoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tempoBox.SelectedIndex == 1 || tempoBox.SelectedIndex == 0)
            {
                note_value2 = 1;
            }

            else if (tempoBox.SelectedIndex == 2)
            {
                note_value2 = 2;
            }

            else if (tempoBox.SelectedIndex == 3)
            {
                note_value2 = 4;
            }
        }

        private void START_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NOTE2.Start();
            }

            catch (ThreadStateException TSE)
            {
                Console.WriteLine(TSE.Message);
            }
        }
        private void PlayBeat(object soundToPlay)
        {
            //SoundPlayer currentSound = (SoundPlayer)soundToPlay;
            // currentSound.PlaySync();
        }
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            bpm2 = (int)slider.Value * note_value2;
            string _value = ((int)slider.Value).ToString();

            try
            {
                textBlock1.Text = _value;
            }

            catch (NullReferenceException NRE)
            {
                Console.WriteLine(NRE.Message);
            }
        }

        public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            //player.PlaySync();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Start_Select2 = true;

            try
            {
                t2.Start();
            }

            catch (ThreadStateException TSE)
            {
                Console.WriteLine(TSE.Message);
            }
        }
        private void SHOW()
        {
            Dispatcher.Invoke(() =>
            {
                cuteBorder.Visibility = Visibility.Visible;
            });
        }
        private void HIDE()
        {

            Dispatcher.Invoke(() =>
            {
                cuteBorder.Visibility = Visibility.Collapsed;
            });
        }
        private void Thread_task2()
        {
            while (Start_Select2)
            {
                SHOW();
                Console.Beep(300, 100);
                HIDE();
                Thread.Sleep(60000 / bpm2);
            }
        }
        private void NoteGenerator2()
        {
            NOTE_SELECT2 = true;
            Stopwatch sw;
            while (NOTE_SELECT2)
            {
                sw = Stopwatch.StartNew();

                try
                {

                    Console.Beep(beep_value2, 1000);

                }

                catch (ArgumentOutOfRangeException a)
                {
                    Console.WriteLine(a.Message);
                }

                while (sw.ElapsedMilliseconds < 5000) ;

            }

        }
    }
}
