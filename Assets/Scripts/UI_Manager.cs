using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private Text Ammo_UI;

    bool up_State = true;

    public GameObject state_UI;
    public GameObject wave_UI;
    
    // Start is called before the first frame update
    void Start()
    {
        Ammo_UI = GameObject.Find("VR_Canvas").transform.Find("Ammo_UI").GetComponent<Text>();
        Ammo_UI.text = "총탄환/현재탄환 : 1/1";
    }

    // Update is called once per frame
    void Update()
    {if (GameManager.instance.isClear == true && up_State == false)   // 웨이브 끝나면 (강화창 띄우기 및 wave 증가)
        {
            // 강화창 띄우기
            state_UI.SetActive(true);
            wave_UI.SetActive(true);

            up_State = true;
        }
    }
    public void SetAmmoUi()
    {
        Ammo_UI.text = "총탄환/현재탄환 : " + GameManager.instance.Gi.get_ammo()+"/" + GameManager.instance.Gi.get_now_Ammo();
    }
    public void State_OK()
    {
        GameManager.instance.stateUp.defalut_SetHp();
        GameManager.instance.wave++;
        GameManager.instance.Mw.isReady = true;
        state_UI.SetActive(false);
        wave_UI.SetActive(false);

        GameManager.instance.isClear = false;
        up_State = false;
    }
}
