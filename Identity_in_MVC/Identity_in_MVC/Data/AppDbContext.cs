using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity_in_MVC.Data

{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
    }
}
