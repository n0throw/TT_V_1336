using TT.dtoContract;

namespace TT;

public static class ConflictsChecker
{
    public static List<Conflict> Check(List<DeviceInfo> devices)
    {
        List<Conflict> conflicts = new();
        List<string> uniqueCode = GetUniqueCode(devices);

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

        return conflicts;
    }

    private static List<string> GetUniqueCode(List<DeviceInfo> devices)
    {
        List<string> output = new(devices.Count);

        devices.ForEach(device => output.Add(device.Brigade.Code));

        return output.Distinct().ToList();
    }

    private static string[] GetDevicesSerials(List<DeviceInfo> devices)
    {
        string[] output = new string[devices.Count];

        for (int i = 0; i < devices.Count; i++)
            output[i] = devices[i].Device.SerialNumber;

        return output;
    }
}
