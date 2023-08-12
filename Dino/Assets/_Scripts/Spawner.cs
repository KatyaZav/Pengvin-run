using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] lvls;

    public void CreateLvl()
    {
        var rand = Random.Range(0, lvls.Length);
        Instantiate(lvls[rand], new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y), Quaternion.identity);
    }    
}
