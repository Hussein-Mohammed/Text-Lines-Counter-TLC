using Lines_Counter.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Lines_Counter.Headers;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<Uploaded_Images>();
builder.Services.AddSingleton<Temp_Parameters>();

var app = builder.Build();

app.Environment.EnvironmentName = "Staging";

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

string Manuscripts_Folder = "Manuscripts";
string Histogram_Folder = "Histogram";
string Preprocessed_Folder = "Preprocessed";
string Pattern_Folder = "Pattern";
string Enhanced_Folder = "Enhanced";
string NumberedLines_Folder = "NumberedLines";
string Temp_Folder = "Temp";
string webRootPath = app.Environment.WebRootPath;
string Manuscripts_Path = Path.Combine(webRootPath, Manuscripts_Folder);
string Preprocessed_Path = Path.Combine(webRootPath, Preprocessed_Folder);
string Pattern_Path = Path.Combine(webRootPath, Pattern_Folder);
string Histogram_Path = Path.Combine(webRootPath, Histogram_Folder);
string Enhanced_Path = Path.Combine(webRootPath, Enhanced_Folder);
string NumberedLines_Path = Path.Combine(webRootPath, NumberedLines_Folder);
string TempPath = Path.Combine(webRootPath, Temp_Folder);

if (!Directory.Exists(Manuscripts_Path))
{
	Directory.CreateDirectory(Manuscripts_Path);
}
Directory.EnumerateFiles(Manuscripts_Path).ToList().ForEach(f => System.IO.File.Delete(f));
if (!Directory.Exists(Preprocessed_Path))
{
	Directory.CreateDirectory(Preprocessed_Path);
}
Directory.EnumerateFiles(Preprocessed_Path).ToList().ForEach(f => System.IO.File.Delete(f));

if (!Directory.Exists(Pattern_Path))
{
	Directory.CreateDirectory(Pattern_Path);
}
Directory.EnumerateFiles(Pattern_Path).ToList().ForEach(f => System.IO.File.Delete(f));

if (!Directory.Exists(Histogram_Path))
{
	Directory.CreateDirectory(Histogram_Path);
}
Directory.EnumerateFiles(Histogram_Path).ToList().ForEach(f => System.IO.File.Delete(f));

if (!Directory.Exists(Enhanced_Path))
{
	Directory.CreateDirectory(Enhanced_Path);
}
Directory.EnumerateFiles(Enhanced_Path).ToList().ForEach(f => System.IO.File.Delete(f));
if (!Directory.Exists(NumberedLines_Path))
{
	Directory.CreateDirectory(NumberedLines_Path);
}
Directory.EnumerateFiles(NumberedLines_Path).ToList().ForEach(f => System.IO.File.Delete(f));
if (!Directory.Exists(TempPath))
{
	Directory.CreateDirectory(TempPath);
}
Directory.EnumerateFiles(TempPath).ToList().ForEach(f => System.IO.File.Delete(f));


//Console.WriteLine("Url: ");
//Console.WriteLine(app.Urls.Count());
//Console.WriteLine("--------------");

Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

app.Lifetime.ApplicationStarted.Register(() => Process.Start(new ProcessStartInfo("cmd", $"/c start {app.Urls.First()}")
{
    CreateNoWindow = true
}));

app.Run();