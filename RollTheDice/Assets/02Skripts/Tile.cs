using UnityEngine;

/// <summary>
/// ���� �⺻ ĭ ���̽� Ŭ����
/// </summary>
public class Tile : MonoBehaviour
{
    public int index; //���° ĭ������ ���� �ε���

    /// <summary>
    /// �÷��̾ �ش� ĭ�� �������� �� ȣ���� �Լ�
    /// </summary>
    public virtual void OnHere()
    {
        Debug.Log($"Tile : {index} ��° ĭ ����!");
    }
}
