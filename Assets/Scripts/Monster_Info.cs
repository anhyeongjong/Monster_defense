using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Info : MonoBehaviour
{
    Animator Zombie_Ani;
    Animator wolf_Ani;
    Animator troll_Ani;

    private float MonsterHp;
    // Start is called before the first frame update
    void Start()
    {
        
        if (gameObject.tag == "Wolf")
        {
            MonsterHp = 10f + GameManager.instance.wave * 20f;
            wolf_Ani = GetComponent<Animator>();
            wolf_Ani.SetTrigger("Wolf_Run");
        }
        else if (gameObject.tag == "Troll")
        {
            MonsterHp = 20f + GameManager.instance.wave * 30f;
            troll_Ani = GetComponent<Animator>();
            troll_Ani.SetTrigger("Troll_Walk");
        }
        else if (gameObject.tag == "Zombie")
        {
            MonsterHp = 20f + GameManager.instance.wave * 20f;
            Zombie_Ani = GetComponent<Animator>();
            Zombie_Ani.SetTrigger("Zombie_Run");
        }
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

        if (other.tag == "Bullet")
        {
            if (other.name == "sniperBullet")
            {
                GameObject explosion = Instantiate(GameManager.instance.explosion_Effect, other.transform.position, other.transform.rotation);
                explosion.name = "explosion";
                Destroy(explosion, 3f);
            }
            if (other.name != "explosion")
            {
                Destroy(other.gameObject);
            }
            MonsterHp -= GameManager.instance.Gi.Get_Gun_Damage();

            if (MonsterHp <= 0 && this.tag != "Plane")
            {
                //Debug.Log(gameObject.name + "사망");
                if (gameObject.tag == "Wolf")
                {
                    wolf_Ani.SetTrigger("Wolf_Die");
                    Destroy(gameObject, 1.3f);
                }
                else if (gameObject.tag == "Troll")
                {
                    troll_Ani.SetTrigger("Troll_Die");
                    Destroy(gameObject, 1.9f);
                }
                else if (gameObject.tag == "Zombie")
                {
                    Zombie_Ani.SetTrigger("Zombie_Die");
                    Destroy(gameObject, 2.5f);
                }
                GetComponent<Collider>().enabled = false;
                gameObject.GetComponent<zombie_Move>().Stop_Nav();

                //Debug.Log(MonsterHp.ToString());
            }
            else
            {
                //Debug.Log(gameObject.name + "의 체력이 " + MonsterHp + " 만큼 남음");
            }
        }
    }
}
