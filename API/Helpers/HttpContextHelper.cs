namespace school_admin_api.Helpers;

public class HttpContextHelper
{
    private readonly HttpContext _context;

    public HttpContextHelper(
        HttpContext context
        )
    {
        _context = context;
    }

    public string GetUsername() => (string)_context.Items["username"];
    public string GetProfile() => (string)_context.Items["profile"];
}