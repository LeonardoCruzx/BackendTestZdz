namespace BackendTest.Features.User.Resources;

public class TokenResource
{
    public string Token { get; set; }

    public TokenResource(string token)
    {
        Token = token;
    }
}
