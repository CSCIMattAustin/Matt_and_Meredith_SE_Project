using System.Windows;
using System.Windows.Controls;
using System.Timers;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using System.ComponentModel;
using System;

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

            app.InitializeComponent();
            /*   var m = new MessageBox();
               m.Show("Would you like to go with the original version?", "Select yes or no", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
               if(MessageBoxResult == MessageBoxResult.Yes)*/
            app.Run();
        }
    }

//    abstract class ThemeFactory
//    {
//        public abstract WindowProduct createProduct();
//    }

//    class ConcreteFactoryOriginal : ThemeFactory
//    {
//        public override WindowProduct createProduct()
//        {
//            return new ConcreteProductOriginal();
//        }
//    }

//    class ConcreteFactoryCute : ThemeFactory
//    {
//        public override WindowProduct createProduct()
//        {
//            return new ConcreteProductCute();
//        }
//    }

//    abstract class WindowProduct
//    {
//        public abstract Window window();
//    }

//    class ConcreteProductOriginal : WindowProduct
//    {
//        public override Window window()
//        {
//            MainWindow m = new MainWindow();

//            m.Show();

//            return m;
//        }
//    }

//    class ConcreteProductCute : WindowProduct
//    {
//        public override Window window()
//        {
//            Window1 w = new Window1();

//            w.Show();

//            return w;
//        }
//    }

//    class Client
//    {
//        private WindowProduct p;
        
//        public Client(ThemeFactory t)
//        {
//            p = t.createProduct();
//        }

//        public Window runWindow()
//        {
//            return p.window();
//        }

//    }
}
