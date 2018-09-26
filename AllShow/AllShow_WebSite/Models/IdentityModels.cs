using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AllShow_WebSite.Models
{
    // 您可將更多屬性新增至 ApplicationUser 類別，藉此為使用者新增設定檔資料，如需深入了解，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=317594。
    public class ApplicationUser : IdentityUser
    {
        public string NickName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 注意 authenticationType 必須符合 CookieAuthenticationOptions.AuthenticationType 中定義的項目
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在這裡新增自訂使用者宣告
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AllShowConnectionString", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //這必需在第一行
            base.OnModelCreating(modelBuilder);
            //以下依實際情境來調整 table name
            modelBuilder.Entity<ApplicationUser>().ToTable("CustomUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("CustomRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("CustomUserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("CustomUserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("CustomUserLogins");
        }
    }
}