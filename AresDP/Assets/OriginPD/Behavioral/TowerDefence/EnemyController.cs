using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float _duration = 0f;
    Material[] _materials;
    GameObject _birthPoint;
    GameObject _enemyInstance;
    List<GameObject> _enemyList;
    string _materialPath = @"TowerDefence/Material";
    string _enemyPrefabPath = @"TowerDefence/Prefab/Enemy";

    public float Interval = 3f;
    void Awake()
    {
        _enemyList = new List<GameObject>();
        _birthPoint = GameObject.Find("BirthPoint");
        _materials = Resources.LoadAll<Material>(_materialPath);
        _enemyInstance = Resources.Load<GameObject>(_enemyPrefabPath);
    }

    void Update()
    {
        _duration += Time.deltaTime;
        if (_duration > Interval)
        {
            _duration = 0f;
            GenerateEnemy();
        }
        RemoveEnemy();
    }

    //生成物体
    void GenerateEnemy()
    {
        GameObject go = Instantiate(_enemyInstance, _birthPoint.transform);
        go.transform.localPosition = Vector3.zero;
        //生成材质
        int index = go.GetComponent<EnemyAttribute>().EnemyTypeIndex;
        Material material = _materials[index];
        go.GetComponent<Renderer>().material = material;
        _enemyList.Add(go);
    }
    //对enemy 列表进行操作
    public void RemoveEnemy()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {
            if (_enemyList[i].GetComponent<EnemyAttribute>().Alive == false)
            {
                GameObject go = _enemyList[i];
                _enemyList.Remove(go);
                Destroy(go);
            }
        }
    }
    public List<GameObject> GetEnemyList()
    {
        return _enemyList;
    }
}
