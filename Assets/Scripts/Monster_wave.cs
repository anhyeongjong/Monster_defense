using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_wave : MonoBehaviour
{
    public Transform spawnPoints;
    public GameObject[] monsterPrefabs;
    
    bool isReady = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isReady == true)
        {
            StartCoroutine(monsterSpawner());
            isReady = false;
            GameManager.instance.isClear = false;
        }
        if (GameManager.instance.isClear == true)   // 웨이브 끝나면 (강화창 띄우기 및 wave 증가)
        {
            // 강화창 띄우기


            // wave 증가
            //if (강화창 ok되면)
            GameManager.instance.wave++;
            isReady = true;
        }
    }

    IEnumerator monsterSpawner()
    {
        for (int i = 0; i < 1; i++)      // 소 웨이브
        {
            for (int j = 0; j < 15; j++) // 몹 생성 갯수
            {
                Vector3 mobspawnPoint = spawnPoints.position + new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(-70.0f, 70.0f));
                Instantiate(monsterPrefabs[Mathf.Clamp((Random.Range(1,GameManager.instance.wave + 1) - 1), 0, 8)], mobspawnPoint, Quaternion.identity,
                    GameManager.instance.mobParent.transform);
                yield return new WaitForSecondsRealtime(0.05f);
            }
            yield return new WaitForSecondsRealtime(3.0f);
        }
    }
}
