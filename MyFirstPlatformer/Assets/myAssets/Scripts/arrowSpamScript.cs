using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpamScript : MonoBehaviour
{

    public Transform arrowPosition;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(arrowCoroutine());
    }

    IEnumerator arrowCoroutine()
    {
        Instantiate(arrow, arrowPosition.transform.position, transform.rotation);
        yield return new WaitForSeconds(2);
        StartCoroutine(arrowCoroutine());
    }
}
