using HotelWebApp.Data;
using HotelWebApp.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// MongoDB
builder.Services.Configure<DBSettings>(
    options =>
    {
        options.ConnectionString = builder.Configuration.GetSection("MongoDB:ConnectionString").Value;
        options.DatabaseName = builder.Configuration.GetSection("MongoDB:DatabaseName").Value;
    });

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRoom, MongoDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "allRooms",
    pattern: "allRooms/",
    defaults: new { controller = "Rooms", action = "AllRooms" });

app.MapControllerRoute(
    name: "roomInfo",
    pattern: "roomInfo/{id}",
    defaults: new { controller = "Rooms", action = "OneRoom" }
);

app.MapControllerRoute(
    name: "changeRoomInfo",
    pattern: "changeRoomInfo/{id}",
    defaults: new { controller = "Rooms", action = "ChangeRoomInfo" }
);

app.MapControllerRoute(
    name: "updateRoomInfo",
    pattern: "updateRoomInfo/{id}",
    defaults: new { controller = "Rooms", action = "UpdateRoomInfo" }
);

app.MapControllerRoute(
    name: "deleteRoom",
    pattern: "deleteRoom/{id}",
    defaults: new { controller = "Rooms", action = "DeleteRoom" }
);

app.MapControllerRoute(
    name: "deletePhoto",
    pattern: "{controller}/{action}",
    defaults: new { controller = "Rooms", action = "DeletePhoto" }
);

app.MapControllerRoute(
    name: "insertRoomForm",
    pattern: "insertRoomForm/",
    defaults: new { controller = "Rooms", action = "InsertFormPage" }
);

app.MapControllerRoute(
    name: "insertNewRoom",
    pattern: "insertNewRoom/",
    defaults: new { controller = "Rooms", action = "InsertNewRoom" }
);

app.Run();
