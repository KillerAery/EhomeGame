using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbralla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().handlingUmbrella = true;

            Destroy(gameObject);
        }
    }
}
