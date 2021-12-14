using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun_change : MonoBehaviour
{
  

    int gun_Num = 0;

    public GameObject[] gun;

    void Start()
    {
        //gun_Obj = GameObject.Find("Controller (right)").transform.Find("Model").GetComponent<MeshFilter>();
        //gun_Obj.mesh = gun[0].mesh;
    }

    public void change_Gun()
    {
        gun_Num++;
        if (gun.Length <= gun_Num)
        {
            gun_Num = 0;
        }
       // gun_Obj.mesh = gun[gun_Num].mesh;
        GameManager.instance.Gi.gun_info_chage(gun_Num);

    }
    void Update()
    {

    }
    public int get_now_gunNum()
    {
        return gun_Num;
    }
}
