using log4net;
using SwimmingContest.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FlightBookingDBRepository : IFlightBookingRepository
{
    private static readonly ILog log = LogManager.GetLogger("FlightBookingDBRepository");

    IDictionary<string, string> props;

    public FlightBookingDBRepository(IDictionary<string, string> props)
    {
        this.props = props;
    }
    public void Delete(Tuple<int, int> id)
    {
        throw new NotImplementedException();
    }

    public FlightBooking FindOne(Tuple<int, int> id)
    {
        log.InfoFormat("Entering findOne with value {0}", id);
        IDbConnection con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from flight_bookings where id_client=@id_client and id_flight=@id_flight";

            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id_client";
            paramId.Value = id.Item1;
            comm.Parameters.Add(paramId);

            IDbDataParameter paramId2 = comm.CreateParameter();
            paramId2.ParameterName = "@id_flight";
            paramId2.Value = id.Item2;
            comm.Parameters.Add(paramId2);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    int id_client = dataR.GetInt32(0);
                    int id_flight = dataR.GetInt32(1);

                    FlightBooking flightBooking = new FlightBooking();
                    flightBooking.setID(new Tuple<int, int>(id_client, id_flight));

                    log.InfoFormat("Exiting findOne with value {0}", flightBooking);
                    return flightBooking;
                }
            }
        }
        log.InfoFormat("Exiting findOne with value {0}", null);
        return null;
    }

    public IEnumerable<FlightBooking> GetAll()
    {
        log.InfoFormat("Entering GetAll");
        IDbConnection con = DBUtils.getConnection(props);
        List<FlightBooking> list = new List<FlightBooking>();
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from flight_bookings";

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int id_client = dataR.GetInt32(0);
                    int id_flight = dataR.GetInt32(1);

                    FlightBooking flightBooking = new FlightBooking();
                    flightBooking.setID(new Tuple<int, int>(id_client, id_flight));

                    list.Add(flightBooking);
                    
                }
            }
        }
        log.InfoFormat("Exiting GetAll");
        return list;
    }

    public void Save(FlightBooking entity)
    {
        log.InfoFormat("Entering Save with value {0}", entity);
        var con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into flight_bookings(id_client,id_flight) values (@id_client,@id_flight)";
            var param1 = comm.CreateParameter();
            param1.ParameterName = "@id_client";
            param1.Value = entity.getID().Item1;
            comm.Parameters.Add(param1);

            var param2 = comm.CreateParameter();
            param2.ParameterName = "@id_flight";
            param2.Value = entity.getID().Item2;
            comm.Parameters.Add(param2);


            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new Exception("No bookings added !");
        }
        log.InfoFormat("Exiting Save with value {0}", entity);
    }

    public void Update(FlightBooking entity)
    {
        throw new NotImplementedException();
    }
}

