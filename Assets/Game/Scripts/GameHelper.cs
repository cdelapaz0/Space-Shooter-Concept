using UnityEngine;
using System;
using System.Collections;

[Flags]
public enum BoundsExitFlag
{
    None = 0,
    Left = 1,
    Top = 2,
    Right = 4,
    Bottom = 8
}

public static class GameHelper {

    public static BoundsExitFlag CheckOutOfBounds(Vector3 position)
    {
        Rect r = Camera.main.worldSpaceRect();

        BoundsExitFlag exitFlags = BoundsExitFlag.None;

        if (position.x > (r.xMax + 1.0)) {
            exitFlags |= BoundsExitFlag.Right;
        }
        else if (position.x < (r.xMin - 1.0)) {
            exitFlags |= BoundsExitFlag.Left;
        }

        if (position.y > (r.yMax + 1.0)) {
            exitFlags |= BoundsExitFlag.Top;
        }
        else if (position.y < (r.yMin - 1.0)) {
            exitFlags |= BoundsExitFlag.Bottom;
        }

        return exitFlags;
    }

    public static BoundsExitFlag CheckOutOfBounds(Bounds bounds)
    {
        Rect r = Camera.main.worldSpaceRect();

        BoundsExitFlag exitFlags = BoundsExitFlag.None;

        if (bounds.max.x > (r.xMax + bounds.size.x))
        {
            exitFlags |= BoundsExitFlag.Right;
        }
        else if (bounds.min.x < (r.xMin - bounds.size.x))
        {
            exitFlags |= BoundsExitFlag.Left;
        }

        if (bounds.max.y > (r.yMax + bounds.size.y))
        {
            exitFlags |= BoundsExitFlag.Top;
        }
        else if (bounds.min.y < (r.yMin - bounds.size.y))
        {
            exitFlags |= BoundsExitFlag.Bottom;
        }

        return exitFlags;
    }

    public static Vector3 ClampPositionWithinBounds(Vector3 position)
    {
        Vector3 clampPos = new Vector3();
        Rect r = Camera.main.worldSpaceRect();

        clampPos = new Vector3(Mathf.Clamp(position.x, r.xMin, r.xMax),
                               Mathf.Clamp(position.y, r.yMin, r.yMax),
                               position.z);

        return clampPos;
    }

    public static Vector3 ClampPositionWithinBounds(Bounds bounds)
    {
        Vector3 clampPos = bounds.center;
        Rect r = Camera.main.worldSpaceRect();

        if (bounds.max.x > r.xMax)
        {
            clampPos.x -= (bounds.max.x - r.xMax);
        }
        else if (bounds.min.x < r.xMin)
        {
            clampPos.x += (r.xMin - bounds.min.x);
        }

        if (bounds.max.y > r.yMax)
        {
            clampPos.y -= (bounds.max.y - r.yMax);
        }
        else if (bounds.min.y < r.yMin)
        {
            clampPos.y += (r.yMin - bounds.min.y);
        }
        //clampPos = new Vector3(Mathf.Clamp(position.x, r.xMin, r.xMax),
        //                       Mathf.Clamp(position.y, r.yMin, r.yMax),
        //                       position.z);

        return clampPos;
    }
}
