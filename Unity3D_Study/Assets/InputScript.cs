using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;//�ν����� â���� �ӵ� ���� �� ���� �۵�.
    [SerializeField] Animator Chibi_ani;
    [SerializeField] Animator Jump_ani;
    [SerializeField] Animator Run_ani;

    // Update is called once per frame
    void Update()
    {
        /* �̰� �ν����� â���� �̵��ӵ� ���� �� �̵��ϵ��� �����ϴ� ��.
        if (Input.GetKey(KeyCode.A)) // 'A'�� ������ ���� 
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D)) // 'D'�� ������ ������ 
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W)) // 'W'�� ������ �� 
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) // 'S'�� ������ �� 
        {
            transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
        }

        //�̷��� �ϸ� �밢������ �̵� �� �� ���� �Ÿ��� �̵��ϰ� �Ǿ �¿� �̵����� �ӵ��� ������.
        //�̷��� �ǵ��� �ƴ϶�� ���� �޾ƿ��� ������� ����.
        */


        /* �̰� ���� ��ġ �Է� �� �����ϴ� ����
        Input.GetKeyDown(KeyCode.A); // 'A' Ű�� ������ ���� True�� ��ȯ�մϴ�.
        Input.GetKey(KeyCode.A);     // 'A' Ű�� ������ ���¶�� ��� True�� ��ȯ�մϴ�.
        Input.GetKeyUp(KeyCode.A);  // 'A' Ű�� �������� ���� True�� ��ȯ�մϴ�.


        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0); //A�� ������ ���� �����Ӹ��� x��ǥ -1�� �̵���Ŵ. (�̵�speed��)
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0); //D�� ������ ���� �����Ӹ��� x��ǥ 1�� �̵���Ŵ. (�̵�speed��)
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.1f, 0, 0); //A�� ������ �ִ� ���� �����Ӹ��� x��ǥ -0.1�� �̵���Ŵ. (�̵�speed��)
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.1f, 0, 0); //D�� ������ �ִ� ���� �����Ӹ��� x��ǥ 0.1�� �̵���Ŵ. (�̵�speed��)
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

        // Ű ������ �̵�
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

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime; //������Ʈ ��ġ += ���� * �̵��ӵ� * Time.deltaTime
        */

        // �Է�
        float moveX = Input.GetAxisRaw("Horizontal"); //�¿� �̵�
        float moveZ = Input.GetAxisRaw("Vertical"); //�յ� �̵�
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized; //

        // �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;


        // ȸ�� ���� �Է� �� �ϸ� �ƹ� Ű�� �Է� �� �޾��� �� ��ǥ�� 0�̵Ǿ ��ġ�� �������.
        //Ű �Է� �������� ȸ�� �����ִ� ��ɾ� �־��ֱ�!
        if (moveDirection != Vector3.zero) //�Է¹��� ����𷺼� ���� 0,0,0�� �ƴ� ��� ����.
        {
            // transform.rotation = Quaternion.LookRotation(moveDirection);  //�ܼ��� ������
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            //���� ����. ���� �� �ڿ������� ���� ���� ������ �ڵ�
        }

        // �ִϸ�����
        bool isWalk = 0 < moveDirection.magnitude;
        // moveDirection.magnitude : ������ ���̸� ��ȯ�մϴ�.
        // �Է� ���� ������ ������ ���̰� 0���� Ŀ���鼭 True�� ��ȯ�մϴ�.
        Chibi_ani.SetBool("ISWALK", isWalk); //SetBool (�Ķ������ �̸�, ���� ��)

        // anicon_PicoChan�̶�� �ִϸ����͸� ���� ������ �����մϴ�.
        // Bool Ÿ���� Parameter�� �����Ͽ��⿡ SetBool�Լ��� ����մϴ�.


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
