using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public GameObject Hp_Prefab;
    public GameObject Hp_UI;
    private Text Ammo_UI;
    // Start is called before the first frame update
    void Start()
    {
        Ammo_UI = GameObject.Find("Canvas").transform.Find("Ammo_UI").GetComponent<Text>();
        Ammo_UI.text = "총탄환/현재탄환 : 1/1";
        StartCoroutine(defalut_SetHp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAmmoUi()
    {
        Ammo_UI.text = "총탄환/현재탄환 : " + GameManager.instance.Gi.get_ammo()+"/" + GameManager.instance.Gi.get_now_Ammo();
    }
   IEnumerator defalut_SetHp()
    {
        for(int i=1;i<=9;i++)
        {
            Vector3 temp = new Vector3(8f*i, 0, 0);
            GameObject temp1 = Instantiate(Hp_Prefab, Hp_Prefab.transform.position + temp, Hp_Prefab.transform.rotation, Hp_UI.transform);
            temp1.SetActive(false);

        }

        for (int i = 1; i <= 9;i++)
        {
            Hp_UI.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
