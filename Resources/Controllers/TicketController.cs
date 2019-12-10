using Resources.Entities;
using Resources.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Resources.Controllers
{
    public class TicketController
    {
        RestClient client = new RestClient("https://localhost:44324");
        Authentication auth = Authentication.GetInstance();

        public ICollection<Ticket> GetAll()
        {
            var request = new RestRequest("Api/Tickets", Method.GET);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            auth.AddAuthHeader(request);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<Ticket>> response = client.Execute<List<Ticket>>(request);

            List<Ticket> tickets = new List<Ticket>();
            if (response.Data != null && auth.UserLoggedIn())
            {
                tickets = response.Data;
            }

            return tickets;
        }

        public ICollection<Ticket> GetResolved()
        {
            ICollection<Ticket> resolvedTickets = GetAll();
            return resolvedTickets.Where(t => t.Resolved == true).ToList();
        }

        public ICollection<Ticket> GetPending()
        {
            ICollection<Ticket> pendingTickets = GetAll();
            return pendingTickets.Where(t => t.Resolved == false).ToList();
        }

        public Ticket GetById(object ticketId)
        {
            var request = new RestRequest(String.Format("Api/Tickets/{0}", ticketId), Method.GET);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            auth.AddAuthHeader(request);
            request.RequestFormat = DataFormat.Json;
            IRestResponse<Ticket> response = client.Execute<Ticket>(request);

            return response.Data;
        }

        public bool SubmitResponse(Ticket ticketResponse)
        {
            bool success = false;
            var request = new RestRequest(string.Format("Api/Tickets/{0}/Resolve", ticketResponse.Id), Method.POST);
            auth.AddAuthHeader(request);
            request.AddParameter("Response", ticketResponse.Response);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                success = true;
            }

            return success;
        }
    }
}
