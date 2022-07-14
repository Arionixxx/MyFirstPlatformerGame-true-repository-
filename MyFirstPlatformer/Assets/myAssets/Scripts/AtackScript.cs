using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackScript : MonoBehaviour
{

    public Transform shotPosition;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(bullet, shotPosition.transform.position, transform.rotation);
        }
    }
}
