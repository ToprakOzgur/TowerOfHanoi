using UnityEngine;

//I try to avoid using "static" keyword  in projects. Because it can be hard to manage dependencies when project is getting bigger.
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

    //from:  https://github.com/acron0/Easings

    public static float BounceEaseOut(float p)
    {
        if (p < 4 / 11.0f)
        {
            return (121 * p * p) / 16.0f;
        }
        else if (p < 8 / 11.0f)
        {
            return (363 / 40.0f * p * p) - (99 / 10.0f * p) + 17 / 5.0f;
        }
        else if (p < 9 / 10.0f)
        {
            return (4356 / 361.0f * p * p) - (35442 / 1805.0f * p) + 16061 / 1805.0f;
        }
        else
        {
            return (54 / 5.0f * p * p) - (513 / 25.0f * p) + 268 / 25.0f;
        }
    }
}
