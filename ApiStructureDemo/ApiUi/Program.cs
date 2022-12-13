namespace ApiUi;
using RepoLayer;
using BusinessLayer;


public class Program
{
    public static void Main(string[] args)
    {   
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


         builder.Services.AddScoped<IRepositoryClass, RepositoryClass>();
        builder.Services.AddScoped<IBusinessLayerClass, BusinessLayerClass>();
        builder.Services.AddSingleton<IMyLogger, MyLogger>();
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
