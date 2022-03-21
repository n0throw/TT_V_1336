using System.Text.Json.Serialization;

namespace TT.dtoContract;

public class Device
{
	[JsonPropertyName("serialNumber")]
	public string SerialNumber { get; set; }
	[JsonPropertyName("isOnline")]
	public bool IsOnline { get; set; }
}
