using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : MonoBehaviour
{
    public float Speed = 5;
    public bool Alive = true;
    public int EnemyTypeIndex;
    void Awake()
    {
        EnemyTypeIndex = Random.Range(0, 4);
    }


    void Update()
    {
        //move
        float s = Speed * Time.deltaTime;
        transform.position += new Vector3(s, 0, 0);
    }
}
