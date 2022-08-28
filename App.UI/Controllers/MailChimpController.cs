using AppCore.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MailChimpController : ControllerBase
    {

        private readonly MailChimpServiceManager _mailChimpServiceManager;

        public MailChimpController(MailChimpServiceManager mailChimpServiceManager)
        {
            _mailChimpServiceManager = mailChimpServiceManager;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            var result = await _mailChimpServiceManager.AddToMailChimp(email);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(result.Error);
        }
    }
}