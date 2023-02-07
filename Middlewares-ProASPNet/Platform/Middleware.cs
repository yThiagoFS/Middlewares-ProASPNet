using Microsoft.Extensions.Options;

namespace Middlewares_ProASPNet.Platform
{
    public class Middleware
    {
        public class LocationMiddleware
        {
            private RequestDelegate _next;
            private MessageOptions options;

            public LocationMiddleware(RequestDelegate nextDelegate, IOptions<MessageOptions> opts)
            {
                _next = nextDelegate;
                options = opts.Value;
            }

            public async Task Invoke(HttpContext context)
            {
                if(context.Request.Path == "/location")
                {
                    await context.Response.WriteAsync($"{options.CityName}, {options.CountryName}");
                } else
                {
                    await _next(context);
                }
            }
        }
    }
}
