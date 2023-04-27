using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MoviesAPI2022.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//-C- to add cores step1
   builder.Services.AddCors();
builder.Services.AddSwaggerGen(options =>
{
    //-A-change the look or the documentation on swagger
options.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "my first api",
    Description = "this a test to api",
    TermsOfService = new Uri("http://google.com"),
    Contact = new OpenApiContact
    {
        Name = "mohamed talaat",
        Email = "elseady174@gmail.com",
    },
    License = new OpenApiLicense
    {
        Name = "My License",
        Url = new Uri("http://google.com"),
    }
});

    //-B- security point 1
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT key"
    });

   // -B- security point2
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Name="Bearer",
                In= ParameterLocation.Header
            },
            new List<string>()
        }

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//-C- to specify cores step2
app.UseCors(c => c.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
// «·›ÌœÌÊ «·”«»⁄ «»ﬁÌ ‘Ê›Â  «‰Ì » «⁄ «÷«›Â «·œ« « »Ì“