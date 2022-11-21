using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float GetHorizontalDistance(Vector3 from, Vector3 to)
    {
        from.y = 0;
        to.y = 0;
        float dis = Vector3.Distance(from, to);
        return dis;
    }

    public static Vector3 GetLookAtHorizontalPos(Transform my, Transform target)
    {
        Vector3 pos = target.position;
        pos.y = my.position.y;
        return pos;
    }
    
    public static void LookAtHorizontalPos(Transform from, Transform to)
    {
        Vector3 pos = to.position;
        pos.y = from.position.y;
        from.LookAt(pos);
    }
}
