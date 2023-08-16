using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] lvls;

    public static float Speed { get; private set;}

    private void Start()
    {
        StartCoroutine(AddMoreSpeed());    
    }

    /// <summary>
    /// Create part of level
    /// </summary>
    public void CreateLvlPart()
    {
        var rand = Random.Range(0, lvls.Length);

        Instantiate(lvls[rand],
            new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y),
            Quaternion.identity);
    }    

    /// <summary>
    /// Add speed while time
    /// </summary>
    private IEnumerator AddMoreSpeed()
    {
        while (true)
        {
            if (Speed < 20f)
            {
                Speed += 0.5f;
                Debug.Log(string.Format("Speed increase to {0}", Speed));
            }

            yield return new WaitForSeconds(Speed/3);
        }
    }
}
