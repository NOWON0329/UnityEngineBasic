using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//MonoBehavior �� ��ӹ��� ������Ʈ���� �����ڸ� ���ؼ� �����ϸ� �ȉ�;
public class Movement : MonoBehaviour
{
    /// <summary>
    /// ��ũ��Ʈ �ν��Ͻ��� ó�� �ε�� �� ȣ��
    /// �ش� ��ũ��Ʈ �ν��Ͻ��� ������Ʈ�� �����ϴ� ���ӿ�����Ʈ�� Ȱ��ȣ ���Ǿ��־�� ȣ��
    /// (���� ������Ʈ�� ��Ȱ��ȭ �� ä�� ����Ǹ� �ش� ���� ������Ʈ�� �ν��Ͻ�ȭ ���� �ʰ�, ���� ��ũ��Ʈ �ν���Ʈ�� �ν���Ʈȭ ���� �ʴ´�)
    /// ��ũ��Ʈ �ν��Ͻ��� ��Ȱ��ȭ �ϰڴٰ� �� ���Ƶ�
    /// ���ӿ�����Ʈ�� �ν��Ͻ��� �� �� �ش� ��ũ��Ʈ �ν��Ͻ��� �ε�Ǳ� ������ Awake�� ȣ��ȴ�.                                                                           
    ///  -> ������ ������� ����� (�����ڿ� ���ٴ� ���� �ƴ�. ��� �������� �ʱ�ȭ�� �ؾ��� �� �ַ� Awake���� ��)
    ///  
    /// </summary>
    private void Awake()
    {
        Debug.Log("Awake");
    }
    /// <summary>
    /// �� ������Ʈ�� ������ GameObject�� Ȱ��ȭ �ǰų�
    /// �� ��ũ��Ʈ �ν��Ͻ��� Ȱ��ȭ �� ������ ȣ���
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    /// <summary>
    /// �����Ϳ����� ȣ��. ��� �������� ��� default�� ����
    /// </summary>
    private void Reset()
    {
        Debug.Log("Reset");
    }
    /// <summary>
    /// Awake���� �ʱ�ȭ�� �Ϸ�� �ٸ� �������� ����ؼ� ��� �Ǵ� �ٸ� ��ü ���� ���� �ѹ� ���� �ؾ��Ѵٰ� �� �� �ַ� ���
    /// </summary>
    void Start()
    {
        Debug.Log("Start");
    }
    /// <summary>
    /// ���� ������ �ӵ��� �� ������ ȣ��� 
    /// ���� ���� ���� ������ �� �̺�Ʈ���� �����ؾ���
    /// </summary>
    private void FixedUpdate()
    {
        Debug.Log("fixedUpdate");
    }
    /// <summary>
    /// �浹�� ������Ʈ�� this ������Ʈ �� �ϳ� �̻���trigger�� Ȱ��ȭ �Ǿ��ְ� rigidbody�� �����Ҷ� 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[Movement] : {other.name} �� Ʈ���� ��");
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"[Movement] : {collision.gameObject.name} �� �浹��");
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log($"[Movement] : {gameObject.name} �� ���콺 �ٿ�");
    }
    private void OnMouseEnter()
    {
        Debug.Log($"[Movement] : {gameObject.name} �� ���콺 ����");
    }
    private void OnMouseDrag()
    {
        Debug.Log($"[Movement] : {gameObject.name} �� ���콺 ����");
    }
    private void OnMouseExit()
    {
        Debug.Log($"[Movement] : {gameObject.name} �� ���콺 Ż��");
    }
    private void OnMouseOver()
    {
        Debug.Log($"[Movement] : {gameObject.name} �� ���콺 ��ħ");
    }
    private void OnMouseUp()
    {
        Debug.Log($"[Movement] : {gameObject.name} �� ���콺 ��");
    }
    /// <summary>
    /// ���� ������ �⺻ ����
    /// �� �����Ӹ��� ȣ���
    /// </summary>
    void Update()
    {
        Debug.Log("Update");
    }
    /// <summary>
    /// �� �������� �������� ȣ���
    /// ���� ������ �������� ������ ���� �׳� �����Ӹ��� ȣ���� �Ǳ⸸ �ϸ� �ɶ� �ַ� ��(Camera)
    /// </summary>
    private void LateUpdate()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(Vector3.zero, 2.0f);
    }
}
