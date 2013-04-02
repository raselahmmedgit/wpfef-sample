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
using RnD.WpfEfSample.Data;
using RnD.WpfEfSample.Domain;

namespace RnD.WpfEfSample.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppDbContext _db = new AppDbContext();

        public MainWindow()
        {
            InitializeComponent();
            LoadGridData();
        }

        private void LoadGridData()
        {
            var categories = _db.Categories.ToList();
            this.dgCategoryList.ItemsSource = categories;
        }

        private void btnCategorySave_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = this.txtCategoryName.Text;
            var category = new Category() { Name = categoryName };

            _db.Categories.Add(category);
            _db.SaveChanges();

            this.txtCategoryName.Text = string.Empty;

        }

        private void btnCategoryReset_Click(object sender, RoutedEventArgs e)
        {
            this.txtCategoryName.Text = string.Empty;
        }
    }
}
