using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class FlightBooking : Identifiable<Tuple<int, int>>
{
    private int id_client;
    private int id_flight;

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public Tuple<int, int> getID()
    {
        return new Tuple<int,int>(id_client,id_flight);
    }

    public void setID(Tuple<int, int> id)
    {
        id_client= id.Item1;
        id_flight= id.Item2;
    }

    public override string ToString()
    {
        return "client: " + id_client.ToString() + " flight: " + id_flight.ToString();
    }
}

