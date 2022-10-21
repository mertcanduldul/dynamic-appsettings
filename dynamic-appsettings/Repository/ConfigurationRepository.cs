using System.Data;
using Dapper;
using dynamic_appsettings.Model;
using dynamic_appsettings.Repository.Base;
using Microsoft.Extensions.Options;

namespace dynamic_appsettings.Repository;

public class ConfigurationRepository : BaseRepository, IDataRepository<ConfigurationModel>
{
    #region MyRegion
    public IEnumerable<ConfigurationModel> GetAll()
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = @"SELECT * FROM Configuration";
            return dbConnection.Query<ConfigurationModel>(query);
        }
    }

    public ConfigurationModel Get(decimal id)
    {
        throw new NotImplementedException();
    }

    public void Add(ConfigurationModel entity)
    {
        throw new NotImplementedException();
    }

    public void Update(ConfigurationModel entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ConfigurationModel entity)
    {
        throw new NotImplementedException();
    }
    #endregion

    public async Task<Dictionary<string, object>> ConfigurationList()
    {
        Dictionary<string, object> configurationList = new Dictionary<string, object>();
        using (IDbConnection dbConnection = Connection)
        {
            string query = @"SELECT * FROM Configuration";
            var result = await dbConnection.QueryAsync<ConfigurationModel>(query);
            foreach (var item in result)
            {
                configurationList.Add(item.AppKey, item.AppValue);
            }
        }

        return configurationList;
    }

}