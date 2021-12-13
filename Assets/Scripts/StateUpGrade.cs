using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class StateUpGrade : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage_Coefficient;     // 데미지 계수
    public int maxHP;                    // 최대 HP
    public int index_Len;
    public int state_Index = 1;

    public GameObject Hp_Prefab;
    public GameObject Hp_UI;
    public GameObject GameOver;
    public GameObject State_UI;

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean up;
    public SteamVR_Action_Boolean down;
    public SteamVR_Action_Boolean check;

    void Start()
    {
        index_Len = GameObject.Find("Game_Canvas").transform.Find("State").childCount;
        damage_Coefficient = 1;
        maxHP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (up.GetState(handType) && index_Len > state_Index)
        {
            state_Index++;
            Debug.Log(state_Index);
        }
        else if (down.GetState(handType) && state_Index >0)
        {
            state_Index--;
            Debug.Log(state_Index);
        }
        else if (check.GetState(handType))
        {
            if(state_Index == 1)
            {
                Upgrade_GUN();
            }
            else if (state_Index == 2)
            {
                Upgrade_HP();
            }
        }
    }
    public void Upgrade_GUN()
    {
        damage_Coefficient += 0.3f;

        State_UI.SetActive(false);
    }
    public float Get_Change_damage_Coefficient()
    {
        return damage_Coefficient;
    }
    public void Upgrade_HP()
    {
        maxHP += 3;

        defalut_SetHp();
        State_UI.SetActive(false);
    }
    public void  defalut_SetHp()
    {
        for (int i = 0; i <= Hp_UI.transform.childCount - 1; i++)
        {
            Destroy(Hp_UI.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i <= 9 + maxHP; i++)
        {
            Vector3 temp = new Vector3(8f * i, 0, 0);
            GameObject temp1 = Instantiate(Hp_Prefab, Hp_Prefab.transform.position + temp, Hp_Prefab.transform.rotation, Hp_UI.transform);
        }
    }
    public void remove_Hp()
    {
        Debug.Log(Hp_UI.transform.childCount);
        if (Hp_UI.transform.childCount <= 1)
        {
            Destroy(Hp_UI.transform.GetChild(Hp_UI.transform.childCount - 1).gameObject);
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Destroy(Hp_UI.transform.GetChild(Hp_UI.transform.childCount - 1).gameObject);
            Debug.Log("현재 체력 " + (Hp_UI.transform.childCount - 1) + "남음");
        }
    }
}
