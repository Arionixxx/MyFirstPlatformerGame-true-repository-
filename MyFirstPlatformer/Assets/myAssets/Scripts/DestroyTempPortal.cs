using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTempPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyPortalCorounine());
    }

    IEnumerator destroyPortalCorounine()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
