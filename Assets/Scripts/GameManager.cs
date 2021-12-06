using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gun_change Gc;
    public Gun_info Gi;
    public static GameManager instance;   //변수 선언부// 
    public Player_controller Pc;
    public int wave;
    public bool isClear = false;
    public GameObject mobParent;

    public GameObject Bullet_prefab;
    public Transform FirePos;

    public float Bullet_speed;
    private bool isGameOver = false;

    void Awake()
    {
        GameManager.instance = this;  //변수 초기화부 // 

    }
    // Start is called before the first frame update
    void Start()
    {
        Gc = GetComponent<Gun_change>();
        Gi = GetComponent<Gun_info>();
        Pc = GetComponent<Player_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mobParent.transform.childCount == 0)
        {
            isClear = true;
        }
    }
}
