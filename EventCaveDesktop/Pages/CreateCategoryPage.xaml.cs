using Resources.Controllers;
using Resources.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EventCaveDesktop.Pages
{
    public partial class CreateCategoryPage : Page
    {
        CategoryController categoryController = new CategoryController();
        public CreateCategoryPage()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Category createdCategory = new Category()
            {
                Name = name.Text,
                Description = description.Text,
                Image = imageLink.Text
            };

            if (categoryController.Create(createdCategory))
            {
                createBtn.Background = Brushes.LightGreen;
                createBtn.Content = "Success";
                createBtn.IsEnabled = false;
            }
            else
            {
                createBtn.Background = Brushes.IndianRed;
                createBtn.Content = "Error";
            }
        }
    }
}
