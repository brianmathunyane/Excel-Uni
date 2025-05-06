namespace StudentTracker.Services
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Options;
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;
    using System.Text.Encodings.Web;
    using StudentTracker.Data;

    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private readonly ConfigurationManagerService _configurationManagerService;

        [Obsolete]
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                           ILoggerFactory logger,
                                           UrlEncoder encoder,
                                           ISystemClock clock,
                                           ConfigurationManagerService configurationManagerService)
            : base(options, logger, encoder, clock)
        {
           _configurationManagerService = configurationManagerService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Check if Authorization header is present
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));

            // Parse the authorization header
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var authHeader = authorizationHeader.Split(' ');

            if (authHeader.Length != 2 || authHeader[0] != "Basic")
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));

            var encodedCredentials = authHeader[1];
            var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
            var credentials = decodedCredentials.Split(':');

            if (credentials.Length != 2)
                return Task.FromResult(AuthenticateResult.Fail("Invalid Credentials Format"));

            var username = credentials[0];
            var password = credentials[1];

            // Validate credentials 
            if (IsValidUser(username, password))
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, username)
            };

                var identity = new ClaimsIdentity(claims, "Basic");
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, "Basic");

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }

            return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));
        }

        private bool IsValidUser(string username, string password)
        {
           
            return username == _configurationManagerService.GetUsername() && password == _configurationManagerService.GetPassword();
        }
    }

}
