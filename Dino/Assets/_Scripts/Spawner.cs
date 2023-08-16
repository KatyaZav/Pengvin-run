using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] lvls;

    public static float speed = 0;

    private void Start()
    {
        PlayerMoving.GameStartded += StartGame;
    }

    private void OnDestroy()
    {
        PlayerMoving.GameStartded -= StartGame;        
    }

    private void StartGame()
    {
        speed = 2f;
        StartCoroutine(AddMoreSpeed());    
    }

    public void CreateLvl()
    {
        var rand = Random.Range(0, lvls.Length);
        Instantiate(lvls[rand], new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y), Quaternion.identity);
    }    

    private IEnumerator AddMoreSpeed()
    {
        while (true)
        {
            if (speed < 20f)
                speed += 0.5f;
            yield return new WaitForSeconds(speed/3);
        }
    }
}
