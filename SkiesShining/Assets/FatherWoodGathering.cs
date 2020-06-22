using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherWoodGathering : MonoBehaviour
{

    public GameObject fatherObject;
    public GameObject dialogueMenager;
    private LineContainer lc;
    private DialogueMenager dm;

    private void Start()
    {
        lc = fatherObject.GetComponent<LineContainer>();
        dm = dialogueMenager.GetComponent<DialogueMenager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lc.Line == 17)
        {
            IEnumerator coroutine = WoodGathering(23);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator WoodGathering(int activationLine)
    {
        yield return new WaitForSeconds(30);
        dm.WplynNaInne(activationLine);
        yield return new WaitForSeconds(20);
        dm.WplynNaInne(6);
        yield return new WaitForSeconds(16);
        dm.WplynNaInne(9);
        yield return new WaitForSeconds(24);
        dm.WplynNaInne(12);
        yield return new WaitForSeconds(12);
        dm.WplynNaInne(15);
        yield return new WaitForSeconds(12);
        dm.WplynNaInne(24);
    }
}