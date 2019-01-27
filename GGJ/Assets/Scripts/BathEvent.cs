using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            if (player.handlingUmbrella)
            {
                
            }
            else
            {
                player.RecivedDamage(1.0f);
            }
        }
        else if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Die();
        }
    }
}
