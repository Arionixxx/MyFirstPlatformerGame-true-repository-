using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnFireDestroy());
    }

    // Update is called once per frame
    IEnumerator spawnFireDestroy()
    {
        yield return new WaitForSeconds(0.16f);
        Destroy(gameObject);
    }
}
