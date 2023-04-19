using log4net;
using SwimmingContest.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AgentDBRepository : IAgentRepository
{
    private static readonly ILog log = LogManager.GetLogger("AgentDBRepository");

    IDictionary<string, string> props;

    public AgentDBRepository(IDictionary<string, string> props)
    {
        this.props = props;
    }

    public Agent FindAgentByLoginInformation(string agencyName, string userName, string password)
    {
        log.InfoFormat("Entering FindAgentByLoginInformation with value {0} {1} {2}", agencyName, userName, password);
        IDbConnection con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from agents where user_name=@user_name and agency_name=@agency_name and password=@password";
            IDbDataParameter param1 = comm.CreateParameter();
            param1.ParameterName = "@user_name";
            param1.Value = userName;
            comm.Parameters.Add(param1);

            IDbDataParameter param2 = comm.CreateParameter();
            param2.ParameterName = "@agency_name";
            param2.Value = agencyName;
            comm.Parameters.Add(param2);

            IDbDataParameter param3 = comm.CreateParameter();
            param3.ParameterName = "@password";
            param3.Value = password;
            comm.Parameters.Add(param3);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    int id = dataR.GetInt32(0);
                    string user_name = dataR.GetString(1);
                    string agency_name = dataR.GetString(2);
                    string user_password = dataR.GetString(3);

                    Agent agent = new Agent(id, user_name, agency_name, user_password);
                    log.InfoFormat("Exiting findOne with value {0}", agent);
                    return agent;
                }
            }
        }
        log.InfoFormat("Exiting findOne with value {0}", null);
        return null;
    }

    public Agent FindOne(int id)
    {
        log.InfoFormat("Entering findOne with value {0}", id);
        IDbConnection con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from agents where id=@id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    string user_name = dataR.GetString(1);
                    string agency_name = dataR.GetString(2);
                    string password = dataR.GetString(3);

                    Agent agent = new Agent(id, user_name, agency_name, password);
                    log.InfoFormat("Exiting findOne with value {0}", agent);
                    return agent;
                }
            }
        }
        log.InfoFormat("Exiting findOne with value {0}", null);
        return null;
    }

    public IEnumerable<Agent> GetAll()
    {
        log.InfoFormat("Entering GetAll");
        IDbConnection con = DBUtils.getConnection(props);
        List<Agent> list = new List<Agent>();
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from agents";

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int id = dataR.GetInt32(0);
                    string user_name = dataR.GetString(1);
                    string agency_name = dataR.GetString(2);
                    string password = dataR.GetString(3);

                    Agent agent = new Agent(id, user_name, agency_name, password);
                    list.Add(agent);
                    
                }
            }
        }
        log.InfoFormat("Exiting GetAll");
        return list;
    }

    public void Save(Agent entity)
    {
        log.InfoFormat("Entering Save with value {0}", entity);
        var con = DBUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into agents(user_name,agency_name,password) values (@user_name, @agency_name, @password)";
            var param1 = comm.CreateParameter();
            param1.ParameterName = "@user_name";
            param1.Value = entity.UserName;
            comm.Parameters.Add(param1);

            var param2 = comm.CreateParameter();
            param2.ParameterName = "@agency_name";
            param2.Value = entity.AgencyName;
            comm.Parameters.Add(param2);

            var param3 = comm.CreateParameter();
            param3.ParameterName = "@password";
            param3.Value = entity.Password;
            comm.Parameters.Add(param3);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new Exception("No agents added !");
        }
        log.InfoFormat("Exiting Save with value {0}", entity);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Agent entity)
    {
        throw new NotImplementedException();
    }
}

