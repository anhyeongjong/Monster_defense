using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public Gun_change Gc;
    [HideInInspector]
    public Gun_info Gi;
    [HideInInspector]
    public static GameManager instance;   //변수 선언부// 
    [HideInInspector]
    public Player_controller Pc;
    [HideInInspector]
    public UI_Manager UM;
    [HideInInspector]
    public StateUpGrade stateUp;
    [HideInInspector]
    public Monster_wave Mw;

    public Text MobCount_UI;
    public Text NowWave_UI;

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
    void Start()
    {
        Gc = GetComponent<Gun_change>();
        Gi = GetComponent<Gun_info>();
        Pc = GetComponent<Player_controller>();
        UM = GetComponent<UI_Manager>();
        stateUp = GetComponent<StateUpGrade>();
        Mw = GetComponent<Monster_wave>();
    }
    void Update()
    {
        if (mobParent.transform.childCount == 0)
        {
            isClear = true;
        }

        MobCount_UI.text = "Mob : " + mobParent.transform.childCount;

    }
}
