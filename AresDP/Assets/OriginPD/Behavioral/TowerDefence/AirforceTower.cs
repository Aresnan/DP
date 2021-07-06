using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// concrete handler 
/// </summary>
public class AirforceTower : AbstractTower
{
    public override void Handle(EnemyAttribute attribute)
    {
        if (attribute.EnemyTypeIndex == (int)EnemyType.Airforce)
        {
            if (Vector3.Distance(Tower.transform.position, attribute.transform.position) < 5f)
            {
                attribute.Alive = false;
                Debug.Log("enemyType is : airforce");
            }
        }
        else
        {
            Successor.Handle(attribute);
        }
    }


}
