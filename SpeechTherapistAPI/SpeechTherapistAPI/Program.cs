using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SpeechTherapist.Core;
using SpeechTherapist.Core.Repository;
using SpeechTherapist.Core.Service;
using SpeechTherapist.Data;
using SpeechTherapist.Service;
using SpeechTherapistAPI;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//יוצר מופע בודד לכל הרצה
builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(MappingPostProfile),typeof(MappingPutProfile));

builder.Services.AddScoped<IPatientService,PatientService>();
builder.Services.AddScoped<IPatientRepository,PatientsRepository>();

builder.Services.AddScoped<ITreatmentsServie, TreatmentService>();
builder.Services.AddScoped<ITreatmentsRepository, TreatmentRepository>();

builder.Services.AddScoped<IAppointmentService, AppointmentsService>();
builder.Services.AddScoped<IAppointmentsRepository, AppointmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ShabbatMiddleware>();

app.MapControllers();

app.Run();
