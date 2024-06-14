using Kolokwium02.Context;

namespace Kolokwium02;


public class Program
{
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        //Registering services
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        
        /*
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<MasterContext, MasterContext>();
        builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
        */

        builder.Services.AddDbContext<SubContext>();
        
        
        var app = builder.Build();

        //Configuring the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}