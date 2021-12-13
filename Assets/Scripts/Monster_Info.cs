using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Info : MonoBehaviour
{
    private float MonsterHp;
    // Start is called before the first frame update
    void Start()
    {
        MonsterHp = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "[CameraRig]")
        {
            GameManager.instance.stateUp.remove_Hp();
            Destroy(gameObject);
        }
        //Debug.Log("in");
        if (other.tag == "Bullet")
        {
            if(other.name =="sniperBullet")
            {
                MonsterHp -= GameManager.instance.Gi.Get_Gun_Damage();
            }
            else
            {
                Destroy(other.gameObject);
                MonsterHp -= GameManager.instance.Gi.Get_Gun_Damage();
            }

            if(MonsterHp <= 0)
            {
                Debug.Log(gameObject.name + "사망");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log(gameObject.name + "의 체력이 " + MonsterHp + " 만큼 남음");
            }

        }

    }
}
