using System.Windows;
using System.Windows.Controls;
using System.Timers;
using System.Threading;
using System;
using System.Diagnostics;
using System.ComponentModel;
//using Microsoft.Xna.FrameWork;


namespace MMMMM
{
    public delegate void MET();

    public partial class MainWindow : Window
    {
        //Microphone mc;
        bool NOTE_SELECT = false;
        public Thread t;
        public Thread NOTE;
        bool Start_Select = false;
        int bpm;
        int note_value = 0;
        int beep_value = 0;

        public MainWindow()
        {
            InitializeComponent();
            t = new Thread(() => { Thread_task(); });
            NOTE = new Thread(() => { NoteGenerator(); });
            Closing += CLOSE_WINDOW();
        }

        private CancelEventHandler CLOSE_WINDOW()
        {    
            return OnWindowClosing;
        }

        private void noteBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (noteBox.SelectedIndex == 0)
            {
                beep_value = 0;
            }
            else if (noteBox.SelectedIndex == 1)
            {
                beep_value = 220;
            }
            else if (noteBox.SelectedIndex == 2)
            {
                beep_value = 223;

            }
            else if (noteBox.SelectedIndex == 3)
            {
                beep_value = 246;

            }
            else if (noteBox.SelectedIndex == 4)
            {
                beep_value = 261;

            }
            else if (noteBox.SelectedIndex == 5)
            {
                beep_value = 277;

            }
            else if (noteBox.SelectedIndex == 6)
            {
                beep_value = 293;

            }
            else if (noteBox.SelectedIndex == 7)
            {
                beep_value = 311;

            }
            else if (noteBox.SelectedIndex == 8)
            {
                beep_value = 329;

            }
            else if (noteBox.SelectedIndex == 9)
            {
                beep_value = 349;

            }
            else if (noteBox.SelectedIndex == 10)
            {
                beep_value = 369;

            }
            else if (noteBox.SelectedIndex == 11)
            {
                beep_value = 391;

            }
            else if (noteBox.SelectedIndex == 12)
            {
                beep_value = 415;

            }
        }

        private void tempButton_Click(object sender, RoutedEventArgs e)
        {
            Start_Select = false;
        }
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            t.Abort();
            NOTE.Abort();
            NOTE.Interrupt();

            if (beep_value > 36)
            {
                Console.Beep(beep_value, 1);
            }

            else
            {
                Console.Beep(37, 1);
            }

            NOTE.Abort();
            NOTE.Interrupt();
        }
        private void noteButton_Click(object sender, RoutedEventArgs e)
        {
            NOTE_SELECT = false;
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
            try
            {
                    NOTE.Start();
            }

            catch(ThreadStateException TSE)
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
            bpm = (int)slider.Value * note_value;
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
            Start_Select = true;

            try
            {
                t.Start();
            }
            catch(ThreadStateException TSE)
            {
                Console.WriteLine(TSE.Message);
            }
        }
        private void SHOW()
        {
            Dispatcher.Invoke(() =>
            {
                circlegreen.Visibility = Visibility.Visible;
            });
        }
        private void HIDE()
        {

            Dispatcher.Invoke(() =>
            {
                circlegreen.Visibility = Visibility.Collapsed;
            });
        }
        private void Thread_task()
        {        
            while (Start_Select)
            {
                SHOW();
                Console.Beep(300, 100);
                HIDE();
                Thread.Sleep(60000 / bpm);
            }
        }
        private void NoteGenerator()
        {
            NOTE_SELECT = true;
            
            while (NOTE_SELECT && NOTE.IsAlive) 
            {
                try
                {
                    Console.Beep(beep_value, 10000);

                }

                catch(System.ArgumentOutOfRangeException a)
                {
                    Console.WriteLine(a.Message);
                }
            }       
        }
    }
}
 