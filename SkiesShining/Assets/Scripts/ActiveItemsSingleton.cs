using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ActiveItemsSingleton : MonoBehaviour
{
    public static ActiveItemsSingleton Items { get; private set; }
    private List<ActivateItem> list = new List<ActivateItem>();
    // Start is called before the first frame update
    void Start()
    {
        if (Items == null)
        {
            Items = this;
            try
            {   // Open the text file using a stream reader.
                StreamReader sr = new StreamReader("./Assets/ActiveDeactiveItems.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitedLine = line.Split('\t');

                    if (!splitedLine[0].Equals("PrzedmiotID"))
                    {
                        list.Add(new ActivateItem(splitedLine[0], splitedLine[1], splitedLine[2], splitedLine[3], splitedLine[4]));
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

    public static ActivateItem getLine(int index)
    {
        return Items.list[index];
    }
}