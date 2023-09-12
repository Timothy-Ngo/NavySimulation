using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entity;
using System;
using System.Linq;
using static UnityStandardAssets.Utility.TimedObjectActivator;

public class NPVesselController : MonoBehaviour
{
    public Entity.EntityType entityType;
    public List<Transform> transforms;
    public Entity381 entity;
    
    // Start is called before the first frame update
    void Start()
    {
        
        entity = SpawnNPVessel(transform.position, Vector3.zero);
        MoveToCheckpoint(transforms[0].position);
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    public void MoveToCheckpoint(Vector3 newPosition)
    {
        Debug.Log(entity);
        Move m = new Move(entity, newPosition);
        UnitAI ai = entity.GetComponent<UnitAI>();
        ai.SetCommand(m);

    }

    public GameObject NPVesselsRoot;


    public Entity381 SpawnNPVessel(Vector3 spawnPosition, Vector3 spawnEulerAngles)
    {
        Entity381 ent = null;
        GameObject entityPrefab = EntityMgr.inst.entityPrefabs.Find(x => (x.GetComponent<Entity381>().entityType == entityType));
        if (entityPrefab != null)
        {
            GameObject entityGO = Instantiate(entityPrefab, spawnPosition, Quaternion.Euler(spawnEulerAngles), NPVesselsRoot.transform);
            if (entityGO != null)
            {
                Debug.Log("entity created");
                ent= entityGO.GetComponent<Entity381>();
            }
        }

        return ent;
    }

    /*
    public Entity381 CreateEntity(EntityType et, Vector3 position, Vector3 eulerAngles)
    {
        Entity381 entity = null;
        GameObject entityPrefab = entityPrefabs.Find(x => (x.GetComponent<Entity381>().entityType == et));
        if (entityPrefab != null)
        {
            GameObject entityGo = Instantiate(entityPrefab, position, Quaternion.Euler(eulerAngles), entitiesRoot.transform);
            if (entityGo != null)
            {
                entity = entityGo.GetComponent<Entity381>();
                entityGo.name = et.ToString() + entityId++;
                entities.Add(entity);
            }
        }
        return entity;
    }
    */

}
