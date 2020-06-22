using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAtBegining : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        IEnumerator coroutine = DeactivateAfterSeconds(12);
        StartCoroutine(coroutine);
    }

    IEnumerator DeactivateAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.gameObject.SetActive(false);
    }
}