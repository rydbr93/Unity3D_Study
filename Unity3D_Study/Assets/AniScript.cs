using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScript : MonoBehaviour
{
    public Animator animator; // �ִϸ��̼� ��Ʈ�ѷ�
    public KeyCode key = KeyCode.Space; // ������ Ű

    void Update()
    {
        if (Input.GetKeyDown(key)) // ������ Ű�� ������
        {
            animator.SetTrigger("Jumping Up"); // �ִϸ��̼� ����
        }
    }
}
