using DecoraTeb.Data.Entities;
using DecoraTeb.Data.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Data.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
    {
    }

    public DbSet<Service> Services { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<ProjectCategory> ProjectCategories { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectImage> ProjectImages { get; set; }
   // public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogCategory> BlogCategories { get; set; }
    public DbSet<FAQ> FAQs { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<ContantRequest> ContantRequests { get; set; }
    public DbSet<ConsultationRequest> ConsultationRequests { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }
    public DbSet<SiteSetting> SiteSettings { get; set; }
    public DbSet<WebPage> WebPages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new WebPageSeeder());
    }
}
