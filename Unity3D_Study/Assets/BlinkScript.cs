using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    //������Ʈ�� ���������ٰ� ����ǰ� �ϱ� > OnEnable

    void OnEnable() //������Ʈ�� ���������� 
    {
        //������ ������ ������Ʈ ��ġ
        transform.position = new Vector3(Random.Range(0f, 10f), 0f, Random.Range(0f, 10f)); //x�� z�� ������ 0~10 �Ǽ� ��ǥ�� �̵�.
    }
}
