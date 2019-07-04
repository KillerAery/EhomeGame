using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyDoor : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closeSprite;
    private TextManager textManager;
    private SpriteRenderer spriteRenderer;
    public AudioClip Audio;//获取音效
    
    public bool opening = false;
    
    public new BoxCollider2D collider2D;

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
            if (!opening && Input.GetKeyDown(KeyCode.E))
            {
                opening = true;
                spriteRenderer.sprite = openSprite;
                collider2D.enabled = false;

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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if (opening)
            {
                opening = false;
                spriteRenderer.sprite = closeSprite;
                collider2D.enabled = true;
            }
        }
    }
}
