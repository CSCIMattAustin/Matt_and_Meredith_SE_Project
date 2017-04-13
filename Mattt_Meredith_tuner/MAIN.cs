using MMMMM;
using System.Windows;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Controls;

namespace Mattt_Meredith_tuner
{

    class MAIN
    {
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]

        public static void Main()
        {

            App app = new App();
            ThemeFactory orig = new ConcreteFactoryOriginal();
            ThemeFactory cute = new ConcreteFactoryCute();

            Client oClient = new Client(orig);
            Client cClient = new Client(cute);

           // Opener o = (Opener)opClient.runWindow();

            MainWindow m = (MainWindow)oClient.runWindow();
            version2 v = (version2)cClient.runWindow();

            //<Slider x:Name="slider" Foreground="Green" TickFrequency="5" TickPlacement="BottomRight" 
            //  HorizontalAlignment="Right" Margin="0,0,67,87" RenderTransformOrigin="4.167,7.556" Height="39" 
            //  VerticalAlignment="Bottom" Width="174" ValueChanged="slider_ValueChanged" Maximum ="208" Minimum="40" />

            MainWindow.slider.ValueChanged += m.slider_ValueChanged;
            MainWindow.slider.Foreground = Brushes.Green;
            MainWindow.slider.TickFrequency = 5;
            MainWindow.slider.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
            MainWindow.slider.HorizontalAlignment = HorizontalAlignment.Right;
            MainWindow.slider.Margin = new Thickness(0, 0, 67, 87);
            MainWindow.slider.Height = 39;
            MainWindow.slider.VerticalAlignment = VerticalAlignment.Bottom;
            MainWindow.slider.Width = 174;
            MainWindow.slider.Maximum = 208;
            MainWindow.slider.Minimum = 40;
            MainWindow.slider.Visibility = Visibility.Visible;
            m.GRID.Children.Add(MainWindow.slider);

            version2.sliderPastel.ValueChanged += v.slider_ValueChanged2;
            version2.sliderPastel.Foreground = Brushes.Aquamarine;
            version2.sliderPastel.TickFrequency = 5;
            version2.sliderPastel.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
            version2.sliderPastel.HorizontalAlignment = HorizontalAlignment.Right;
            version2.sliderPastel.Margin = new Thickness(0, 0, 67, 87);
            version2.sliderPastel.Height = 39;
            version2.sliderPastel.VerticalAlignment = VerticalAlignment.Bottom;
            version2.sliderPastel.Width = 174;
            version2.sliderPastel.Maximum = 208;
            version2.sliderPastel.Minimum = 40;
            version2.sliderPastel.Visibility = Visibility.Visible;
            v.GRID.Children.Add(version2.sliderPastel);

            m.Show();
            v.Show();

            //o.Show();

            app.Run();

        }


    }
    


    abstract class ThemeFactory
    {
        public abstract WindowProduct createProduct();
    }

    class ConcreteFactoryOriginal : ThemeFactory
    {
        public override WindowProduct createProduct()
        {
            return new ConcreteProductOriginal();
        }
    }

    class ConcreteFactoryCute : ThemeFactory
    {
        public override WindowProduct createProduct()
        {
            return new ConcreteProductCute();
        }
    }

    class ConcreteFactoryOpener : ThemeFactory
    {
        public override WindowProduct createProduct()
        {
            return new ConcreteProductOpener();
        }
    }
    abstract class WindowProduct
    {
        public abstract Window window();
    }

    class ConcreteProductOriginal : WindowProduct
    {
        public override Window window()
        {
            MainWindow m = new MainWindow();

            return m;
        }
    }

    class ConcreteProductCute : WindowProduct
    {
        public override Window window()
        {
            MMMMM.version2 w = new version2();

            return w;
        }
    }
    class ConcreteProductOpener : WindowProduct
    {
        public override Window window()
        {
            Opener w = new Opener();

            return w;
        }
    }

    class Client
    {
        private WindowProduct p;

        public Client(ThemeFactory t)
        {
            p = t.createProduct();
        }

        public Window runWindow()
        {
            return p.window();
        }

    }
}
