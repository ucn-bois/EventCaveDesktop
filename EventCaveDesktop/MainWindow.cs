using EventCaveDesktop.Pages;
using Resources.Controllers;
using Resources.Entities;
using System.Collections.Generic;
using System.Windows;

namespace EventCaveDesktop
{
    // TODO display a message when an admin needs to log in somehow
    public partial class MainWindow
    {
        TicketController ticketController = new TicketController();
        CategoryController categoryController = new CategoryController();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Login());
        }

        private void PendingTickets_Click(object sender, RoutedEventArgs e)
        {
            ICollection<Ticket> pendingTickets = ticketController.GetPending();
            PageFrame.Navigate(new TicketsPage(pendingTickets, "Pending Tickets"));
        }

        private void ResolvedTickets_Click(object sender, RoutedEventArgs e)
        {
            ICollection<Ticket> resolvedTickets = ticketController.GetResolved();
            PageFrame.Navigate(new TicketsPage(resolvedTickets, "Resolved Tickets"));
        }
        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            ICollection<Category> categories = categoryController.GetAll();
            PageFrame.Navigate(new CategoriesPage(categories, "Categories"));
        }
    }
}
