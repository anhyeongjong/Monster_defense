using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public float X;
    public float Y;
    public float Z;
    private GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = GameObject.Find("Controller (right)").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().transform.position = temp.transform.position + new Vector3(X, Y, Z);
        this.GetComponent<Transform>().transform.rotation = temp.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
