using TestTokyWebAPI.Hubs;

namespace TestTokyWebAPI
{
    public static class Startup
    {
        public static WebApplication InitializeWebApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services);

            var app = builder.Build();
            Configure(app);
            return app;
        }

        //To configure servicies and register classes in the IoC Container
        private static void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSignalR();

            services.AddCors(options =>
            {
                options.AddPolicy("TodosPermitidos",
                    builder =>
                    {
                        builder.AllowAnyHeader();//todos las cabeceras
                        builder.AllowAnyMethod();//todos los metodos https, get, post, put, etc
                        builder.SetIsOriginAllowed((Host) => true);   //que permita todos los dominios .. pero investiga que es esto
                        builder.AllowCredentials();//permita todas las credenciales
                                                   //builder.AllowAnyOrigin();// creo que con este bastaba y ya no era necesario poner todo lo demas.. investiga mas al respecto
                    });

            });
        }

        //To configure the middleware
        private static void Configure(WebApplication app)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();



            app.MapControllers();

            app.UseCors("TodosPermitidos");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Esto lo comento porque esto es para los controllers REST Api 
                //pero parece que para NET 6 ya no es necesario y el NET 6 lo asume por defecto
                /*endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");*/

                endpoints.MapHub<TelephonyHub>("/hub/Telephony");   //-> https://localhost:7292/hub/telephony
            });

        }
    }
}
