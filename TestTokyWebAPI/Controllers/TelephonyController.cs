using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using TestTokyWebAPI.constant;
using TestTokyWebAPI.Hubs;
using TestTokyWebAPI.Model;
using TestTokyWebAPI.Model.Request;

namespace TestTokyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephonyController : ControllerBase
    {
        private readonly IHubContext<TelephonyHub> _telephonyHubContex;

        public TelephonyController(IHubContext<TelephonyHub> telephonyHub)
        {
            _telephonyHubContex = telephonyHub;
        }

        [HttpPost]
        public IActionResult Call([FromBody] MakeCallRequestDto dto)
        {
            try
            {
                BusinessTarget businessTarget = new BusinessTarget
                {
                    Agent = dto.Agent,
                    Lead = dto.Lead
                };

                Assignment assignment = new Assignment(555, businessTarget);

                string jsonToAngular = JsonSerializer.Serialize(assignment);
                _telephonyHubContex.Clients.All.SendAsync("CallLeadOnFront", jsonToAngular);//lo enviamos a el hub

                assignment.Status = AssignmentStatus.CONTACTED;
                string jsonToAssignator= JsonSerializer.Serialize(assignment);

                return StatusCode(200, jsonToAssignator);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errorMsg = ex.Message });
            }
        }
    }
}
