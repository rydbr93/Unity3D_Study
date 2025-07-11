using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;//인스펙터 창에서 속도 조절 후 관리 작동.
    [SerializeField] Animator Chibi_ani;
    [SerializeField] Animator Jump_ani;
    [SerializeField] Animator Run_ani;

    // Update is called once per frame
    void Update()
    {
        /* 이건 인스펙터 창에서 이동속도 조절 후 이동하도록 설정하는 것.
        if (Input.GetKey(KeyCode.A)) // 'A'를 누르면 왼쪽 
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D)) // 'D'를 누르면 오른쪽 
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W)) // 'W'를 누르면 앞 
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) // 'S'를 누르면 뒤 
        {
            transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
        }

        //이렇게 하면 대각선으로 이동 시 더 많은 거리를 이동하게 되어서 좌우 이동보다 속도가 빨라짐.
        //이런게 의도가 아니라면 방향 받아오는 기능으로 조절.
        */


        /* 이건 직접 수치 입력 후 적용하는 내용
        Input.GetKeyDown(KeyCode.A); // 'A' 키가 눌리는 순간 True를 반환합니다.
        Input.GetKey(KeyCode.A);     // 'A' 키가 눌리면 상태라면 계속 True를 반환합니다.
        Input.GetKeyUp(KeyCode.A);  // 'A' 키가 떼어지는 순간 True를 반환합니다.


        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0); //A를 누르는 순간 프레임마다 x좌표 -1씩 이동시킴. (이도speed값)
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0); //D를 누르는 순간 프레임마다 x좌표 1씩 이동시킴. (이도speed값)
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.1f, 0, 0); //A를 누르고 있는 동안 프레임마다 x좌표 -0.1씩 이동시킴. (이도speed값)
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.1f, 0, 0); //D를 누르고 있는 동안 프레임마다 x좌표 0.1씩 이동시킴. (이도speed값)
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 0.1f); 
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -0.1f); 
        }
        */


        /*
        Vector3 moveDirection = Vector3.zero;

        // 키 누르면 이동
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += new Vector3(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += new Vector3(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += new Vector3(0, 0, -1);
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime; //오브젝트 위치 += 방향 * 이동속도 * Time.deltaTime
        */

        // 입력
        float moveX = Input.GetAxisRaw("Horizontal"); //좌우 이동
        float moveZ = Input.GetAxisRaw("Vertical"); //앞뒤 이동
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized; //

        // 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;


        // 회전 조건 입력 안 하면 아무 키도 입력 안 받았을 때 좌표가 0이되어서 위치가 정면고정.
        //키 입력 받을때만 회전 시켜주는 명령어 넣어주기!
        if (moveDirection != Vector3.zero) //입력받은 무브디렉션 값이 0,0,0이 아닌 경우 실행.
        {
            // transform.rotation = Quaternion.LookRotation(moveDirection);  //단순한 움직임
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            //구면 보간. 조금 더 자연스럽게 방향 조정 가능한 코드
        }

        // 애니메이터
        bool isWalk = 0 < moveDirection.magnitude;
        // moveDirection.magnitude : 백터의 길이를 반환합니다.
        // 입력 값을 받으면 백터의 길이가 0보다 커지면서 True를 반환합니다.
        Chibi_ani.SetBool("ISWALK", isWalk); //SetBool (파라미터의 이름, 설정 값)

        // anicon_PicoChan이라는 애니메이터를 담을 변수를 생성합니다.
        // Bool 타입의 Parameter를 생성하였기에 SetBool함수를 사용합니다.


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Jump_ani.GetCurrentAnimatorStateInfo(0).IsName("Jumping Up") == false)
                Jump_ani.Play("Jumping Up");
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            Run_ani.Play("Run");
        }


    }
}
