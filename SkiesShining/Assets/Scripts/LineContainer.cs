using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class LineContainer : MonoBehaviour
{
    public int line;

    public int Line
    {
        get => line;
        set
        {
            if(value.GetType() == line.GetType())
            {
                line = value;
            }
        }
    }
}