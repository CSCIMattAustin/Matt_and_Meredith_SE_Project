using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Media;

namespace MMMMM
{
    public partial class version2 : Window
    {
        static public Slider sliderPastel = new Slider();
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
        public abstract class decoratorP
        {
            public abstract void decorate();
        }


        abstract class sliderDecP : decoratorP
        {
            public abstract override void decorate();
        }

        class DisplayColorChangerTP : sliderDecP
        {

            public TextBlock T = new TextBlock();
            private int ind;
            public DisplayColorChangerTP(TextBlock t, int val)
            {
                T = t;

                ind = val%9;
            }
            public override void decorate()
            {
                if (ind == 0)
                    T.Background = Brushes.LightGreen;
                else if (ind == 1)
                    T.Background = Brushes.LightCyan;
                else if (ind == 2)
                    T.Background = Brushes.LightBlue;
                else if (ind == 3)
                    T.Background = Brushes.Lavender;
                else if (ind == 4)
                {
                //    try
                //    {
                        T.Background = Brushes.LavenderBlush;
                    //}
                    //catch (NullReferenceException nre)
                    //{
                    //    Console.WriteLine(nre.Message);
                    //}
                }
                else if (ind == 5)
                    T.Background = Brushes.MistyRose;
                else if (ind == 6)
                    T.Background = Brushes.Pink;
                else if (ind == 7)
                    T.Background = Brushes.PeachPuff;
                else if (ind == 8)
                    T.Background = Brushes.Moccasin;
                else if (ind == 9)
                    T.Background = Brushes.Cornsilk;
            }
        }

        class DisplayColorChangerBP : sliderDecP
        {
            public Border border = new Border();
            private int ind;
            public DisplayColorChangerBP(Border b, int val)
            {
                border = b;
                ind = val % 9;
            }
            public override void decorate()
            {
                if (ind == 0)
                    border.BorderBrush = Brushes.LightGreen;
                else if (ind == 1)
                    border.BorderBrush = Brushes.LightCyan;
                else if (ind == 2)
                    border.BorderBrush = Brushes.LightBlue;
                else if (ind == 3)
                    border.BorderBrush = Brushes.Lavender;
                else if (ind == 4)
                    border.BorderBrush = Brushes.LavenderBlush;
                else if (ind == 5)
                    border.BorderBrush = Brushes.MistyRose;
                else if (ind == 6)
                    border.BorderBrush = Brushes.Pink;
                else if (ind == 7)
                    border.BorderBrush = Brushes.PeachPuff;
                else if (ind == 8)
                    border.BorderBrush = Brushes.Moccasin;
                else if (ind == 9)
                    border.BorderBrush = Brushes.Cornsilk;
            }
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
                    notetextP.Text = "   A";
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
                    notetextP.Text = "  Bb";
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
                    notetextP.Text = "   B";
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
                    notetextP.Text = "   C";
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
                    notetextP.Text = "  C#";
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
                    notetextP.Text = "   D";
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
                    notetextP.Text = "  Eb";
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
                    notetextP.Text = "   E";
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
                    notetextP.Text = "    F";
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
                    notetextP.Text = "  F#";
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
                    notetextP.Text = "   G";
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
                    notetextP.Text = "  Ab";
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
                    notetextP.Text = "  ___ ";
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

        public void slider_ValueChanged2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            bpm = (int)sliderPastel.Value;
            string _value = ((int)sliderPastel.Value).ToString();

            decoratorP d = new DisplayColorChangerTP(textBlockP, (int)sliderPastel.Value);
            decoratorP c = new DisplayColorChangerTP(notetextP, (int)sliderPastel.Value);
            decoratorP b = new DisplayColorChangerBP(mainBorderP, (int)sliderPastel.Value);
            d.decorate();
            c.decorate();
            b.decorate();


            try
            {
                textBlockP.Text = _value;
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
                mainBorderP.Visibility = Visibility.Visible;
            });
        }

        private void HIDE()
        {
            Dispatcher.Invoke(() =>
            {
                mainBorderP.Visibility = Visibility.Collapsed;
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
