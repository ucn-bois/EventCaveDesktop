using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Resources.Entities;

namespace EventCaveDesktop.Pages
{
    public partial class CategoriesPage : Page
    {
        public CategoriesPage(ICollection<Category> categories, string header)
        {
            InitializeComponent();
            this.header.Content = header;

            GridView listViewLayout = new GridView();
            listViewLayout.AllowsColumnReorder = true;
            listViewLayout.ColumnHeaderToolTip = header;

            GridViewColumn gvc1 = new GridViewColumn();
            gvc1.DisplayMemberBinding = new Binding("Id");
            gvc1.Header = "ID";
            gvc1.Width = 50;

            listViewLayout.Columns.Add(gvc1);
            GridViewColumn gvc2 = new GridViewColumn();
            gvc2.DisplayMemberBinding = new Binding("Name");
            gvc2.Header = "Name";
            gvc2.Width = 150;
            listViewLayout.Columns.Add(gvc2);

            GridViewColumn gvc3 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("Description");
            gvc3.Header = "Description";
            gvc3.Width = 650;
            listViewLayout.Columns.Add(gvc3);

            categoryList.ItemsSource = categories;
            categoryList.View = listViewLayout;
        }

        private void listView_Click(object sender, RoutedEventArgs e)
        {
            Category item = (Category)(sender as ListView).SelectedItem;
            if (item != null)
            {
                this.NavigationService.Navigate(new CategoryDetailPage(item.Id));
            }
        }
    }
}
