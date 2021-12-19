using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Gun_info : MonoBehaviour
{
    public SteamVR_Action_Vibration hapticAction;

    public AudioClip rifleClip, shotgunClip;

    public AudioSource GunSource;

    int Damage = 50;
    float shot_Delay = 0.2f;
    float coolTime = 0f;
    int ammo= 1;
    int now_Ammo = 1;
    int now_Gun =0;

   
    public float duration;
    [Range(0, 320f)]
    public float frequency;
    [Range(0,1.0f)]
    public float amplitude;
    // Start is called before the first frame update
    void Start()
    {
        //GunSource = GameObject.Find("[CameraRig]").transform.Find("Controller (right)").transform.Find("Model").GetComponent<AudioSource>();
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
            Damage = 50;
            shot_Delay = 0.2f;
            coolTime = 0f;
            ammo = 1;
            now_Ammo = ammo;
            GameManager.instance.Bullet_speed = 60f;
        }
        else if (gun_num == 1)
        {
            now_Gun = 1;
            Damage = 30;
            shot_Delay = 1.0f;
            coolTime = 5f;
            ammo = 5;
            now_Ammo = ammo;
            if(!GameManager.instance.Pc.is_shotgun_Ready)
            {
                now_Ammo = 0;
            }
            GameManager.instance.Bullet_speed = 50f;
        }
        else if (gun_num == 2)
        {
            now_Gun = 2;
            Damage = 10000;
            shot_Delay = 2.0f;
            coolTime = 20f;
            ammo = 1;
            now_Ammo = ammo;
            if (!GameManager.instance.Pc.is_sniper_Ready)
            {
                now_Ammo = 0;
            }
            GameManager.instance.Bullet_speed = 70f;
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
        //shotHaptic(duration, frequency, amplitude, SteamVR_Input_Sources.RightHand);
        if (now_Gun == 1 )
        {
            shotHaptic(0.2f, 320f, 1f, SteamVR_Input_Sources.RightHand);
            GunSource.PlayOneShot(shotgunClip);
            for (int i = 1; i <= 40; i++)
            {
               Quaternion target = Quaternion.Euler(new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(-5.5f,5.5f), 0f));
               GameObject temp = Instantiate(GameManager.instance.default_Bullet_prefab, GameManager.instance.FirePos.position, GameManager.instance.FirePos.rotation * target);
               temp.name = "shotGunBullet";
            }
        }
        if (now_Gun == 2)
        {
            shotHaptic(0.6f, 320f, 1f, SteamVR_Input_Sources.RightHand);
            GameObject temp = Instantiate(GameManager.instance.RPG_Bullet_prefab, GameManager.instance.FirePos.position, GameManager.instance.FirePos.rotation);
            temp.transform.localScale = new Vector3(3f, 3f, 3f);
            temp.name = "sniperBullet";
        }
        else
        {
            GunSource.PlayOneShot(rifleClip);
            shotHaptic(0.1f, 100f, 1f, SteamVR_Input_Sources.RightHand);
            GameObject temp = Instantiate(GameManager.instance.default_Bullet_prefab, GameManager.instance.FirePos.position, GameManager.instance.FirePos.rotation);
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

    private void shotHaptic(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
    }

}
