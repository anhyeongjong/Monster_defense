using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_info_Pivot : MonoBehaviour
{
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Controller (left)").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().transform.position = controller.transform.position + new Vector3(0,0.08f,0);
        this.GetComponent<RectTransform>().transform.rotation = controller.transform.rotation * Quaternion.Euler(new Vector3(80f,0, 0));
    }
}
