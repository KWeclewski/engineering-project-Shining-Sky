using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DecisionSingleton : MonoBehaviour
{
    public static DecisionSingleton Items { get; private set; }
    private List<Decision> list = new List<Decision>();
    // Start is called before the first frame update
    void Start()
    {
        if (Items == null)
        {
            Items = this;
            try
            {   // Open the text file using a stream reader.
                StreamReader sr = new StreamReader("./Assets/Chooses.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitedLine = line.Split('\t');

                    if (!splitedLine[0].Equals("TekstDecyzji"))
                    {
                        list.Add(new Decision(splitedLine[0], splitedLine[1], splitedLine[2], splitedLine[3]));
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

    public static Decision getLine(int index)
    {
        return Items.list[index];
    }
}