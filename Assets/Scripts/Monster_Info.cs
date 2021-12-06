using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Info : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            if(other.name =="sniperBullet")
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
 

        }
    }
}
