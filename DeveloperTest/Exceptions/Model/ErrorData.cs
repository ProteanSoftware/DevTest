using System.Text.Json;

namespace DeveloperTest.Exceptions.Model;

public class ErrorData
{
    public int StatusCode { get; set; }

    public string Message { get; set; }

    public override string ToString() => 
        JsonSerializer.Serialize(this);
}