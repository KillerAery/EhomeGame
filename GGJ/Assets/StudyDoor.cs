using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyDoor : MonoBehaviour
{
    public GameObject tip;
    public Sprite openSprite;
    private TextManager textManager;
    private SpriteRenderer spriteRenderer;
    public AudioClip Audio;//获取音效
    //Start is called before the first frame update
    void Start()
    {
        textManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
                if (player.studykey == true)
                {
                    AudioSource.PlayClipAtPoint(Audio, transform.position);
                    textManager.ShowText("看来很顺利开了书房的锁。");
                    spriteRenderer.sprite = openSprite;
                }
                else
                {
                    textManager.ShowText("书房门锁上了，我开不了。");
                }
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        tip.SetActive(false);
    }
}
