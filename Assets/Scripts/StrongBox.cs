using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrongBox : MonoBehaviour
{
    public string password = "2333";
    public GameObject inp;
    public InputField inputField;
    public Player player;
    private TextManager textManager;
    public GameObject tip;
    public bool empty = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tip.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                if (empty)
                {
                    textManager.ShowText("这什么都没有。");
                }
                else
                {
                    inp.SetActive(true);
                }
            }
            tip.SetActive(false);
            inp.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tip.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                if (empty)
                {
                    textManager.ShowText("这什么都没有。");
                }
                else
                {
                    inp.SetActive(true);
                }
            }
            tip.SetActive(false);
            inp.SetActive(false);
        }
    }

    public void toOpen()
    { //
        if (inputField.text == password)
        {
            textManager.ShowText("一把钥匙");
            player.gatekey = true;
        }
    }
}
