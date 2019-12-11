using EventCaveDesktop.ViewModels;
using Resources.Controllers;
using Resources.Entities;
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

namespace EventCaveDesktop.Pages
{
    public partial class UpdateCategoryPage : Page
    {
        CategoryController categoryController = new CategoryController();
        CategoryViewModel categoryViewModel = new CategoryViewModel();
        public UpdateCategoryPage(int id)
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
                updateBtn.Background = Brushes.LightGreen;
                updateBtn.Content = "Success";
            }
            else
            {
                updateBtn.Background = Brushes.IndianRed;
                updateBtn.Content = "Error";
            }
        }
    }
}
