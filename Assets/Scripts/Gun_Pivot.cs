using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pivot : MonoBehaviour
{
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
         controller = GameObject.Find("Controller (right)").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().transform.position = controller.transform.position;
        if (gameObject.name == "ShotGun" || gameObject.name == "RPG")
        {
            this.GetComponent<Transform>().transform.rotation = controller.transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            this.GetComponent<Transform>().transform.rotation = controller.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 0));
        }

    }
}
