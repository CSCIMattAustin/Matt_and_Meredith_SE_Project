using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System;
using System.Diagnostics;
using System.ComponentModel;
using CSCore;
using CSCore.SoundIn;
using CSCore.Codecs.WAV;
using CSCore.CoreAudioAPI;

namespace MMMMM
{
    public partial class version2 : Window
    {
        bool NOTE_SELECT = false;
        public Thread t;
        public Thread NOTE;
        bool Start_Select = false;
        int bpm;
        int beep_value = 0;

        public version2()
        {
            bpm = 40;
            InitializeComponent();
            t = new Thread(() => { Thread_task2(); });
            NOTE = new Thread(() => { NoteGenerator2(); });
            Closing += CLOSE_WINDOW();
        }

        private CancelEventHandler CLOSE_WINDOW()
        {
            return OnWindowClosing2;
        }

        public void v2noteBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (noteBox.SelectedIndex == 1)
            {
                beep_value = 220;
                try
                {
                    notetext.Text = "   A";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 2)
            {
                beep_value = 223;
                try
                {
                    notetext.Text = "  Bb";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 3)
            {
                beep_value = 246;
                try
                {
                    notetext.Text = "   B";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 4)
            {
                beep_value = 261;
                try
                {
                    notetext.Text = "   C";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 5)
            {
                beep_value = 277;
                try
                {
                    notetext.Text = "  C#";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 6)
            {
                beep_value = 293;
                try
                {
                    notetext.Text = "   D";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 7)
            {
                beep_value = 311;
                try
                {
                    notetext.Text = "  Eb";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 8)
            {
                beep_value = 329;
                try
                {
                    notetext.Text = "   E";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 9)
            {
                beep_value = 349;
                try
                {
                    notetext.Text = "    F";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 10)
            {
                beep_value = 369;
                try
                {
                    notetext.Text = "  F#";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 11)
            {
                beep_value = 391;
                try
                {
                    notetext.Text = "   G";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 12)
            {
                beep_value = 415;
                try
                {
                    notetext.Text = "  Ab";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }

            else if (noteBox.SelectedIndex == 0)
            {
                beep_value = 0;
                try
                {
                    notetext.Text = "  ___ ";
                }

                catch (NullReferenceException NRE)
                {
                    Console.WriteLine(NRE.Message);
                }
            }
        }

        private void temp2Button_Click(object sender, RoutedEventArgs e)
        {
            Start_Select = false;
            t.Abort();
            t = new Thread(() => { Thread_task2(); });
        }

        public void OnWindowClosing2(object sender, CancelEventArgs e)
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

        private void note2Button_Click(object sender, RoutedEventArgs e)
        {
            NOTE_SELECT = false;
            NOTE = new Thread(() => { NoteGenerator2(); });
        }

        private void START_Click2(object sender, RoutedEventArgs e)
        {
            NOTE_SELECT = true;
            try
            {
                NOTE.Start();
            }

            catch (ThreadStateException TSE)
            {
                Console.WriteLine(TSE.Message);
            }
        }

        private void slider_ValueChanged2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            bpm = (int)slider.Value;
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


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Start_Select = true;

            try
            {
                t.Start();
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
                mainBorder.Visibility = Visibility.Visible;
            });
        }

        private void HIDE()
        {
            Dispatcher.Invoke(() =>
            {
                mainBorder.Visibility = Visibility.Collapsed;
            });
        }

        private void Thread_task2()
        {
            while (Start_Select)
            {
                SHOW();
                Console.Beep(300, 100);
                HIDE();

                Thread.Sleep(60000 / bpm);
            }
        }

        private void NoteGenerator2()
        {
            NOTE_SELECT = true;

            Stopwatch sw;

            while (NOTE_SELECT)
            {
                sw = Stopwatch.StartNew();

                try
                {
                    Console.Beep(beep_value, 3000);
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
