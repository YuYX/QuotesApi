using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In order to support XML formatted return body.
builder.Services.AddMvc().AddXmlDataContractSerializerFormatters();

builder.Services.AddResponseCaching();

// 1. Add Authentication Services  
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	//options.Authority = "https://yuyongxue.us.auth0.com/";
	options.Authority = "https://dev-go1ymqgvrxu0i24r.us.auth0.com/";
	options.Audience = "https://localhost:7114/";
});


// In order to solve the case that a parameter is absent.(the 'sort')
builder.Services.AddControllers(
	options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
} 
app.UseHttpsRedirection(); 

app.UseResponseCaching();

// 2. Enable authentication middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
