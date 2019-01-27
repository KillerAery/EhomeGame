using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closeSprite;
    public bool opening = false;
    public AudioClip Audio;//获取音效

    private SpriteRenderer spriteRenderer;
    public new BoxCollider2D collider2D;

    //Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if (!opening)
            {
                opening = true;
                AudioSource.PlayClipAtPoint(Audio, transform.position);
                spriteRenderer.sprite = openSprite;
                collider2D.enabled = false;
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
