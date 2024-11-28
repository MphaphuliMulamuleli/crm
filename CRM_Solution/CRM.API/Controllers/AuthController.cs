using CRM.Infrastructure.Data; // Ensure this is the correct namespace
using Microsoft.AspNetCore.Mvc; // Add this if not already present

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly CrmDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(CrmDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto userDto)
    {
        // Registration logic here
        return Ok(new { Message = "User registered successfully." });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto userDto)
    {
        // Login logic here
        return Ok(new { Token = "generated-jwt-token" });
    }
} 