using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Save"))
        {
            Save(this);
        }
    }

    private void Start()
    {
        if (LoadGameStatic.LoadGame)
        {
            Load();
        }
    }

    private void Save(SaveGame saveGame)
    {
        Transform[] childrens = saveGame.GetComponentsInChildren<Transform>();

        var saveData = new SaveData();
        saveData.CreateList(childrens);

        string json = JsonUtility.ToJson(saveData);

        string filename = Path.Combine(Application.persistentDataPath, "SaveGame.json");

        if (File.Exists(filename))
        {
            File.Delete(filename);
        }

        File.WriteAllText(filename, json);

        Debug.Log("Player saved to " + filename);
    }

    public void Load()
    {
        string filename = Path.Combine(Application.persistentDataPath, "SaveGame.json");
        string jsonFromFile = File.ReadAllText(filename);

        var saveData = JsonUtility.FromJson<SaveData>(jsonFromFile);

        saveData.LoadList(this);


        Debug.Log("PLAYER LOADED FROM " + filename);
    }
}