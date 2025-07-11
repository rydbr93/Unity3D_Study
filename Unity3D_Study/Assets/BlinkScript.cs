using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    //오브젝트가 켜질때마다가 실행되게 하기 > OnEnable

    void OnEnable() //오브젝트가 켜질때마다 
    {
        //랜덤한 구간에 오브젝트 배치
        transform.position = new Vector3(Random.Range(0f, 10f), 0f, Random.Range(0f, 10f)); //x와 z값 랜덤한 0~10 실수 좌표로 이동. 
        //이를 잘 활용하면 캐릭터의 공간 이동 가능. 순간이동이나.
    }
}
