using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Flight : Identifiable<int>
{
    private int _id;

    public string Destination { get; set; }

    public DateTime Date { get; set; }

    public string AirportName { get; set; }

    public int NoOfSeatsLeft { get; set; }

    public Flight(int id, string destination, DateTime date, string airportName, int noOfSeatsLeft)
    {
        _id = id;
        Destination = destination;
        Date = date;
        AirportName = airportName;
        NoOfSeatsLeft = noOfSeatsLeft;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public int getID()
    {
        return _id;
    }

    public void setID(int id)
    {
        _id = id;
    }

    public override string ToString()
    {
        return _id + " Destination: " + Destination + " " + "Date: " + Date + " " +
            "AirportName: " + AirportName + " " + "NoOfSeatsLeft: " + NoOfSeatsLeft;
    }
}

