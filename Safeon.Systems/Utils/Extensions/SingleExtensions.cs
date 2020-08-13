using System;

namespace Safeon.Systems.Utils.Extensions
{
    public static class SingleExtensions
    {
        public static Single Round(this float value, int precision = 6)
        {
            return (Single)Math.Round(value, precision);
        }

        public static Single Round(this float value, int precision, MidpointRounding mode)
        {
            return (Single)Math.Round(value, precision, mode);
        }
    }
}