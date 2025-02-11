namespace DemoCICD.Domain.Entities.Identity;

public class AppUserLogin
{
    public string UserId { get; set; }
    public string LoginProvider { get; set; }
    public string ProviderKey { get; set; }
    public string ProviderDisplayName { get; set; }
}