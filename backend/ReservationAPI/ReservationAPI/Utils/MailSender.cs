using ReservationAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace ReservationAPI.Utils
{
    public class MailSender
    {
        string systemMail = "sender.246695@gmail.com";
        string systemMailName = "Zespół Koleje-Rezerwacje";
        string systemMailPassword = "6z3&j65!UwQTxHu@6kdr";

        User user;
        string fromStationName;
        string toStationName;
        Stop from;
        Stop to;
        List<TicketType> ticketTypes;
        int resId;
        List<PlaceRequest> places;
        double price;
        string mailMessage;
        string mailTopic = "Potwierdzenie dokonania rezerwacji";

        public MailSender(User user, string fromStationName, string toStationName, Stop from, Stop to, List<TicketType> ticketTypes, int resId, List<PlaceRequest> places, double price)
        {
            this.user = user;
            this.fromStationName = fromStationName;
            this.toStationName = toStationName;
            this.from = from;
            this.to = to;
            this.ticketTypes = ticketTypes;
            this.resId = resId;
            this.places = places;
            this.price = price;
        }
        public string prepareMessage()
        {
            string message = $"Witaj {user.Login}!\n\nTwoja rezerwacja została przyjęta. \n";
            message += $"Numer rezerwacji: {resId}\n\n";

            message += $"Stacja początkowa: {fromStationName}\n";
            message += $"Stacja docelowa: {toStationName}\n";
            message += $"Data przejazdu: {from.StopDateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}\n";
            message += $"Godzina odjazdu: {from.StopDateTime.ToString("HH:mm", CultureInfo.InvariantCulture)}\n";
            message += $"Godzina przyjazdu: {to.StopDateTime.ToString("HH:mm", CultureInfo.InvariantCulture)}\n\n";

            int iter = 1;
            message += "Bilety: \n\n";
            foreach (PlaceRequest place in places)
            {
                TicketType ticket = ticketTypes.First(t => t.TicketTypeId == place.ticketTypeId);
                message += $"  {iter}) Miejsce: {place.placeNumber}, Wagon: {place.trainCartNumber}, Rodzaj biletu: {ticket.Name}\n";
                iter++;
            }

            message += $"\nKwota do zapłaty: {Math.Round(price, 2).ToString("0.00")} PLN\n\n";

            message += "Pozdrawiamy \nZespół Koleje-Rezerwacje";

            mailMessage = message;
            return mailMessage;
        }

        public void sendMail()
        {
            MailAddress to = new MailAddress(user.Email);
            MailAddress from = new MailAddress(systemMail, systemMailName);

            MailMessage message = new MailMessage(from, to);
            message.Subject = this.mailTopic;
            message.Body = this.mailMessage;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(systemMail, systemMailPassword),
                EnableSsl = true
            };

            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
