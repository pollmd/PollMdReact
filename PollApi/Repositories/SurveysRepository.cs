using PollApi.Models;
using Dapper;

namespace PollApi.Repositories
{
    public class SurveysRepository : ISurveysRepository
    {
        private DapperContext _context;

        public SurveysRepository(DapperContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Survey>> GetSurveys()
        {
            var connection = _context.CreateConecton();
            var query = "select id, name, description, startdate,enddate,price,type from survey";

            var result = await connection.QueryAsync<Survey>(query);

            return result;
        }
    }

    public interface ISurveysRepository
    {
        Task<IEnumerable<Survey>> GetSurveys();
    }
}
