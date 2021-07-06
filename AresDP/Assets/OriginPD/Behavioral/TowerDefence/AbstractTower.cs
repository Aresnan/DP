//-------------------------------------------------------------------------------------
//职责链模式
//基础塔防游戏
//-------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人类型
/// </summary>
public enum EnemyType
{
    Airforce,
    Ground,
    Group
}
/// <summary>
/// 抽象 Handler
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
