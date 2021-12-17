using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun_change : MonoBehaviour
{
  

    int gun_Num = 0;
    GameObject gun_Obj;
    public GameObject[] gun;

    void Start()
    {
        gun[0].SetActive(true);
        gun_Obj = gun[0];


    }

    public void change_Gun()
    {
        gun_Num++;
        if (gun.Length <= gun_Num)
        {
            gun_Num = 0;
        }
        gun_Obj.SetActive(false);
        gun[gun_Num].SetActive(true);
        gun_Obj = gun[gun_Num];
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
