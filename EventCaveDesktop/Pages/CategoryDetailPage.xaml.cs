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
            if (id == 0)
            {
                updateBtn.Visibility = Visibility.Hidden;
                createBtn.Visibility = Visibility.Visible;
                this.id.Content = "-";
            }
            else
            {
                updateBtn.Visibility = Visibility.Visible;
                createBtn.Visibility = Visibility.Hidden;
                FetchCategory(id);
                BindData();
            }
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
            name.Text = categoryViewModel.Name;
            description.Text = categoryViewModel.Description;
            imageLink.Text = categoryViewModel.Image;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            categoryViewModel.Name = name.Text;
            categoryViewModel.Description = description.Text;
            categoryViewModel.Image = imageLink.Text;

            Category updatedCategory = new Category()
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name,
                Description = categoryViewModel.Description,
                Image = categoryViewModel.Image
            };

            if (categoryController.Update(updatedCategory))
            {
                updateBtn.Background = Brushes.Green;
                updateBtn.Content = "Sucess";
            }
            else
            {
                updateBtn.Background = Brushes.Red;
                updateBtn.Content = "Error";
            }
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            categoryViewModel.Name = name.Text;
            categoryViewModel.Description = description.Text;
            categoryViewModel.Image = imageLink.Text;

            Category createdCategory = new Category()
            {
                Name = categoryViewModel.Name,
                Description = categoryViewModel.Description,
                Image = categoryViewModel.Image
            };

            if (categoryController.Create(createdCategory))
            {
                updateBtn.Background = Brushes.Green;
                updateBtn.Content = "Sucess";
            }
            else
            {
                updateBtn.Background = Brushes.Red;
                updateBtn.Content = "Error";
            }
        }
    }
}
