using System.Collections;
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// Translate the ColorTarget enums to Renderable colors in Unity
    /// </summary>
    public static class ColorTranslator
    {
        private static Hashtable _colorsTable = new Hashtable()
        {
            { ColorTarget.NONE,      Color.black},
            { ColorTarget.RED,       Color.red},
            { ColorTarget.GREEN,     Color.green},
            { ColorTarget.BLUE,      Color.blue},
            { ColorTarget.YELLOW,    Color.yellow},
            { ColorTarget.ORANGE,    new Color(1.0f,0.498f,0.314f)}, // Domain [0,1]
            { ColorTarget.PURPLE,    new Color(0.6f,0.196f,0.8f)},
        };

        public static Color GetColorFromTarget(ColorTarget colorTarget)
        {
            return (Color)_colorsTable[colorTarget];
        }

    }

}