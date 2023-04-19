using log4net;
using SwimmingContest.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FlightDBRepository : IFlightRepository
{
    private static readonly ILog log = LogManager.GetLogger("FlightDBRepository");

    IDictionary<string, string> props;

    public FlightDBRepository(IDictionary<string, string> props)
    {
        this.props = props;
    }
    public void Delete(int id)
    {
        IDbConnection con = DBUtils.getConnection(props);
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "delete from flights where id=@id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);
            var dataR = comm.ExecuteNonQuery();
            if (dataR == 0)
                throw new Exception("No task deleted!");
        }
    }

    public List<Flight> FindAvailableFlights()
    {
        log.InfoFormat("Entering findAvailableFlights");
        IDbConnection con = DBUtils.getConnection(props);
        List<Flight> list = new List<Flight>();

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from flights where seats_left > 0";

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int id = dataR.GetInt32(0);
                    string destination = dataR.GetString(1);
                    DateTime date = dataR.GetDateTime(2);
                    string airport = dataR.GetString(3);
                    int seats_left = dataR.GetInt32(4);

                    Flight flight = new Flight(id, destination, date, airport, seats_left);
                    list.Add(flight);

                }
            }
        }
        log.InfoFormat("Exiting findAvailableFlights");
        return list;
    }

    public List<Flight> FindFlightByDestinationAndDatetime(string destination, DateTime date)
    {
        log.InfoFormat("Entering GetAll");
        IDbConnection con = DBUtils.getConnection(props);
        List<Flight> list = new List<Flight>();
        DateTime start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        DateTime end = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from flights where destination=@destination and departure_date > @departure_date_start and departure_date < @departure_date_end";
            IDbDataParameter param1 = comm.CreateParameter();
            param1.ParameterName = "@destination";
            param1.Value = destination;
            comm.Parameters.Add(param1);
            
            IDbDataParameter param2 = comm.CreateParameter();
            param2.ParameterName = "@departure_date_start";
            param2.Value = start;
            comm.Parameters.Add(param2);

            
            IDbDataParameter param3 = comm.CreateParameter();
            param3.ParameterName = "@departure_date_end";
            param3.Value = end;
            comm.Parameters.Add(param3);

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int id = dataR.GetInt32(0);
                    DateTime departure_date = dataR.GetDateTime(2);
                    string airport = dataR.GetString(3);
                    int seats_left = dataR.GetInt32(4);

                    Flight flight = new Flight(id, destination, departure_date, airport, seats_left);
                    list.Add(flight);

                }
            }
        }
        log.InfoFormat("Exiting GetAll");
        return list;
    }

    public Flight FindOne(int id)
    {
        log.InfoFormat("Entering findOne with value {0}", id);
        IDbConnection con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from flights where id=@id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    string destination = dataR.GetString(1);
                    DateTime date = dataR.GetDateTime(2);
                    string airport = dataR.GetString(3);
                    int seats_left = dataR.GetInt32(4);

                    Flight flight = new Flight(id, destination, date, airport, seats_left);
                    
                    log.InfoFormat("Exiting findOne with value {0}", flight);
                    return flight;
                }
            }
        }
        log.InfoFormat("Exiting findOne with value {0}", null);
        return null;
    }

    public IEnumerable<Flight> GetAll()
    {
        log.InfoFormat("Entering GetAll");
        IDbConnection con = DBUtils.getConnection(props);
        List<Flight> list = new List<Flight>();

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from flights";
            
            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int id = dataR.GetInt32(0);
                    string destination = dataR.GetString(1);
                    DateTime date = dataR.GetDateTime(2);
                    string airport = dataR.GetString(3);
                    int seats_left = dataR.GetInt32(4);

                    Flight flight = new Flight(id, destination, date, airport, seats_left);
                    list.Add(flight);
                    
                }
            }
        }
        log.InfoFormat("Exiting GetAll");
        return list;
    }

    public void Save(Flight entity)
    {
        log.InfoFormat("Entering Save with value {0}", entity);
        var con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into flights(destination,departure_date,airport,seats_left) values (@destination,@departure_date,@airport,@seats_left)";
            var param1 = comm.CreateParameter();
            param1.ParameterName = "@destination";
            param1.Value = entity.Destination;
            comm.Parameters.Add(param1);

            var param2 = comm.CreateParameter();
            param2.ParameterName = "@departure_date";
            param2.Value = entity.Date;
            comm.Parameters.Add(param2);

            var param3 = comm.CreateParameter();
            param3.ParameterName = "@airport";
            param3.Value = entity.AirportName;
            comm.Parameters.Add(param3);

            var param4 = comm.CreateParameter();
            param4.ParameterName = "@seats_left";
            param4.Value = entity.NoOfSeatsLeft;
            comm.Parameters.Add(param4);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new Exception("No flights added !");
        }
        log.InfoFormat("Exiting Save with value {0}", entity);
    }

    public void Update(Flight entity)
    {
        log.InfoFormat("Entering Update with value {0}", entity);
        var con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "update flights set destination=@destination,departure_date=@departure_date,airport=@airport,seats_left=@seats_left where id=@id";
            
            var param1 = comm.CreateParameter();
            param1.ParameterName = "@destination";
            param1.Value = entity.Destination;
            comm.Parameters.Add(param1);

            var param2 = comm.CreateParameter();
            param2.ParameterName = "@departure_date";
            param2.Value = entity.Date;
            comm.Parameters.Add(param2);

            var param3 = comm.CreateParameter();
            param3.ParameterName = "@airport";
            param3.Value = entity.AirportName;
            comm.Parameters.Add(param3);

            var param4 = comm.CreateParameter();
            param4.ParameterName = "@seats_left";
            param4.Value = entity.NoOfSeatsLeft;
            comm.Parameters.Add(param4);

            var param5 = comm.CreateParameter();
            param5.ParameterName = "@id";
            param5.Value = entity.getID();
            comm.Parameters.Add(param5);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new Exception("No flights updated !");
        }
        log.InfoFormat("Exiting Update with value {0}", entity);
    }
}

