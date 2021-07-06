//-------------------------------------------------------------------------------------
//ְ����ģʽ
//����������Ϸ
//-------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��������
/// </summary>
public enum EnemyType
{
    Airforce,
    Ground,
    Group
}
/// <summary>
/// ���� Handler
/// </summary>
public abstract class AbstractTower
{
    protected AbstractTower Successor;
    public GameObject Tower;
    public void SetSuccessor(AbstractTower successor)
    {
        this.Successor = successor;
    }
    public abstract void Handle(EnemyAttribute attribute);

}
