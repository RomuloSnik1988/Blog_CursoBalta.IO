using Blog.Data;

var builder = WebApplication.CreateBuilder(args);
//Adicionar Controlers
builder
    .Services
    .AddControllers()
    //Desabilitando validações automaticas
    .ConfigureApiBehaviorOptions(options => {
        options.SuppressModelStateInvalidFilter = true;
    });
    
//Injetar contexto
builder.Services.AddDbContext<BlogDataContext>();

var app = builder.Build();
app.MapControllers();

app.Run();
