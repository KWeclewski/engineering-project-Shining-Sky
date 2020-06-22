using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveFound : MonoBehaviour
{
    public GameObject stateManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("mainCharacter"))
        {
            stateManager.GetComponent<GameStateManager>().FoundCave = true;
        }
    }
}