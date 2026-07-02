using DecoraTeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Service> Services { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<ProjectCategory> ProjectCategories { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectImsge> ProjectImsges { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogCategory> BlogCategories { get; set; }
    public DbSet<FAQ> FAQs { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<ContantRequest> ContantRequests { get; set; }
    public DbSet<ConsultationRequest> ConsultationRequests { get; set; }

}
