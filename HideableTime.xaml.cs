using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpTechnicalTest
{

    public partial class HideableTime : UserControl
    {


        public string DateContent
        {
            get { return (string)GetValue(DateContentProperty); }
            set { SetValue(DateContentProperty, value); }
        }

        public static readonly DependencyProperty DateContentProperty =
            DependencyProperty.Register("DateContent", typeof(string), typeof(HideableTime), new PropertyMetadata("Date"));


        //PST, CST, etc.
        public string ZoneLabel
        {
            get { return (string)GetValue(ZoneLabelProperty); }
            set { SetValue(ZoneLabelProperty, value); }
        }

        public static readonly DependencyProperty ZoneLabelProperty =
            DependencyProperty.Register("ZoneLabel", typeof(string), typeof(HideableTime), new PropertyMetadata("Time_Zone"));



        public HideableTime()
        {
            InitializeComponent();
        }
    }
}
