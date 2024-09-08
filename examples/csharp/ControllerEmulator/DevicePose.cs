using System.Globalization;
using System.Numerics;

namespace ControllerEmulator
{
    static class CeMath
    {
        public static Quaternion Multiply(this Quaternion lhs, Quaternion rhs)
        {
            return new Quaternion
            {
                W = (lhs.W * rhs.W) - (lhs.X * rhs.X) - (lhs.Y * rhs.Y) - (lhs.Z * rhs.Z),
                X = (lhs.W * rhs.X) + (lhs.X * rhs.W) + (lhs.Y * rhs.Z) - (lhs.Z * rhs.Y),
                Y = (lhs.W * rhs.Y) + (lhs.Y * rhs.W) + (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                Z = (lhs.W * rhs.Z) + (lhs.Z * rhs.W) + (lhs.X * rhs.Y) - (lhs.Y * rhs.X)
            };
        }

        public static Quaternion quaternionFromRotationX(double rot)
        {
            double ha = rot / 2;
            return new()
            {
                W = (float)Math.Cos(ha),
                X = (float)Math.Sin(ha),
                Y = 0.0f,
                Z = 0.0f
            };
        }

        public static Quaternion quaternionFromRotationY(double rot)
        {
            double ha = rot / 2f;
            return new()
            {
                W = (float)Math.Cos(ha),
                X = 0.0f,
                Y = (float)Math.Sin(ha),
                Z = 0.0f
            };
        }

        public static Quaternion quaternionFromRotationZ(double rot)
        {
            double ha = rot / 2f;
            return new()
            {
                W = (float)Math.Cos(ha),
                X = 0.0f,
                Y = 0.0f,
                Z = (float)Math.Sin(ha)
            };
        }

        public static Quaternion QuaternionFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            return quaternionFromRotationY(yaw) * quaternionFromRotationX(pitch) * quaternionFromRotationZ(roll);
        }
    }
    class DevicePose
    {
        public string? DeviceID { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 EulerAngles { get; set; }

        public DevicePose() { }

        public void UpdateFromIpc(string ipcMessage)
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
