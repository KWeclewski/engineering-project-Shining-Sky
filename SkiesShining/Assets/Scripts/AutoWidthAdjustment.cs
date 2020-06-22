using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWidthAdjustment : MonoBehaviour
{
    private Resolution res;
    private RectTransform[] tabRects;

    // Use this for initialization
    void Start()
    {
        res = Screen.currentResolution;
        tabRects = this.GetComponentsInChildren<RectTransform>();
        
        //do usuniecia rect wlasciciela czyli 'this.recttransform'
        foreach (RectTransform rectChild in tabRects)
        {
            Debug.Log(rectChild.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!res.Equals(Screen.currentResolution))
        {
            res = Screen.currentResolution;
            //foreach(RectTransform rectChild in tabRects)
            //{
            //    rectChild.sizeDelta = new Vector2(-100, -100);
            //}
        }
    }
}