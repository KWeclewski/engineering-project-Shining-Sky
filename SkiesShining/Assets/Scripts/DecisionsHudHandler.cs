using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionsHudHandler : MonoBehaviour
{
    public GameObject[] przyciski = new GameObject[2];
    private int[] activateDeactivateItemsIndex = new int[2];
    public GameObject mainCharacter;
    public GameObject dialogueMenager;

    public void CreateOptions(int decisionIndex, int optionIndex = 0)
    {
        Decision decision = DecisionSingleton.getLine(decisionIndex);
        if (!decision.WymogiWsparcia.Equals("*"))
        {
            if(mainCharacter.GetComponent<CharController>().Aprobate >= Int16.Parse(decision.WymogiWsparcia))
            {
                przyciski[optionIndex].gameObject.SetActive(true);
                przyciski[optionIndex].GetComponentInChildren<Text>().text = decision.TekstDecyzji;
                activateDeactivateItemsIndex[optionIndex] = (decision.IndeksWplywuNaInne.Equals("*")? -1: Int16.Parse(decision.IndeksWplywuNaInne));
                if (!decision.NastepnaDecyzja.Equals("*"))
                {
                    CreateOptions(Int16.Parse(decision.NastepnaDecyzja), 1);
                }
            }
            else if (!decision.NastepnaDecyzja.Equals("*"))
            {
                CreateOptions(Int16.Parse(decision.NastepnaDecyzja));
            }
        }
        else
        {
            przyciski[optionIndex].gameObject.SetActive(true);
            przyciski[optionIndex].GetComponentInChildren<Text>().text = decision.TekstDecyzji;
            activateDeactivateItemsIndex[optionIndex] = (decision.IndeksWplywuNaInne.Equals("*") ? -1 : Int16.Parse(decision.IndeksWplywuNaInne));
            if (!decision.NastepnaDecyzja.Equals("*"))
            {
                CreateOptions(Int16.Parse(decision.NastepnaDecyzja), 1);
            }
        }
    }
    public void buttonClicked(int i)
    {
        if(activateDeactivateItemsIndex[i] != -1)
        {
            dialogueMenager.GetComponent<DialogueMenager>().WplynNaInne(activateDeactivateItemsIndex[i]);
        }
        przyciski[0].SetActive(false);
        przyciski[1].SetActive(false);

        dialogueMenager.GetComponent<DialogueMenager>().StartCoroutine("ReturnFunctionality");
    }
}