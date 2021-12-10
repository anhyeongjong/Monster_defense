using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpGrade : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage_Coefficient;
    public float defence_Coefficient;
    void Start()
    {
        damage_Coefficient = 1;
        defence_Coefficient = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change_damage_Coefficient()
    {
        damage_Coefficient += 0.3f;
    }
    public float Get_Change_damage_Coefficient()
    {
        return damage_Coefficient;
    }
}
