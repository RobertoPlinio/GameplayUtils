using UnityEngine;

public class RandomDirByAngle
{
    /// <summary>
    /// COPY THE METHOD INTO YOUR LIBRARY!
    /// </summary>

    /// <summary>
    /// Returns a direction rotated by a random angle based on an angle radius and a origin vector.
    /// </summary>
    /// <param name="origin">The direction that will serve as the origin</param>
    /// <param name="angleRadius">The angle range radius, in degrees</param>
    /// <returns></returns>
    public static Vector3 RandomDirByAngle3D(Vector3 origin, float angleRadius) {
        //no need to be bigger than the entire sphere
        angleRadius = Mathf.Clamp(angleRadius, -180, 180);

        float ptAngle = Random.Range(-2 * Mathf.PI, 2 * Mathf.PI);
        float randomAngleRad = Random.Range(-angleRadius, angleRadius) * Mathf.Deg2Rad;

        Vector3 pt = new Vector3(Mathf.Cos(ptAngle), Mathf.Sin(ptAngle)).normalized * Mathf.Sin(randomAngleRad);
        pt += Vector3.forward * Mathf.Cos(randomAngleRad);

        return Quaternion.LookRotation(origin) * pt;
    }
}
