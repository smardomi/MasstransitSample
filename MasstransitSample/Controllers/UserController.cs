using MassTransit;
using MasstransitSample.Data;
using MasstransitSample.Events;
using Microsoft.AspNetCore.Mvc;

namespace MasstransitSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ApplicationDbContext context;

        public UserController(ILogger<UserController> logger,
                                         IPublishEndpoint publishEndpoint,
                                         ApplicationDbContext context)
        {
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            await publishEndpoint.Publish(new UserCreatedEvent());
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}