using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSolution
{
    // determine the firing angle to hit a given location with a given muzzle velocity
    public Nullable<Vector3> Calculate(Vector3 start, Vector3 end, float muzzleV, Vector3 gravity)
    {
        Nullable<float> TargetTime = GetTimeToTarget(start, end, muzzleV, gravity);
        if (!TargetTime.HasValue)
        {
            return null;
        }

        // return the firing vector
        Vector3 delta = end - start;

        Vector3 n1 = delta * 2;
        Vector3 n2 = gravity * (TargetTime.Value * TargetTime.Value);
        float d = 2 * muzzleV * TargetTime.Value;
        Vector3 solution = (n1 - n2) / d;

        return solution;
    }

    // determine the shortest time it will take a projectile to get to a target
    public Nullable<float> GetTimeToTarget(Vector3 start, Vector3 end, float muzzleV, Vector3 gravity)
	{
        Vector3 delta = start - end;

		// Caclulate the real-valued a,b,c coefficents of a conventional quadratic equation
		float a = gravity.magnitude * gravity.magnitude;
		float b = -4 * (Vector3.Dot(gravity, delta) + muzzleV * muzzleV);
		float c = 4 * delta.magnitude * delta.magnitude;

		// check for no real solution
		float b2minus4ac  = (b * b) - (4 * a * c);
		if (b2minus4ac < 0)
		{
			return null;
		}

		// find the candidate times
		float time0 = Mathf.Sqrt((-b + Mathf.Sqrt(b2minus4ac)) / (2 * a));
		float time1 = Mathf.Sqrt((-b - Mathf.Sqrt(b2minus4ac)) / (2 * a));

		// find the time to target
		Nullable<float> TargetTime;
		if (time0 < 0)
		{
			if (time1 < 0)
			{
				// we have no valid times
				return null;
			}
			else
			{
				TargetTime = time1;
			}
		}
		else if (time1 < 0)
		{
			TargetTime = time0;
		}
		else
		{
            TargetTime = Mathf.Min(time0, time1);
        }

        return TargetTime;
	}
}