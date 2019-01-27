using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject tip;
    private TextManager textManager;

    //Start is called before the first frame update
    void Start()
    {
        textManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
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
                textManager.ShowText("纸条上写着...对不起，我们还没想好谜题，先给你密码吧：2333");
                tip.SetActive(false);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        tip.SetActive(false);
    }

}
