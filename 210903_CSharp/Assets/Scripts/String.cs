using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour
{
    //¹®ÀÚ¿­(String)
    public char c = 'a';
    public string s = "Test";

    // Start is called before the first frame update
    void Start()
    {
        s = "A/B/C";
        Debug.Log(s + "Test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
