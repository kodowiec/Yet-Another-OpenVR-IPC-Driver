using System.Globalization;
using System.Numerics;

namespace HmdRotation
{
    class DevicePose
    {
        public string? DeviceID { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 EulerAngles { get; set; }


        public DevicePose(string ipcMessage)
        {
            this.Update(ipcMessage);
        }

        public void Update(string ipcMessage)
        {
            string[] strings;

            strings = ipcMessage.Split(' ');
            strings = strings.Skip(1).ToArray();

            if (strings.Length < 10) return;

            this.DeviceID = strings[1];

            this.Position = new()
            {
                X = float.Parse(strings[2], CultureInfo.InvariantCulture),
                Y = float.Parse(strings[3], CultureInfo.InvariantCulture),
                Z = float.Parse(strings[4], CultureInfo.InvariantCulture)
            };

            this.Rotation = new()
            {
                W = float.Parse(strings[5], CultureInfo.InvariantCulture),
                X = float.Parse(strings[6], CultureInfo.InvariantCulture),
                Y = float.Parse(strings[7], CultureInfo.InvariantCulture),
                Z = float.Parse(strings[8], CultureInfo.InvariantCulture)
            };

            this.EulerAngles = new()
            {
                // x - roll
                X = float.Parse(strings[11], CultureInfo.InvariantCulture), 
                // y - pitch
                Y = float.Parse(strings[10], CultureInfo.InvariantCulture),
                // z - yaw
                Z = float.Parse(strings[9], CultureInfo.InvariantCulture)
            };
        }
    }
}
