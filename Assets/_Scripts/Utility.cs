using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{

    /// <summary>
    /// Returns Clamped  angle between -rotationLimit and +rotationLimit
    /// </summary>
    /// <returns>Clamped angle.</returns>
    /// <param name="currentAngle">Current angle.</param>
    /// <param name="rotationLimit">Rotation limit.</param>
    public static float ClampRotation(float currentAngle, float rotationLimit)
    {
        if (currentAngle < 0) //keeps negative angles between 0..360
            currentAngle += 360;

        currentAngle = Mathf.Repeat(currentAngle, 360); //keeps positive angles between 0..360

        if (currentAngle >= 180)
            currentAngle = Mathf.Clamp(currentAngle, 360 - rotationLimit, 360);
        else
            currentAngle = Mathf.Clamp(currentAngle, 0, rotationLimit);

        return currentAngle;
    }

}
