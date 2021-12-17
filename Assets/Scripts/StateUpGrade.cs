using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateUpGrade : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage_Coefficient;     // 데미지 계수
    int maxHP;                           // 최대 HP
    int index_Len;
    int state_Index = 1;
    int compare_Index;

    public GameObject Hp_Prefab;
    public GameObject Hp_UI;
    public GameObject GameOver;
    public GameObject State_UI;
    public GameObject HpUiPivot;
    

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean up;
    public SteamVR_Action_Boolean down;
    public SteamVR_Action_Boolean check;
    public SteamVR_Action_Boolean reStart;

    void Start()
    {
        index_Len = GameObject.Find("Game_Canvas").transform.Find("State").childCount + 1;
        damage_Coefficient = 1;
        maxHP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isClear && !GameManager.instance.isGameOver)
        {
            if (down.GetLastStateUp(handType) && index_Len > state_Index)
            {
                state_Index++;
                //.Log(state_Index);
            }
            else if (up.GetLastStateUp(handType) && state_Index > 1)
            {
                state_Index--;
                //Debug.Log(state_Index);
            }
            else if (check.GetLastStateUp(handType))
            {
                if (state_Index == 1 && State_UI.activeSelf == true)
                {
                    Upgrade_HP();
                }
                else if (state_Index == 2 && State_UI.activeSelf == true)
                {
                    Upgrade_GUN();
                }
                else if (state_Index == index_Len)
                {
                    GameManager.instance.UM.State_OK();
                }
            }
            if (State_UI.activeSelf == false && state_Index != 3)
            {
                state_Index = index_Len;
                {
                    //Debug.Log(state_Index);
                }
            }
            if (compare_Index != state_Index)
            {
                if (state_Index == 1)
                {
                    GameObject.Find("Game_Canvas").transform.Find("State").GetChild(0).GetComponent<Image>().color = Color.green;
                    GameObject.Find("Game_Canvas").transform.Find("State").GetChild(1).GetComponent<Image>().color = Color.white;
                    GameObject.Find("Game_Canvas").transform.GetChild(0).GetComponent<Image>().color = Color.white;
                }
                else if (state_Index == 2)
                {
                    GameObject.Find("Game_Canvas").transform.Find("State").GetChild(0).GetComponent<Image>().color = Color.white;
                    GameObject.Find("Game_Canvas").transform.Find("State").GetChild(1).GetComponent<Image>().color = Color.green;
                    GameObject.Find("Game_Canvas").transform.GetChild(0).GetComponent<Image>().color = Color.white;
                }
                else if (state_Index == index_Len)
                {
                    GameObject.Find("Game_Canvas").transform.Find("State").GetChild(0).GetComponent<Image>().color = Color.white;
                    GameObject.Find("Game_Canvas").transform.Find("State").GetChild(1).GetComponent<Image>().color = Color.white;
                    GameObject.Find("Game_Canvas").transform.GetChild(0).GetComponent<Image>().color = Color.green;
                }
                compare_Index = state_Index;
            }
        }
        if(GameManager.instance.isGameOver && reStart.GetLastStateDown(SteamVR_Input_Sources.LeftHand))
        {
            SceneManager.LoadScene("Map_v2");
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
        maxHP += 2;

        Active_Hp();
        State_UI.SetActive(false);
        //Debug.Log("HP");
    }
    public void Active_Hp()
    {
        for (int i = 0; i <= Hp_UI.transform.childCount - 1; i++)
        {
            Destroy(Hp_UI.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i <= 9 + maxHP; i++)
        {
            Vector3 temp = new Vector3(-8f * i, 0, 0);
            Quaternion Quaternion_temp = Quaternion.Euler(new Vector3(0, 0, 0));
            GameObject temp1 = Instantiate(Hp_Prefab, HpUiPivot.transform.position + new Vector3(20f, 0f, 0f) + temp, Quaternion_temp, Hp_UI.transform);
            temp1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
    public void remove_Hp()
    {
        //Debug.Log(Hp_UI.transform.childCount);
        if (Hp_UI.transform.childCount <= 1)
        {
            Destroy(Hp_UI.transform.GetChild(Hp_UI.transform.childCount - 1).gameObject);
            GameManager.instance.isGameOver = true;
            GameManager.instance.UM.state_UI.SetActive(false);
            GameManager.instance.UM.wave_UI.SetActive(false);
            foreach (var Mob in GameManager.instance.mobParent_ray)
            {
                Destroy(Mob);
            }
            GameOver.SetActive(true);
            
        }
        else
        {
            Destroy(Hp_UI.transform.GetChild(Hp_UI.transform.childCount - 1).gameObject);
            //Debug.Log("현재 체력 " + (Hp_UI.transform.childCount - 1) + "남음");
        }
    }
}
