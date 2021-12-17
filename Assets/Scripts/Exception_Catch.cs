using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exception_Catch : MonoBehaviour
{
    public GameObject SpwanPoint;
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
        if(other.GetComponent<zombie_Move>()!=null)
        {
            other.GetComponent<zombie_Move>().enabled_Nav();
            other.transform.position = new Vector3(-14f, 13f, -63f);
            other.GetComponent<zombie_Move>().enabled_Nav();
        }
    }
}


