namespace ProtoConverter;

public class AppSettings
{
    public string PathToDll { get; set; }

    public string Namespace { get; set; }
    
    public string Package { get; set; }
    
    public string[] ClassesToImport { get; set; }
}