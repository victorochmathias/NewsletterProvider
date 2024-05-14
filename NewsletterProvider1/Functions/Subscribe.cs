using Data.Contexts;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NewsletterProvider1.Functions
{
    public class Subscribe(ILogger<Subscribe> logger, DataContext context)
    {
        private readonly ILogger<Subscribe> _logger = logger;
        private readonly DataContext _context = context;

        [Function("Subscribe")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            if (!string.IsNullOrEmpty(body))
            {
                var subscribeEntity = JsonConvert.DeserializeObject<SubscribeEntity>(body);
                if (subscribeEntity != null)
                {

                    var existingSubscriber = await _context.Subscribers.FirstOrDefaultAsync(s => s.Email == subscribeEntity.Email);
                    if (existingSubscriber != null)
                    {
                        _context.Entry(existingSubscriber).CurrentValues.SetValues(subscribeEntity);
                        await _context.SaveChangesAsync();
                        return new OkObjectResult(new { Status = 200, Message = "Subscriber was updated." });
                    }

                    _context.Subscribers.Add(subscribeEntity);
                    await _context.SaveChangesAsync();
                    return new OkObjectResult(new { Status = 200, Message = "Subscriber is now subscribed." });
                }
            }

            return new BadRequestObjectResult(new { Status = 400, Message = "Unable to subscribe right now." });
        }
    }
}
