#region project_lib
using TT.dtoContract;
using TT.IO;
#endregion

namespace TT;

public class Checker
{
    public List<DeviceInfo> devices;
    public List<Conflict> conflicts;
    private readonly IReader reader;
    private readonly IWriter writer;

    public Checker(IReader reader, IWriter writer)
    {
        devices = new();
        conflicts = new();

        this.reader = reader;
        this.writer = writer;
    }

    public void Read(string path) => devices = reader.Read(path);
    public void Write(string path) => writer.Write(conflicts, path);
    public void Check()
    {
        conflicts.Clear();
        List<string> uniqueCode = GetUniqueCode();

        for (int i = 0; i < uniqueCode.Count; i++)
        {
            List<DeviceInfo> tempDevices = devices.Where(tempDevice => tempDevice.Brigade.Code == uniqueCode[i]).ToList();

            if (tempDevices.Count > 1 && tempDevices.Any(device => device.Device.IsOnline))
            {
                conflicts.Add(new Conflict()
                {
                    BrigadeCode = uniqueCode[i],
                    DevicesSerials = GetDevicesSerials(tempDevices)
                });
            }

        }        
    }

    private List<string> GetUniqueCode()
    {
        List<string> output = new();
        devices.ForEach(device =>
        {
            if (!output.Contains(device.Brigade.Code))
                output.Add(device.Brigade.Code);
        });

        return output;
    }

    private static string[] GetDevicesSerials(List<DeviceInfo> tempDevices)
    {
        string[] output = new string[tempDevices.Count];

        for (int i = 0; i < tempDevices.Count; i++)
            output[i] = tempDevices[i].Device.SerialNumber;

        return output;
    }
}
