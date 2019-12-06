using EventCaveDesktop.Pages;
using Resources.Controllers;
using Resources.Entities;
using System.Collections.Generic;
using System.Windows;

namespace EventCaveDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        TicketController controller = new TicketController();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PendingTickets_Click(object sender, RoutedEventArgs e)
        {
            ICollection<Ticket> pendingTickets = controller.GetPending();
            PageFrame.Navigate(new TicketsPage(pendingTickets, "Pending Tickets"));
        }

        private void ResolvedTickets_Click(object sender, RoutedEventArgs e)
        {
            ICollection<Ticket> resolvedTickets = controller.GetResolved();
            PageFrame.Navigate(new TicketsPage(resolvedTickets, "Resolved Tickets"));
        }
    }
}
