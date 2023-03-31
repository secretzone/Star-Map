
using System;
using UnityEngine;

public static class Conversions
{
    public static Color ColorFromString(String color)
    {
        switch (color.ToLower())
        {
            case "red": return Color.red;
            case "blue": return Color.blue;
            case "yellow": return Color.yellow;
            case "green": return Color.green;
            case "orange": return new Color(255, 165, 0, 1);
            case "violet": return new Color(238, 130, 238, 1);
            case "cyan": return Color.cyan;
            default: return Color.white;
        }
    }
}
