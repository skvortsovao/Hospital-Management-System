using Microsoft.AspNet.SignalR;

public class AppointmentHub : Hub
{
    public void SendAppointmentUpdate()
    {
        // Notify all clients
        Clients.All.receiveAppointment("An update occurred.");
    }
}