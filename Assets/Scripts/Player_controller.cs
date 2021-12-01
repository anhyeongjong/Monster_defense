using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Player_controller : MonoBehaviour
{
    // 핸드 타입
    private SteamVR_Input_Sources right_Hand;
    private SteamVR_Input_Sources left_Hand;

    // 컨트롤러 버튼 타입
    public SteamVR_Action_Boolean function_Key;

    void Start()
    {
        right_Hand = SteamVR_Input_Sources.RightHand;
        left_Hand = SteamVR_Input_Sources.LeftHand;
    }

    void Update()
    {
        // right_function 클릭 시 
        if (function_Key.GetState(right_Hand))
        {
            // 총 발사
            Debug.Log("shot");
        }

        // left_function 클릭 시 
        if (function_Key.GetLastStateDown(left_Hand))
        {
            // 총(스킬) 체인지
            Debug.Log("change");
        }
    }
}
