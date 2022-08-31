using System.Reflection;
using Microsoft.Extensions.Configuration;
using ProtoConverter;
using ProtoConverter.Visitors;
using Serilog;

var settings = GetAppSettings();
var neededTypes = GetNeededTypes();
SetupLog();

var converter = new ProtoConverter.Converters.ProtoConverter();
var visitor = new ProtoVisitor(settings);

var files = neededTypes.SelectMany(x => converter.Convert(x)).ToList();

var path = Directory.GetCurrentDirectory() + "\\" + settings.Package;

Directory.CreateDirectory(path);


foreach (var file in files)
{
    using var tw = new StreamWriter(path + "\\" + file.Name + ".proto", false);
    tw.WriteLine(visitor.Visit(file));
}

AppSettings GetAppSettings()
{
    var settings = new AppSettings();
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
    configuration.Bind(settings);
    return settings;
}

List<Type> GetNeededTypes()
{
    var assembly = Assembly.LoadFrom(settings.PathToDll);
    return settings.ClassesToImport.Select(cl => assembly.ExportedTypes.First(x => x.Name == cl)).ToList();
}

void SetupLog()
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger();
}