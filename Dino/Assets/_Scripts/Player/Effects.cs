using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] GameObject[] jumpEffects;
    [SerializeField] GameObject[] diedEffects;

    /// <summary>
    /// Make jump effect
    /// </summary>
    public void PlayEffectJump()
    {
        var rnd = Random.Range(0, jumpEffects.Length);
        Instantiate(jumpEffects[rnd], transform.position, Quaternion.identity);
    }

    /// <summary>
    /// Make died effect
    /// </summary>
    public void PlayEffectDied(GameObject obst)
    {
        var rnd = Random.Range(0, diedEffects.Length);
        Instantiate(diedEffects[rnd], obst.transform.position, Quaternion.identity);
    }
}
