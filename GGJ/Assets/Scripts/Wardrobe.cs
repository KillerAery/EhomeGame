using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MonoBehaviour
{
    public bool isOpened=false;
    public GameObject enemy;
    
    
    public GameObject ima;
    public GameObject inp;
    
    public Image image;
    public InputField inputField;
    public string password = "0606";
    private TextManager textManager;
    void Start()
    {
        textManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
    }

    
    void Update()
    {
       
    }

    public void Open()
    {
        //Instantiate(enemy, transform.position, Quaternion.identity);
        
        ima.SetActive(true);
        inp.SetActive(true);//"你发现了一个木箱"
        textManager.ShowText("你发现了一个木箱");

        isOpened = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isOpened&&collision.collider.tag=="Player")
        {
            Open();
        }
    }

    public void toOpen(string str)
    {
        //
        if (str == password)
        {
            
            textManager.ShowText("你发现了一条奇怪的围巾");
        }
        
        
    }
}
