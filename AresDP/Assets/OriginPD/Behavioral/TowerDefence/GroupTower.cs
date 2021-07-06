using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// concrete handler 
/// </summary>
public class GroupTower : AbstractTower
{
    public override void Handle(EnemyAttribute attribute)
    {
        if (attribute.EnemyTypeIndex == (int)EnemyType.Group)
        {
            if (Vector3.Distance(Tower.transform.position, attribute.transform.position) <20f)
            {
                attribute.Alive = false;
                Debug.Log("enemyType is : group");
            }            
        }
        else
        {
            //Successor.Handle(attribute);            
            MonoBehaviour mono = attribute.GetComponent<MonoBehaviour>();
            mono.StartCoroutine(Shot(attribute));
        }
    }
    IEnumerator Shot(EnemyAttribute attribute)
    {
        Debug.Log("无法识别的物体");
        yield return new WaitForSeconds(3);
        attribute.Alive = false;
    }
}
