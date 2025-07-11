using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    [SerializeField] GameObject cube; //세럴라이즈필는 인스펙터 창에 만들어서 cube값 조절할 수 있도록 만드는 것

    // Start is called before the first frame update
    void Start()
    {
        cube.transform.position = new Vector3(1, 0, 1);  //큐브 위치 이동  (x, y, z) 좌표값으로 이동.
        cube.transform.position += new Vector3(1, 0, 1);  //큐브 위치 이동  + 시키기.

        float distance = Vector3.Distance(transform.position, Vector3.zero);
        // Vector3.zero : Vector3(0,0,0)와 동일합니다.
        // Vector3.Dsitance(A,B) : A와 B의 사이의 거리를 반환합니다. > 0,0,0과 프레임마다 이동되는 거리를 찍어서 출력
        Debug.Log($"거리는 : {distance}");

        // ? transform.position += new Vector3(1f * Time.deltaTime, 0, 1f * Time.deltaTime);
        // 1초에 이동 값에 프레임 시간을 곱합서 네 프레임마다 입력하는 시간 찍어준다.
    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.position += new Vector3(0.1f, 0, 0.1f);  //매 프레임마다 0.1씩 이동 됨.
    }
}
