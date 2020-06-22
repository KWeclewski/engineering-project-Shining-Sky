using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private bool foundCave;

    public bool FoundCave { get => foundCave; set => foundCave = value; }

    // Start is called before the first frame update
    void Start()
    {
        foundCave = false;
    }

}