using Resources.Entities;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EventCaveDesktop.Pages
{
    /// <summary>
    /// Interaction logic for TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {
        public TicketsPage(ICollection<Ticket> tickets, string header)
        {
            InitializeComponent();
            this.header.Content = header;

            GridView listViewLayout = new GridView();
            listViewLayout.AllowsColumnReorder = true;
            listViewLayout.ColumnHeaderToolTip = header;

            GridViewColumn gvc = new GridViewColumn();
            gvc.DisplayMemberBinding = new Binding("Id");
            gvc.Header = "ID";
            gvc.Width = 50;
            listViewLayout.Columns.Add(gvc);

            GridViewColumn gvc1 = new GridViewColumn();
            gvc1.DisplayMemberBinding = new Binding("Subject");
            gvc1.Header = "Subject";
            gvc1.Width = 150;
            listViewLayout.Columns.Add(gvc1);

            GridViewColumn gvc2 = new GridViewColumn();
            gvc2.DisplayMemberBinding = new Binding("Message");
            gvc2.Header = "Message";
            gvc2.Width = 550;
            listViewLayout.Columns.Add(gvc2);

            GridViewColumn gvc3 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("SenderUsername");
            gvc3.Header = "Sender";
            gvc3.Width = 100;
            listViewLayout.Columns.Add(gvc3);

            GridViewColumn gvc4 = new GridViewColumn();
            gvc4.DisplayMemberBinding = new Binding("SubmittedAt");
            gvc4.Header = "Submitted";
            gvc4.Width = 150;
            listViewLayout.Columns.Add(gvc4);

            ticketList.ItemsSource = tickets;
            ticketList.View = listViewLayout;
        }

        private void listView_Click(object sender, RoutedEventArgs e)
        {
            Ticket item = (Ticket)(sender as ListView).SelectedItem;
            if (item != null)
            {
                this.NavigationService.Navigate(new TicketDetailPage(item.Id));
            }
        }
    }
}
