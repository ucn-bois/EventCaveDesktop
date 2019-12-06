using EventCaveDesktop.ViewModels;
using Resources.Controllers;
using Resources.Entities;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace EventCaveDesktop.Pages
{
    /// <summary>
    /// Interaction logic for TicketDetailPage.xaml
    /// </summary>
    public partial class TicketDetailPage : Page
    {
        TicketController ticketController = new TicketController();
        TicketDetailViewModel viewModel = new TicketDetailViewModel();

        public TicketDetailPage(object ticketId)
        {
            InitializeComponent();
            fetchTicket(ticketId);
            bindData();
        }

        private void fetchTicket(object ticketId)
        {
            Ticket ticket = ticketController.GetById(ticketId);
            viewModel.Id = ticket.Id;
            viewModel.Subject = ticket.Subject;
            viewModel.SubmittedAt = ticket.SubmittedAt;
            viewModel.Message = ticket.Message;
            viewModel.Resolved = ticket.Resolved;
            viewModel.SenderId = ticket.SenderId;
            viewModel.SenderUsername = ticket.SenderUsername;
            viewModel.Response = ticket.Response;
        }

        private void bindData()
        {
            id.Content = string.Format("Ticket (ID: {0})", viewModel.Id);
            subject.Content = string.Format("Subject: {0}", viewModel.Subject);
            submittedAt.Content = string.Format("Submitted at {0}", viewModel.SubmittedAt);
            submittedBy.Content = string.Format("Submitted by {0}", viewModel.SenderUsername);
            message.Content = string.Format("Message: {0}", viewModel.Message);
            responseText.Text = viewModel.Response;
        }

        private void submitResponseBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel.Response = responseText.Text;

            Ticket ticketResponse = new Ticket()
            {
                Id = viewModel.Id,
                Response = viewModel.Response
            };

            if (ticketController.SubmitResponse(ticketResponse))
            {
                submitResponseBtn.Background = Brushes.Green;
                submitResponseBtn.Content = "Sucess";
            }
            else
            {
                submitResponseBtn.Background = Brushes.Red;
                submitResponseBtn.Content = "Error";
            }
        }
    }
}
