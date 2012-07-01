using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WindowsPhoneAppHost
{
    public partial class AppHost : Application
    {

        // Easy access to the root frame
        public PhoneApplicationFrame RootFrame { get; private set; }

        WindowsPhoneApp.App app;

        // Constructor
        public AppHost()
        {
            // Standard Silverlight initialization
            InitializeComponent();

            app = new WindowsPhoneApp.App(this);
        }



    }
}


