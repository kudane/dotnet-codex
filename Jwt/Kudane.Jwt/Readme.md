การใช้งาน Kudane.Jwt ในโปรเจกต์ C# ของคุณ

```c#
var services = new ServiceCollection();

services.AddSingleton<IJwtService, JwtService>();

```

```c#
public class AuthenticationController : ControllerBase
{
	private readonly IJwtService _jwtService;

	public AuthenticationController(IJwtService jwtService)
	{
		_jwtService = jwtService;
	}

	[HttpPost("login")]
	public IActionResult Login([FromBody] LoginRequest request)
	{
		var cliams = new Dictionary<string, string>()
		{
			{ "UserId", "U123" },
			{ "Email", "U123@mail.com" }
		};	

		var secreatKey = "get your secret key"

		var expiresInMinutes = 60;

		var signData = new SignData(cliams, secreatKey, expiresInMinutes);

		var token = _jwtService.SignToken(signData);

		return Ok(new { Token = token });
	}
}
```