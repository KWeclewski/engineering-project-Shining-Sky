using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum GameState
{
    start,
    input,
    stop,
    end
};

public class GuitarPlayingMiniGame : MonoBehaviour, IMiniGame
{
    public AudioSource audioSource;
    public GameObject player;
    public GameObject gameHud;
    public Image[] images;
    public AudioClip[] sounds;

    public Camera mainCamera;
    public Camera miniGameCamera;
    public GameObject playerGuitar;
    public Text sukces;
    public Text porazka;

    private Transform playerStartTransform;
    private string val = "";
    private string input = "";
    private GameState gameState = GameState.stop;
    private float time = 8f;
    private List<AudioClip> playlist = new List<AudioClip>();

    internal GameState GameState { get => gameState; }

    public void endMiniGame()
    {
        //animation
        playerGuitar.SetActive(false);
        player.GetComponent<Animator>().SetBool("Playing", false);
        playerGuitar.GetComponent<Animator>().SetBool("Playing", true);
        mainCamera.GetComponent<Camera>().enabled = true;
        miniGameCamera.gameObject.SetActive(false);
        player.transform.rotation = playerStartTransform.rotation;

        //logic
        gameHud.SetActive(false);
        gameState = GameState.end;
        player.GetComponent<CharController>().UnlockGameplay();

    }

    public void startMiniGame()
    {
        //animation
        player.GetComponent<Animator>().SetBool("Moving", false);
        playerGuitar.SetActive(true);
        player.GetComponent<Animator>().SetBool("Playing", true);
        playerGuitar.GetComponent<Animator>().SetBool("Playing", true);
        mainCamera.GetComponent<Camera>().enabled = false;
        miniGameCamera.gameObject.SetActive(true);
        playerStartTransform = player.transform;
        player.transform.LookAt(new Vector3(miniGameCamera.transform.position.x, player.transform.position.y, miniGameCamera.transform.position.z));

        //logic
        gameHud.SetActive(true);
        val = "";
        gameState = GameState.start;
        foreach (Image img in images)
        {
            var random = (UnityEngine.Random.Range(1, 100) % 4) + 1;
            val += random;
            img.sprite = Resources.Load<Sprite>("Graphics/" + random);
        }
        
        player.GetComponent<CharController>().LockGameplay();

        input = "";
        StartCoroutine("CheckWin");
        gameState = GameState.input;
    }

    private void Update()
    {
        if (gameState.Equals(GameState.input))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                input += "1";
                playlist.Add(sounds[0]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                input += "2";
                playlist.Add(sounds[1]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                input += "3";
                playlist.Add(sounds[2]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                input += "4";
                playlist.Add(sounds[3]);
            }

            if (input.Length.Equals(6))
            {
                gameState = GameState.stop;
            }
        }
        if (!audioSource.isPlaying)
        {
            if (playlist.Count > 0)
            {
                audioSource.clip = playlist[0];
                playlist.RemoveAt(0);
                audioSource.Play();
            }
        }
    }

    IEnumerator CheckWin()
    {
        if(gameState != GameState.end)
        yield return new WaitForSeconds(time);
        if (input.Equals(val))
        {
            startMiniGame();
            time *= .95f;
            sukces.GetComponent<Animator>().Play("Sukces");
        }
        else
        {
            endMiniGame();
            porazka.GetComponent<Animator>().Play("Porazka");
            
            playlist.RemoveRange(0, playlist.Count);
            audioSource.Stop();
        }
    }
}