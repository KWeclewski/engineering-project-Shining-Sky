using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueSingleton : MonoBehaviour
{
    public static DialogueSingleton Dialogues { get; private set; }
    private List<DialogueLine> list = new List<DialogueLine>();
    // Start is called before the first frame update
    void Start()
    {
        if (Dialogues == null)
        {
            Dialogues = this;
            try
            {   // Open the text file using a stream reader.
                StreamReader sr = new StreamReader("./Assets/dialogues.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitedLine = line.Split('\t');
                    
                    if (!splitedLine[0].Equals("Dialog"))
                    {
                        list.Add(new DialogueLine(splitedLine[0], splitedLine[1], splitedLine[2], splitedLine[3], splitedLine[4], splitedLine[5], splitedLine[6], splitedLine[7]));
                    }
                }
            }
            catch (IOException e)
            {
                Debug.Log(e.Message);
                Debug.Log("pliku nie znaleziono");
            }
        }
        else
        {
            Debug.Log("else");
        }
    }

    public static DialogueLine getLine(int index)
    {
        return Dialogues.list[index];
    }
}