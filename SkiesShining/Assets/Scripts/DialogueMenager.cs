using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMenager : MonoBehaviour
{
    public GameObject DialogueObjectBackground;
    public GameObject DialogueObject;
    public GameObject player;
    public AudioSource audioSource;
    private Text Text;

    private string dialogueValueToSet;
    private bool kontynuowacDialog;
    private GameObject tempGO;
    private bool czyDialog;

    // Start is called before the first frame update
    void Start()
    {
        Text = DialogueObject.GetComponent<Text>();
    }

    public void Dialogue(int line)
    {
        if (player.GetComponent<CharController>().enabled == true || kontynuowacDialog)
        {
            DialogueLine dialogueLine = DialogueSingleton.getLine(line);
            Text.text = dialogueLine.Dialog;
            audioSource.clip = Resources.Load<AudioClip>("Audio/" + dialogueLine.Nagranie);
            audioSource.Play();
            DialogueObjectBackground.SetActive(true);
            DialogueObject.SetActive(true);
            //looking at dialogue item
            tempGO = GameObject.Find(dialogueLine.Przedmiot);
            Vector3 newPosition = tempGO.transform.position;
            newPosition.y += 1.7f;
            newPosition.x += tempGO.transform.forward.x + 1.5f;
            newPosition.z += tempGO.transform.forward.z + 1f;
            Camera.main.transform.position = newPosition;
            Camera.main.transform.LookAt(tempGO.transform);
            dialogueValueToSet = dialogueLine.ZmianaWartosci;
            kontynuowacDialog = dialogueLine.Kontynuowac;
            if (!dialogueLine.AktywowacInne.Equals("*"))
            {
                WplynNaInne(Int16.Parse(dialogueLine.AktywowacInne));
            }
            if(dialogueLine.DialogCzyTekst)
            {
                DialogueObjectBackground.GetComponent<DecisionsHudHandler>().CreateOptions(Int16.Parse(dialogueLine.IndeksWyboru));
                czyDialog = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                czyDialog = false;
            }

            //to make sure that character will not play moving animation
            player.GetComponent<Animator>().SetBool("Moving", false);
        }
    }

    public void WplynNaInne(int index)
    {
        ActivateItem temp = ActiveItemsSingleton.getLine(index);
        GameObject tempGmOb = GameObject.Find(temp.PrzedmiotID);
        if (temp.AktywujLubDeaktywuj)
        {
            if (tempGmOb.transform.position.y < -50)
            {
                if (tempGmOb.GetComponent<Rigidbody>())
                {
                    tempGmOb.GetComponent<Rigidbody>().useGravity = true;
                    tempGmOb.transform.position = new Vector3(tempGmOb.transform.position.x, tempGmOb.transform.position.y + 100.2f, tempGmOb.transform.position.z);
                }
                else
                {
                    tempGmOb.transform.position = new Vector3(tempGmOb.transform.position.x, tempGmOb.transform.position.y + 100, tempGmOb.transform.position.z);
                }
            }
        }
        else
        {
            if (tempGmOb.transform.position.y > -50)
            {
                if( tempGmOb.GetComponent<Rigidbody>())
                {
                    tempGmOb.GetComponent<Rigidbody>().useGravity = false;
                    tempGmOb.transform.position = new Vector3(tempGmOb.transform.position.x, tempGmOb.transform.position.y - 100, tempGmOb.transform.position.z);
                }
                else
                {
                    tempGmOb.transform.position = new Vector3(tempGmOb.transform.position.x, tempGmOb.transform.position.y - 100, tempGmOb.transform.position.z);
                }
            }
        }
        if (!temp.ZmienWartoscDialogu.Equals("*"))
        {
            if (tempGmOb.GetComponent<LineContainer>())
            {
                tempGmOb.GetComponent<LineContainer>().Line = Int16.Parse(temp.ZmienWartoscDialogu);
            }
            else
            {
                tempGmOb.GetComponentInChildren<LineContainer>().Line = Int16.Parse(temp.ZmienWartoscDialogu);
            }
        }
        if (temp.KontynuowacAktywacje)
        {
            WplynNaInne(Int16.Parse(temp.KolejkaAktywacjiPrzedmiotow));
        }
    }

    private void Update()
    {
        if (player.GetComponent<CharController>().enabled == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (tempGO != null && !dialogueValueToSet.Equals("*"))
                {
                    tempGO.GetComponentInChildren<LineContainer>().Line = Int16.Parse(dialogueValueToSet);
                }
                if (kontynuowacDialog)
                {
                    Dialogue(Int16.Parse(dialogueValueToSet));
                }
                else
                {
                    if(!czyDialog)
                    {
                        StartCoroutine("ReturnFunctionality");
                    }
                }
            }
        }
    }

    IEnumerator ReturnFunctionality()
    {
        yield return new WaitForSeconds(.1f);
        audioSource.Stop();
        DialogueObjectBackground.SetActive(false);
        DialogueObject.SetActive(false);
        player.GetComponent<CharController>().UnlockGameplay();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}