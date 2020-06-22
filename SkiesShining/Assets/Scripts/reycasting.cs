using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reycasting : MonoBehaviour
{
    private Renderer selectionRenderer;
    public Material highlightMaterial;
    private Material defaultMaterial;
    private float maxDistance = 3.5f;
    public GameObject player;
    public DialogueMenager dialogueMenager;
    private bool isPlaying = false;
    private bool isHighlighting = false;
    public GameObject guitarMiniGame;
    private Ray ray;

    void Update()
    {
        if (selectionRenderer != null)
        {
            selectionRenderer.material = defaultMaterial;
            selectionRenderer = null;
        }

        if (Camera.main)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.transform.CompareTag("Selectable"))
            {
                if (hit.collider.GetComponent<Renderer>())
                {
                    selectionRenderer = hit.collider.GetComponent<Renderer>();
                    defaultMaterial = selectionRenderer.material;
                }
                else
                {
                    selectionRenderer = hit.collider.GetComponentInChildren<Renderer>();
                    defaultMaterial = selectionRenderer.material;
                }
                if (selectionRenderer != null)
                {
                    if (selectionRenderer.material != highlightMaterial && !selectionRenderer.gameObject.name.Equals("ID0"))
                    {
                        selectionRenderer.material = highlightMaterial;
                    }
                }
            }
            if (hit.transform.CompareTag("MiniGame"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (isPlaying == false)
                    {
                        Debug.Log("IN");
                        isPlaying = true;
                        guitarMiniGame.GetComponent<GuitarPlayingMiniGame>().startMiniGame();
                    }
                }
            }
        }
        if (Input.GetButtonDown("Fire2") || guitarMiniGame.GetComponent<GuitarPlayingMiniGame>().GameState == GameState.end)
        {
            if (isPlaying == true)
            {
                Debug.Log("out");
                isPlaying = false;
                guitarMiniGame.GetComponent<GuitarPlayingMiniGame>().endMiniGame();
            }
        }

        if (selectionRenderer != null && isPlaying == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                dialogueMenager.Dialogue(selectionRenderer.GetComponent<LineContainer>().Line);
                player.GetComponent<CharController>().LockGameplay();
            }
        }
        if(Input.GetButtonDown("Use") && !isHighlighting)
        {
            RaycastHit[] hitCollection = Physics.SphereCastAll(player.transform.position, 4f, transform.forward, 0f);
            if (hitCollection.Length > 0)
            {
                isHighlighting = true;
                foreach (RaycastHit rch in hitCollection)
                {
                    if (rch.transform.gameObject.CompareTag("Selectable")){
                        StartCoroutine("HighlightSelectable", rch.transform.gameObject);
                    }
                }
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(player.transform.position, player.transform.position + transform.forward);
        Gizmos.DrawWireSphere(player.transform.position + transform.forward*0, 4f);
    }

    IEnumerator HighlightSelectable(GameObject gameObject)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>() ? gameObject.GetComponent<Renderer>() : gameObject.GetComponentInChildren<Renderer>();
        Material defaultMaterialOfHighlighted = renderer.material;
        if(renderer.material != highlightMaterial)
        {
            renderer.material = highlightMaterial;
            yield return new WaitForSeconds(.6f);
            renderer.material = defaultMaterialOfHighlighted;
            isHighlighting = false;
        }
    }
}