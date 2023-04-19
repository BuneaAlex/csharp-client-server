using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class FlightDTO : Identifiable<int>
{
    private int _id;

    public DateTime Date { get; set; }

    public int NoOfSeatsLeft { get; set; }

    public FlightDTO(int id, DateTime date, int noOfSeatsLeft)
    {
        _id = id;
        Date = date;
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
        return  "Date: " + Date + " " + "NoOfSeatsLeft: " + NoOfSeatsLeft;
    }
}

