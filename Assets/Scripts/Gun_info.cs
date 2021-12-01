using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_info : MonoBehaviour
{
    int Damage;
    float shot_Delay;
    float coolTime;
    int ammo;
    int now_Ammo;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void gun_info_chage(int gun_num)
    {
        if (gun_num == 0)
        {
            Damage = 5;
            shot_Delay = 0.13f;
            coolTime = 0f;
            ammo = -1;
            now_Ammo = ammo;
        }
        else if (gun_num == 1)
        {
            Damage = 25;
            shot_Delay = 1.0f;
            coolTime = 5f;
            ammo = 5;
            now_Ammo = ammo;
        }
        else if (gun_num == 2)
        {
            Damage = 100;
            shot_Delay = 2.0f;
            coolTime = 10f;
            ammo = 1;
            now_Ammo = ammo;
        }
    }
    public float get_shot_Delay()
    {
        return shot_Delay;
    }

    public float get_Damage()
    {
        return Damage;
    }
    public float get_coolTime()
    {
        return coolTime;
    }
    public float get_ammo()
    {
        return ammo;
    }
    public float get_now_Ammo()
    {
        return now_Ammo;
    }
    public void shot()
    {
        if (ammo == -1)
            return;
        now_Ammo--;
    }
    public void reload()
    {
        if (ammo == -1)
            return;
        now_Ammo = ammo;
    }

}
