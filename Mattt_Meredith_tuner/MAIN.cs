using MMMMM;
using System.Windows;
using System;
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

            Window w = new Opener();
            ThemeFactory opener = new ConcreteFactoryOpener();

            ThemeFactory orig = new ConcreteFactoryOriginal();
            ThemeFactory cute = new ConcreteFactoryCute();

            Client opClient = new Client(opener);

            Client oClient = new Client(orig);
            Client cClient = new Client(cute);

            Opener o = (Opener)opClient.runWindow();
            MainWindow m = (MainWindow)oClient.runWindow();
            version2 v = (version2)cClient.runWindow();
            o.Show();
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
