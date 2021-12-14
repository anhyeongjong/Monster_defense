using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(90, 0,0);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * GameManager.instance.Bullet_speed*Time.deltaTime);
    }
}
