namespace roadcast.Api.Requests;

/// <summary>
/// MAKE AUTO REGISTER to create 1-click registration (anon)
/// </summary>
public class RegisterRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
