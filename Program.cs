using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

app.MapGet("/token", () =>
{
    
    var environmentId = builder.Configuration.GetValue<string>("CKBoxEnvironmentId");
    var accessKey = builder.Configuration.GetValue<string>("CKBoxAccessKey");
    var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(accessKey));

    var signingCredentials = new SigningCredentials(securityKey, "HS256");
    var header = new JwtHeader(signingCredentials);

    var dateTimeOffset = new DateTimeOffset(DateTime.UtcNow);

    var payload = new JwtPayload
    {
        { "aud", environmentId },
        { "iat", dateTimeOffset.ToUnixTimeSeconds() },
        { "sub", "user-123" },
        { "user", new Dictionary<string, string> {
            { "email", "joe.doe@example.com" },
            { "name", "Joe Doe" }
        } },
        { "auth", new Dictionary<string, object> {
            { "ckbox", new Dictionary<string, string> {
                { "role", "admin" }
            } }
        } }
    };

    var securityToken = new JwtSecurityToken(header, payload);
    var handler = new JwtSecurityTokenHandler();

    return handler.WriteToken(securityToken);
});

app.MapRazorPages();
app.Run();