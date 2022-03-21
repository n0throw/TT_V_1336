using System.Text.Json.Serialization;

namespace TT.dtoContract;

public class DeviceInfo
{
	[JsonPropertyName("device")]
	public Device Device { get; set; }

	[JsonPropertyName("brigade")]
	public Brigade Brigade { get; set; }
}
