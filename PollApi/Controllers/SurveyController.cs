using Microsoft.AspNetCore.Mvc;

namespace PollApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ILogger<SurveyController> _logger;

        public SurveyController(ILogger<SurveyController> logger)
        {
            _logger = logger;
        } 

        [HttpGet(Name = "GetSurveys")]
        public IEnumerable<Survey> Get()
        {
            var list = new List<Survey>
            {
                new Survey
                {
                    Id = 1,
                    Name="Impactul schimbării climaterice",
                    Description = "Impactul schimbării climaterice",
                    CreationTime = DateTime.Now,
                },                     new Survey
                {
                    Id = 2,
                    Name="Mijloacele de informare",
                    Description = "Mijloacele de informare",
                    CreationTime = DateTime.Now,
                }
            };

            return list.ToArray();
        }
    }
}