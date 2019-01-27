using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject tip;
    private TextManager textManager;
    public GameObject ending;
    public AudioSource source;

    //Start is called before the first frame update
    void Start()
    {
        textManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tip.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                var player = collision.gameObject.GetComponent<Player>();
                if (player.gatekey == true)
                {
                    textManager.ShowText("我成功逃离了吗..");
                    StartCoroutine(EndGame());
                }
                else
                {
                    textManager.ShowText("大门锁上了，我开不了。");
                }
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        tip.SetActive(false);
    }

    IEnumerator EndGame()
    {
        for (float timer = 2.0f; timer >= 0; timer -= Time.deltaTime)
            yield return 0;
        Application.Quit();
    }

}
