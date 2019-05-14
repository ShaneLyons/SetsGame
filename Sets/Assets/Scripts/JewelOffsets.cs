using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelOffsets
{
    public static Dictionary<string, float> GetOffsets(int setSize)
    {
        float xOffset, yOffset, xDiff, yDiff, scaleFactor;
        xOffset = yOffset = scaleFactor = xDiff = yDiff = 0;
        switch (setSize)
        {
            case 1:
                yOffset = .15f;
                scaleFactor = .6f;
                break;
            case 2:
                xOffset = .11f;
                xDiff = .225f;
                yOffset = .15f;
                scaleFactor = .5f;
                break;
            case 3:
                xOffset = .125f;
                xDiff = .125f;
                yOffset = .15f;
                yDiff = .1f;
                scaleFactor = .45f;
                break;
            case 4:
                xOffset = .145f;
                xDiff = .09f;
                yOffset = .15f;
                yDiff = .08f;
                scaleFactor = .35f;
                break;
            case 5:
                xOffset = .145f;
                xDiff = .07f;
                yOffset = .14f;
                yDiff = .1f;
                scaleFactor = .35f;
                break;
        }
        return new Dictionary<string, float>()
        {
            { "xOffset", xOffset },
            { "yOffset", yOffset },
            { "xDiff", xDiff },
            { "yDiff", yDiff },
            { "scaleFactor", scaleFactor }
        };
    }
}
