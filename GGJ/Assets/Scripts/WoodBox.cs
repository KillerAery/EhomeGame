using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WoodBox : MonoBehaviour
{
    public GameObject tex;
    public GameObject ima;
    public GameObject inp;
    public Text text;
    public Image image;
    public InputField inputField;
    public string password="0606";
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void toOpen(string str)
    {

        tex.SetActive(true);
        ima.SetActive(true);
        inp.SetActive(true);
        text.text = "你发现了一个木箱";
        if (str==password)
        {
            Debug.Log("right");
            
        }
        
    }
}
