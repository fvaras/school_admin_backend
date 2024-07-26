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
    public string GetProfileId() => (string)_context.Items["profileId"];
    public Guid GetUserProfileId() => (Guid)_context.Items["userProfileId"];
}