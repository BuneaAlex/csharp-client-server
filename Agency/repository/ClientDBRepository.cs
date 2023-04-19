using log4net;
using SwimmingContest.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ClientDBRepository : IClientRepository
{
    private static readonly ILog log = LogManager.GetLogger("ClientDBRepository");

    IDictionary<string, string> props;

    public ClientDBRepository(IDictionary<string, string> props)
    {
        this.props = props;
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Client> findClientsByNoOfSeatsReserved(int noOfSeats)
    {
        throw new NotImplementedException();
    }

    public Client FindOne(int id)
    {
        log.InfoFormat("Entering findOne with value {0}", id);
        IDbConnection con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from clients where id=@id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    string name = dataR.GetString(1);
                    string address = dataR.GetString(2);
                    int seats_reserved = dataR.GetInt32(3);
                    string tourists_names = dataR.GetString(4);

                    Client client = new Client(id, name, tourists_names, address, seats_reserved);
                    log.InfoFormat("Exiting findOne with value {0}", client);
                    return client;
                }
            }
        }
        log.InfoFormat("Exiting findOne with value {0}", null);
        return null;
    }

    public IEnumerable<Client> GetAll()
    {
        log.InfoFormat("Entering GetAll");
        IDbConnection con = DBUtils.getConnection(props);
        List<Client> list = new List<Client>();
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from clients";

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int id = dataR.GetInt32(0);
                    string name = dataR.GetString(1);
                    string address = dataR.GetString(2);
                    int seats_reserved = dataR.GetInt32(3);
                    string tourists_names = dataR.GetString(4);

                    Client client = new Client(id, name, tourists_names, address, seats_reserved);
                    list.Add(client);

                }
            }
        }
        log.InfoFormat("Exiting GetAll");
        return list;
        
    }

    public void Save(Client entity)
    {
        log.InfoFormat("Entering Save with value {0}", entity);
        var con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into clients(name,address,seats_reserved,tourists_names) values (@name,@address,@seats_reserved,@tourists_names)";
            var param1 = comm.CreateParameter();
            param1.ParameterName = "@name";
            param1.Value = entity.Name;
            comm.Parameters.Add(param1);

            var param2 = comm.CreateParameter();
            param2.ParameterName = "@address";
            param2.Value = entity.Address;
            comm.Parameters.Add(param2);

            var param3 = comm.CreateParameter();
            param3.ParameterName = "@seats_reserved";
            param3.Value = entity.NoOfSeatsReserved;
            comm.Parameters.Add(param3);

            var param4 = comm.CreateParameter();
            param4.ParameterName = "@tourists_names";
            param4.Value = entity.TouristNames;
            comm.Parameters.Add(param4);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new Exception("No clients added !");
        }
        log.InfoFormat("Exiting Save with value {0}", entity);
    }

    public void Update(Client entity)
    {
        throw new NotImplementedException();
    }
}

