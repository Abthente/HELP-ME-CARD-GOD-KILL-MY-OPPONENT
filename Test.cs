using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] public string aA;
    [SerializeField] public string bB;
    void Start()
    {
        FindReaderToName("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FindReaderToName(string g)
    {
        StreamReader sw = new StreamReader("Doddi.txt");
        List<string> a = new List<string>();
        string b = "";
        while (true)
        {
            b = sw.ReadLine();
            if (b == ("<" + g + ">"))
            {
                b = "";
                while (true)
                {
                    b = sw.ReadLine();
                    if (b != ("</" + g + ">"))
                    {
                        a.Add(b);
                    }
                    else
                        break;
                }
                break;
            }
        }
        foreach (string s in a)
        {
            Debug.Log(s);
        }
        aA = a[0];
        bB = a[1];

    }
}
