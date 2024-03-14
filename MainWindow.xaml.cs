using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
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
using WpfApp1.Check;
using WpfApp1.Modelf;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Table2> observable = new ObservableCollection<Table2>();
        public MainWindow()
        {
            InitializeComponent();
            we.ItemsSource = observable;
            foreach (Table2 r in new RereazzzzzzzContext().Table1s.ToArray())
            {
                observable.Add(r);
            }
        }
            private void Button_Click_Sort(object sender, RoutedEventArgs e)
            {
                CollectionViewSource.GetDefaultView(we.ItemsSource).Filter = FilterRating;
                CollectionViewSource.GetDefaultView(we.ItemsSource).Refresh();
            }
            public bool FilterRating(object sender)
            {
                var obj = sender as Table2;
                if (obj != null)
                {
                    if (obj.Name.Contains(sort.Text))
                        return true;
                    else
                        return false;
                }
                return false;
           }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ChackTable1.ChackName(name.Text) && ChackTable1.ChackCount(count.Text) && ChackTable1.ChackDiscount(prise.Text))
            {
                var nameL = name.Text;
                var countL = Convert.ToInt32(count.Text);
                var priseL = Convert.ToDouble(prise.Text);

                using (RereazzzzzzzContext db = new RereazzzzzzzContext())
                {
                    int Id = db.Table1s.Max(d => d.Id) + 1;
                    var tab = new Table1() { Id = Id, Name = nameL, Count = countL, Discount = priseL };
                    db.Table1s.Add(tab);
                    observable.Add(tab);
                    db.SaveChanges();
                }
            }
            else
                MessageBox.Show("Неправильна введена название, количество или цена!");
        }
    }
}