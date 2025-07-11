using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    [SerializeField] GameObject cube; //�����������ʵ�? cube��� ������Ʈ�� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        cube.transform.position = new Vector3(1, 0, 1);  //ť�� ��ġ �̵�  (x, y, z) ��ǥ������ �̵�.
        cube.transform.position += new Vector3(1, 0, 1);  //ť�� ��ġ �̵�  + ��Ű��.

        float distance = Vector3.Distance(transform.position, Vector3.zero);
        // Vector3.zero : Vector3(0,0,0)�� �����մϴ�.
        // Vector3.Dsitance(A,B) : A�� B�� ������ �Ÿ��� ��ȯ�մϴ�. > 0,0,0�� �����Ӹ��� �̵��Ǵ� �Ÿ��� �� ���
        Debug.Log($"�Ÿ��� : {distance}");
    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.position += new Vector3(0.1f, 0, 0.1f);  //�� �����Ӹ��� 0.1�� �̵� ��.
    }
}
