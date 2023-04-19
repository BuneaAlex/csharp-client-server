using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Client : Identifiable<int>
{
    private int _id;

    public string Name { get; set; }

    public string TouristNames { get; set; }
    public string Address { get; set; }
    public int NoOfSeatsReserved { get; set; }

    public Client(int id, string name, string touristNames, string address, int noOfSeatsReserved)
    {
        _id = id;
        Name = name;
        TouristNames = touristNames;
        Address = address;
        NoOfSeatsReserved = noOfSeatsReserved;
    }

    public int getID()
    {
        return _id;
    }

    public void setID(int id)
    {
        _id= id;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return _id + " Name: " + Name + " " + "TouristNames: " + TouristNames + " " + 
            "Address: " + Address + " " + "NoOfSeatsReserved: " + NoOfSeatsReserved;
    }
}

