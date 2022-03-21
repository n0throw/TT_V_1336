using System.Text.Json.Serialization;

namespace TT.dtoContract;

public class Brigade
{
	[JsonPropertyName("code")]
	public string Code { get; set; }
}
