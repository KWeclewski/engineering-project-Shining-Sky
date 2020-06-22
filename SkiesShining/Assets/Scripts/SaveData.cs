using System;
using System.Collections.Generic;
using UnityEngine;


public class SaveData
{
    public List<Data> savedata = new List<Data>();

    public void CreateList(Transform[] childrens)
    {
        foreach (Transform tran in childrens)
        {
            if (tran.gameObject.name.Equals("mainCharacter"))
            {
                savedata.Add(new Data()
                {
                    name = tran.gameObject.name,
                    lineNumber = -1,

                    position = tran.position,
                    rotation = tran.rotation
                });
            }
            if (tran.gameObject.name.StartsWith("ID"))
            {
                if (tran.gameObject.GetComponent<LineContainer>() != null)
                {
                    savedata.Add(new Data()
                    {
                        name = tran.gameObject.name,
                        lineNumber = tran.gameObject.GetComponent<LineContainer>().Line,

                        position = tran.position,
                        rotation = tran.rotation
                    });
                }
                else if (tran.gameObject.GetComponentInChildren<LineContainer>() != null)
                {
                    savedata.Add(new Data()
                    {
                        name = tran.gameObject.name,
                        lineNumber = tran.gameObject.GetComponentInChildren<LineContainer>().Line,

                        position = tran.position,
                        rotation = tran.rotation
                    });
                }
                else
                {
                    savedata.Add(new Data()
                    {
                        name = tran.gameObject.name,
                        lineNumber = -1,

                        position = tran.position,
                        rotation = tran.rotation
                    });
                }
            }
        }
    }

    public void LoadList(SaveGame interactableParent)
    {
        foreach (Data data in savedata)
        {
            var go = GameObject.Find(data.name);
            go.transform.position = data.position;
            go.transform.rotation = data.rotation;
            if (data.lineNumber != -1)
            {
                if (go.GetComponent<LineContainer>() != null)
                {
                    go.GetComponent<LineContainer>().Line = data.lineNumber;
                }
                else if (go.GetComponentInChildren<LineContainer>() != null)
                {
                    go.GetComponentInChildren<LineContainer>().Line = data.lineNumber;
                }
            }
        }
    }
}