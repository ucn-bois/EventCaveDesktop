using EventCaveDesktop.ViewModels;
using Resources.Controllers;
using Resources.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EventCaveDesktop.Pages
{
    public partial class CategoryDetailPage : Page
    {
        CategoryController categoryController = new CategoryController();
        CategoryViewModel categoryViewModel = new CategoryViewModel();
        public CategoryDetailPage(int id)
        {
            InitializeComponent();
            FetchCategory(id);
            BindData();

        }

        private void FetchCategory(int id)
        {
            Category category = categoryController.GetById(id);
            categoryViewModel.Id = category.Id;
            categoryViewModel.Name = category.Name;
            categoryViewModel.Description = category.Description;
            categoryViewModel.Image = category.Image;
        }

        private void BindData()
        {
            this.id.Content = categoryViewModel.Id;
            name.Content = categoryViewModel.Name;
            description.Content = categoryViewModel.Description;
            imageLink.Content = categoryViewModel.Image;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UpdateCategoryPage(categoryViewModel.Id));
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (categoryController.Delete(categoryViewModel.Id))
            {
                deleteBtn.Background = Brushes.LightGreen;
                deleteBtn.Content = "Success";
            }
            else
            {
                deleteBtn.Background = Brushes.IndianRed;
                deleteBtn.Content = "Error";
            }
            this.NavigationService.Navigate(new CategoriesPage(categoryController.GetAll(), "Categories"));
        }
    }
}
