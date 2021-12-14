using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float X;
    public float Y;
    private GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = GameObject.Find("Controller (left)").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().transform.position = temp.transform.position + new Vector3(X,0.08f,Y);
        this.GetComponent<RectTransform>().transform.rotation = temp.transform.rotation * Quaternion.Euler(new Vector3(80f,0, 0));
    }
}
