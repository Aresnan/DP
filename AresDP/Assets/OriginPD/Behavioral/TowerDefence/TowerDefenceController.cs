//-------------------------------------------------------------------------------------
//职责链模式
//基础塔防游戏client
//-------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefenceController : MonoBehaviour
{
    public GameObject Group;
    public GameObject Ground;
    public GameObject Airforce;

    List<GameObject> _enemyList;
    EnemyController _enemyController;
    AbstractTower _concreteGroupTower;
    AbstractTower _concreteGroundTower;
    AbstractTower _concreteAirforceTower;

    void Start()
    {
        _concreteGroupTower = new GroupTower();
        _concreteGroundTower = new GroundTower();
        _concreteAirforceTower = new AirforceTower();

        _concreteGroupTower.Tower = Group;
        _concreteGroundTower.Tower = Ground;
        _concreteAirforceTower.Tower = Airforce;

        _enemyController = GetComponent<EnemyController>();
        _enemyList = _enemyController.GetEnemyList();

        _concreteGroundTower.SetSuccessor(_concreteGroupTower);
        _concreteAirforceTower.SetSuccessor(_concreteGroundTower);
    }

    void Update()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {
            EnemyAttribute attribute = _enemyList[i].GetComponent<EnemyAttribute>();
            _concreteAirforceTower.Handle(attribute);
        }
    }
}
