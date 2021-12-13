using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_info : MonoBehaviour
{
    int Damage = 5;
    float shot_Delay = 0.3f;
    float coolTime = 0f;
    int ammo= 1;
    int now_Ammo = 1;
    int now_Gun =0;

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
            now_Gun = 0;
            Damage = 5;
            shot_Delay = 0.3f;
            coolTime = 0f;
            ammo = 1;
            now_Ammo = ammo;
            //GameManager.instance.Bullet_speed = 
        }
        else if (gun_num == 1)
        {
            now_Gun = 1;
            Damage = 25;
            shot_Delay = 1.0f;
            coolTime = 5f;
            ammo = 5;
            now_Ammo = ammo;
            if(!GameManager.instance.Pc.is_shotgun_Ready)
            {
                now_Ammo = 0;
            }
            //GameManager.instance.Bullet_speed =
        }
        else if (gun_num == 2)
        {
            now_Gun = 2;
            Damage = 100;
            shot_Delay = 2.0f;
            coolTime = 10f;
            ammo = 1;
            now_Ammo = ammo;
            if (!GameManager.instance.Pc.is_sniper_Ready)
            {
                now_Ammo = 0;
            }
            //GameManager.instance.Bullet_speed =
        }
        GameManager.instance.UM.SetAmmoUi();
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
        if(now_Gun == 1 )
        {
            for (int i = 1; i <= 20; i++)
            {
               Quaternion target = Quaternion.Euler(new Vector3(0, Random.Range(-45f,45f), 0));
               GameObject temp = Instantiate(GameManager.instance.Bullet_prefab, GameManager.instance.FirePos.position, GameManager.instance.FirePos.rotation * target);
               temp.name = "shotGunBullet";
            }
        }
        if (now_Gun == 2)
        {
            GameObject temp = Instantiate(GameManager.instance.Bullet_prefab, GameManager.instance.FirePos.position, GameManager.instance.FirePos.rotation);
            temp.name = "sniperBullet";
        }
        else
        {
            GameObject temp = Instantiate(GameManager.instance.Bullet_prefab, GameManager.instance.FirePos.position, GameManager.instance.FirePos.rotation);
        }

        if (now_Gun == 0)
        return;


        now_Ammo--;
        GameManager.instance.UM.SetAmmoUi();
    }
    public void reload()
    {
        if (now_Gun ==0)
            return;
        now_Ammo = ammo;
        GameManager.instance.UM.SetAmmoUi();
    }

    public float Get_Gun_Damage()
    {
        return Damage * GameManager.instance.stateUp.Get_Change_damage_Coefficient();
    }

}
