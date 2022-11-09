using System;

namespace LocationByZip;

internal static class MathExtensions
{
    /// <summary>
    /// π / 180°
    /// </summary>
    private static readonly double _PI_OVER_180 = Math.PI / 180.0;

    /// <summary>
    /// 180° / π
    /// </summary>
    private static readonly double _180_OVER_PI = 180.0 / Math.PI;


    /// <summary>
    /// Convert degrees to radians.
    /// </summary>
    internal static double ToRadians(this double degrees) => degrees * _PI_OVER_180;

    /// <summary>
    /// Convert radians to degrees.
    /// </summary>
    internal static double ToDegrees(this double radians) => radians * _180_OVER_PI;
}
