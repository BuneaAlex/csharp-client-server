using System;

[Serializable]
public class Agent : Identifiable<int>
{
    private int _id;
    public string AgencyName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public Agent(int id,string agencyName,string userName,string password)
    {
        _id = id;
        AgencyName = agencyName;
        UserName = userName;
        Password = password;
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
        return "Id:" + _id + "Agency: " + AgencyName + " " + "UserName: " + UserName + " " +
            "Password: " + Password;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
