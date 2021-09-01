using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Microsoft.Win32;


namespace WpfAppSHOPkop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Product _selectedProduct;

        private ObservableCollection<Product> prod;
        public ObservableCollection<Product> Prod
        {
            get { return prod; }
            set { prod = value; }
        }

           private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value;  }
        }
        public MainWindow()
        {
            InitializeComponent();
            ListBoxProducts.DataContext = this;
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Coca-cola 2 litr",
                    Quantity = 200,
                    Price = 1.80,
                    ImagePath = "Images/Cola2l.JPG"
                },
                new Product
                {
                    Id = 2,
                    Name = "Lays",
                    Quantity = 200,
                    Price = 2.20,
                    ImagePath = "Images/Lays.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Cappy 0.5 litr",
                    Quantity = 200,
                    Price = 0.90,
                    ImagePath = "Images/Cappy0.5l.jpg"
                },
                
                new Product
                {
                    Id =4,
                    Name = "Mister Tum",
                    Quantity = 200,
                    Price = 0.50,
                    ImagePath = "Images/Mistertum.jpg"
                },
                
                new Product
                {
                    Id = 5,
                    Name = "Snickers",
                    Quantity = 200,
                    Price = 0.60,
                    ImagePath = "Images/Snickers.jpg"
                },
                
                new Product
                {
                    Id = 6,
                    Name = "Bakili qiz Dondurma",
                    Quantity = 200,
                    Price = 0.60,
                    ImagePath = "Images/Bakiliqiz.jpg"
                },
                
                new Product
                {
                    Id = 7,
                    Name = "Bizon 0.5 litr",
                    Quantity = 200,
                    Price = 1.00,
                    ImagePath = "Images/Bizon0.5l.jpg"
                },


            };
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ObservableCollection<Product> itemsToRemove = new ObservableCollection<Product>();
            foreach (Product item in ListBoxProducts.SelectedItems)
            {
                itemsToRemove.Add(item);
            }
            foreach (Product item in itemsToRemove)
            {
                ((ObservableCollection<Product>)ListBoxProducts.ItemsSource).Remove(item);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void RefreshListBox(ObservableCollection<Product> products)
        {
            ListBoxProducts.ItemsSource = null;
            ListBoxProducts.ItemsSource = products;
        }
        private void TextBoxSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
           //TextBoxSearch.Text = string.Empty;
            if (String.IsNullOrWhiteSpace(TextBoxSearch.Text))
            {
                Prod = Products ;
            }
            else
            {
                Prod = FilterByKeyword(TextBoxSearch.Text);
            }
            RefreshListBox(Prod);
        }
        private ObservableCollection<Product> FilterByKeyword(string keyword)
        {
            keyword = keyword.ToLower();
            var list = new List<Product>(Products);
            list = list.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
            ObservableCollection<Product> products = new ObservableCollection<Product>(list);
            return products;
        }
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
           _selectedProduct = (Product)ListBoxProducts.SelectedItem;
            Edit editt = new Edit();
            editt.Produ = ListBoxProducts.SelectedItem as Product;
                this.WindowState = WindowState.Normal;
                editt.Show();
        }
        private void DELETE_ELEMENT(object sender, MouseEventArgs e)
        {
           _selectedProduct = (Product)ListBoxProducts.SelectedItem;
            Edit editt = new Edit();
            editt.Produ = ListBoxProducts.SelectedItem as Product;
                this.WindowState = WindowState.Normal;
                editt.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your Order Taken,Thanks a lot","Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> itemsToRemove = new ObservableCollection<Product>();
            foreach (Product item in ListBoxProducts.SelectedItems)
            {
                itemsToRemove.Add(item);
            }
            foreach (Product item in itemsToRemove)
            {
                ((ObservableCollection<Product>)ListBoxProducts.ItemsSource).Remove(item);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> itemsToRemove = new ObservableCollection<Product>();
            foreach (Product item in ListBoxProducts.SelectedItems)
            {
                itemsToRemove.Add(item);
            }
            foreach (Product item in itemsToRemove)
            {
                ((ObservableCollection<Product>)ListBoxProducts.ItemsSource).Remove(item);
            }
        }
    }
}
