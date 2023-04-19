using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Agency.service;

public class AgencyService : IChatService
{
    private IAgentRepository agentRepository;
    private IClientRepository clientRepository;
    private IFlightRepository flightRepository;
    private IFlightBookingRepository flightBookingRepository;
    private readonly IDictionary<int, IChatObserver> loggedAgents;

    public AgencyService(IAgentRepository agentRepository, IClientRepository clientRepository, IFlightRepository flightRepository, IFlightBookingRepository flightBookingRepository)
    {
        this.agentRepository = agentRepository;
        this.clientRepository = clientRepository;
        this.flightRepository = flightRepository;
        this.flightBookingRepository = flightBookingRepository;
        loggedAgents = new Dictionary<int, IChatObserver>();
    }

    public void login(Agent agent, IChatObserver client)
    {
        Agent agentOk = agentRepository.FindAgentByLoginInformation(agent.AgencyName, agent.UserName, agent.Password);
        if (agentOk != null)
        {
            if (loggedAgents.ContainsKey(agentOk.getID()))
                throw new ChatException("User already logged in.");
            loggedAgents[agentOk.getID()] = client;
        }
        else
            throw new ChatException("Authentication failed.");
    }

    public void logout(Agent agent, IChatObserver client)
    {
        IChatObserver localClient = loggedAgents[agent.getID()];
        if (localClient == null)
            throw new ChatException("User " + agent.getID() + " is not logged in.");
        loggedAgents.Remove(agent.getID());
    }

    public void bookFlightNotification(Flight flight)
    {
        IEnumerable<Agent> agents = agentRepository.GetAll();
        foreach (Agent us in agents)
        {
            if (loggedAgents.ContainsKey(us.getID()))
            {
                IChatObserver chatClient = loggedAgents[us.getID()];
                Task.Run(() => chatClient.updateFlights(flight));
            }
        }
    }

    public List<Flight> getAllAvailableFlights()
    {
        return flightRepository.FindAvailableFlights();
    }

    public List<Flight> getFilteredFlights(string destination, DateTime date)
    {
        return flightRepository.FindFlightByDestinationAndDatetime(destination, date);
    }

    public Agent getLoginAgent(string agencyName, string userName, string password)
    {
        return agentRepository.FindAgentByLoginInformation(agencyName, userName, password);
    }

    public Client addClient(Client client)
    {
        clientRepository.Save(client);
        int idMax = 0;
        foreach (Client c in clientRepository.GetAll())
        {
            if (c.getID() > idMax)
                idMax = c.getID();
        }

        return clientRepository.FindOne(idMax);
    }

    public void addBooking(Client client, Flight flight)
    {
        FlightBooking booking = new FlightBooking();
        booking.setID(new Tuple<int, int>(client.getID(), flight.getID()));
        flightBookingRepository.Save(booking);
    }

    public void updateNoSeatsLeftFlight(Flight flight)
    {
        flightRepository.Update(flight);
    }

    public void finishBooking(Client client, Flight flight)
    {
        Client rezClient = addClient(client);
        updateNoSeatsLeftFlight(flight);
        addBooking(rezClient, flight);
        Flight flightUpdated = flightRepository.FindOne(flight.getID());
        bookFlightNotification(flightUpdated);
    }

    public Flight findFlightById(int id)
    {
        return flightRepository.FindOne(id);
    }

   
}

