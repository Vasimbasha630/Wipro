using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CmsDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("CmsConn")));

var app = builder.Build();

/* ───── show detailed errors only in Development ───── */
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();   // ← add this line first
    app.UseSwagger();
    app.UseSwaggerUI();
}
/* ───────────────────────────────────────────────────── */

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.Run();
