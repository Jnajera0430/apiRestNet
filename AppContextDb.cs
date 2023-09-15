using Microsoft.EntityFrameworkCore;
using webapi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsDb) : base(optionsDb)
    { }

    public DbSet<TaskInserted> Tasks { get; set; }
    public DbSet<Categoria> Categorys { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categorysInit = new List<Categoria>();
        categorysInit.Add(new Categoria()
        {
            id = Guid.Parse("sfdkj405-c98e-4c60-ac52-dasdashjjahjas"),
            Name = "Rutina Gym",
            Description = "Todas mis rutinas de ejercicio",
            Weight = 25
        });
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Categoria>(Categoria =>
        {
            Categoria.ToTable("Categorys");
            Categoria.Property(p => p.Name).IsRequired().HasMaxLength(150);
            Categoria.Property(p => p.Description).IsRequired(false);
            Categoria.Property(p => p.Weight);
            Categoria.HasData(categorysInit);
        });

        List<TaskInserted> TasksInitial = new List<TaskInserted>();
        TasksInitial.Add(new TaskInserted()
        {
            id = Guid.Parse("sfdkj859-c98e-4c60-ac52-dasdashjjadasg"),
            Title = "Pechos de hierro",
            Description = "Todos los ejercicios para pecho",
            PriorityTask = Priority.alta,
            IdCategory = Guid.Parse("sfdkj405-c98e-4c60-ac52-dasdashjjahjas"),
            createdAt = DateTime.Now
        });
        TasksInitial.Add(new TaskInserted()
        {
            id = Guid.Parse("sfdkj859-c98e-4c60-ac52-dasdashjjadasg"),
            Title = "Piernas sexis",
            Description = "Todos los ejercicios para piernas",
            PriorityTask = Priority.alta,
            IdCategory = Guid.Parse("sfdkj405-c98e-4c60-ac52-dasdashjjahjas"),
            createdAt = DateTime.Now
        });
        modelBuilder.Entity<TaskInserted>(task =>
        {
            task.ToTable("Tasks");
            task.HasKey(p => p.id);
            task.HasOne(p => p.Category).WithMany(p => p.tasks).HasForeignKey(p => p.IdCategory);
            task.Property(p => p.Title).IsRequired().HasMaxLength(100);
            task.Property(p => p.Description).IsRequired(false);
            task.Property(p => p.PriorityTask);
            task.Property(p => p.createdAt);
            task.Property(p => p.Resumen);
            task.Ignore(p=>p.Resumen);
            task.HasData(TasksInitial);
        });
    }
}