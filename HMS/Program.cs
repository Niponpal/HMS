using HMS.Data;
using HMS.Repositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("Coon")));
builder.Services.AddDbContext<AuthDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbConnectionString")));

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;

});
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();


builder.Services.AddScoped<IPatientRepository,PatientRepository>();
builder.Services.AddScoped<IDoctorRepository,DoctorRepository>();
builder.Services.AddScoped<IImageRepository,CloudinaryImageRepository>();
builder.Services.AddScoped<IAppointmentRepository,AppointmentRepository>();
builder.Services.AddScoped<IHospitalRoomRepository,HospitalRoomRepository>();
builder.Services.AddScoped<IAdmissionRepository,AdmissionRepository>();
builder.Services.AddScoped<IMedicalRecordRepository,MedicalRecordRepository>();
builder.Services.AddScoped<IInvoiceRepository,InvoiceRepository>();
builder.Services.AddScoped<IStaffRepository,StaffRepository>();
builder.Services.AddScoped<IMedicineRepository,MedicineRepository>();
builder.Services.AddScoped<ILabTestRepository,LabTestRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
     name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
