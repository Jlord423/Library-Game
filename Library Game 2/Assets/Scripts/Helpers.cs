using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{


    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

    // changes input by 45 degrees to fix isometric movement 
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);

    // Generate random normalized direction (codemonkeys tutorial)
    public static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
