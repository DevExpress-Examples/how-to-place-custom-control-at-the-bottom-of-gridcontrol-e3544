using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Q346919 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            DataContext = DataList.Create();
            InitializeComponent();
        }
    }

    public class DataList : List<Data> {
        public static DataList Create() {
            DataList res = new DataList();
            for(int i = 0; i < 10; i++) {
                for(int j = 0; j < 10; j++) {
                    Data item = new Data() {
                        Value1 = "Value1 = " + i.ToString(),
                        Value2 = "Value2 = " + j.ToString(),
                    };
                    res.Add(item);
                }
            }
            return res;
        }
    }
    public class Data {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}
