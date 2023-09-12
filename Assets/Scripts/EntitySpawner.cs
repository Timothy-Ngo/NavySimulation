using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entity;
using System.Linq;

public class EntitySpawner : MonoBehaviour
{
    public EntityType entityType;
    public List<Transform> wayPoints = new List<Transform>();
    public float moveDelay = 1f;
    public int test;
    Entity381 entity;
    void Start()
    {
        entity = EntityMgr.inst.CreateEntity(entityType, transform.position, Vector3.zero);
        DistanceMgr.inst.Initialize();
        GetComponent<MeshRenderer>().enabled = false;
        foreach (Transform child in transform)
        {
            wayPoints.Add(child);
            child.GetComponent<MeshRenderer>().enabled = false;
        }
        
        StartCoroutine(MoveEntity());
    }

    IEnumerator MoveEntity()
    {
        yield return new WaitForSeconds(moveDelay);

        UnitAI uai = entity.GetComponent<UnitAI>();
        foreach (Transform waypoint in wayPoints)
        {
            Move m = new Move(entity, waypoint.position);
            uai.AddCommand(m);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Enable waypoints renderers?
        }

    }
}
