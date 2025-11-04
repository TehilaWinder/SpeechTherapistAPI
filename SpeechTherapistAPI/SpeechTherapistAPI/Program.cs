using SpeechTherapist.Core.Repository;
using SpeechTherapist.Core.Service;
using SpeechTherapist.Data;
using SpeechTherapist.Service;
using SpeechTherapistAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//יוצר מופע בודד לכל הרצה
builder.Services.AddSingleton<DataContext>();

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

app.MapControllers();

app.Run();
