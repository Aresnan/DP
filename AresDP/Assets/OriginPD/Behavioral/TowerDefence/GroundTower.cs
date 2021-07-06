using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// concrete handler 
/// </summary>
public class GroundTower : AbstractTower
{
    public override void Handle(EnemyAttribute attribute)
    {
        if (attribute.EnemyTypeIndex == (int)EnemyType.Ground)
        {
            if (Vector3.Distance(Tower.transform.position, attribute.transform.position) < 10f)
            {
                attribute.Alive = false;
                Debug.Log("enemyType is : ground");
            }
        }
        else
        {
            Successor.Handle(attribute);
        }
    }

}
