using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Player_controller : MonoBehaviour
{
    // 핸드 타입
    private SteamVR_Input_Sources right_Hand;
    private SteamVR_Input_Sources left_Hand;


    // 컨트롤러 버튼 타입
    public SteamVR_Action_Boolean function_Key;

    [HideInInspector]
    private bool is_shot_Ready = true;
    [HideInInspector]
    public bool is_shotgun_Ready = true;
    [HideInInspector]
    public bool is_sniper_Ready = true;
    private bool is_nowgun_Read;

    public Coroutine shotgun,sniper;
    void Start()
    {
        right_Hand = SteamVR_Input_Sources.RightHand;
        left_Hand = SteamVR_Input_Sources.LeftHand;
        shotgun = StartCoroutine(Demo());
        sniper  = StartCoroutine(Demo());

    }

    void Update()
    {
        // right_function 클릭 시 
        if (function_Key.GetState(right_Hand) && is_shot_Ready == true && is_nowgun_Read == true)
        {
            // 총 발사
            StartCoroutine(shotDelay());
            GameManager.instance.Gi.shot();
            if (GameManager.instance.Gi.get_now_Ammo() == 0)
            {
                if (GameManager.instance.Gc.get_now_gunNum() == 1)
                {
                    StopCoroutine(shotgun);
                    shotgun = StartCoroutine(shotgun_coolTime());
                }
                else if (GameManager.instance.Gc.get_now_gunNum() == 2)
                {
                    StopCoroutine(sniper);
                    sniper = StartCoroutine(sniper_coolTime());
                }
            }
        }
        if (GameManager.instance.Gc.get_now_gunNum() == 1)
        {
            is_nowgun_Read = is_shotgun_Ready;
        }
        else if (GameManager.instance.Gc.get_now_gunNum() == 2)
        {
            is_nowgun_Read = is_sniper_Ready;
        }
        else if (GameManager.instance.Gc.get_now_gunNum() == 0)
        {
            is_nowgun_Read = true;
        }
        // left_function 클릭 시 
        if (function_Key.GetLastStateDown(left_Hand))
        {
            if (GameManager.instance.Gc.get_now_gunNum() == 1)
            {
                StopCoroutine(shotgun);
                shotgun = StartCoroutine(shotgun_coolTime());
            }
            else if (GameManager.instance.Gc.get_now_gunNum() == 2)
            {
                StopCoroutine(sniper);
                sniper = StartCoroutine(sniper_coolTime());
            }
            // 총(스킬) 체인지
            GameManager.instance.Gc.change_Gun();
            //Debug.Log("change");
        }
    }

    IEnumerator shotDelay()
    {
        is_shot_Ready = false;
        yield return new WaitForSecondsRealtime(GameManager.instance.Gi.get_shot_Delay());
        is_shot_Ready = true;
    }

    IEnumerator shotgun_coolTime()
    {
        //Debug.Log("샷건 쿨타임 시작");
        is_shotgun_Ready = false;
        yield return new WaitForSecondsRealtime(GameManager.instance.Gi.get_coolTime());

        if(GameManager.instance.Gc.get_now_gunNum() ==1)
        GameManager.instance.Gi.reload();
        //Debug.Log("샷건 쿨타임 끝");
        is_shotgun_Ready = true;
    }
    IEnumerator sniper_coolTime()
    {
        //Debug.Log("스나이퍼 쿨타임 시작");
        is_sniper_Ready = false;
        yield return new WaitForSecondsRealtime(GameManager.instance.Gi.get_coolTime());
        if (GameManager.instance.Gc.get_now_gunNum() == 2)
            GameManager.instance.Gi.reload();
        //Debug.Log("스나이퍼 쿨타임 끝");
        is_sniper_Ready = true;
    }
    IEnumerator Demo()
    {
        yield return new WaitForSeconds(100000f);
    }

}
