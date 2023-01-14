using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cerulean.API.Authentication
{
    public class EverlandTokenAuthenticationHandler : AuthenticationHandler<EverlandTokenAuthenticationOptions>
    {
        public EverlandTokenAuthenticationHandler(IOptionsMonitor<EverlandTokenAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue value))
                return AuthenticateResult.NoResult();

            if (!value.Scheme.Equals("Bearer", StringComparison.OrdinalIgnoreCase))
                return AuthenticateResult.NoResult();



            var claim = new Claim("AccountId", "123456789");
            var identity = new ClaimsIdentity(new[] { claim });
            var principal = new ClaimsPrincipal(identity);


            var ticket = new AuthenticationTicket(principal, "EverlandToken");
            return AuthenticateResult.Success(ticket);
        }
    }
}
