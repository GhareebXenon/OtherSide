using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{

    [SerializeField] StageData stageData;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] BossManager BossManager;
    StageTime stageTime;
    int eventIndexer;


    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        stageData.stageEvents[0].time = 0;
        stageData.stageEvents[1].time = 10;
        stageData.stageEvents[2].time = 20;
        stageData.stageEvents[3].time = 30;
    }

    private void Update()
    {


        if (eventIndexer >= stageData.stageEvents.Count) { return; }

        if (stageTime.time > stageData.stageEvents[eventIndexer].time)
        {

            Debug.Log(stageData.stageEvents[eventIndexer].message);

            
            for (int i = 0; i < stageData.stageEvents[eventIndexer].count;i++)
            {
                enemyManager.SpawnEnemy();
            }

            if (eventIndexer != 0)
            {
                stageData.stageEvents[eventIndexer].time += 30;
            }


            eventIndexer += 1;
            if(eventIndexer == 4)
            {
                eventIndexer = 1;
            }
         
        }
        
    }

   

}

