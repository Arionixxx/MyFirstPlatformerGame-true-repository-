using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBoxScript : MonoBehaviour
{
    
    public GameObject _moneyBox;
    public GameObject coin;

    private Animator animator;

    public Transform spawnPosition;
    public GameObject spawmObject;
    public float TimeSpawn;
    public bool isCaseOpen = false;
    public int CaseMoneyCount = 4; //to do: random


    void Repeat()
    {
        StartCoroutine(SpawmCD());
    }
    IEnumerator SpawmCD()
    {

        yield return new WaitForSeconds(TimeSpawn);
        Instantiate(spawmObject, spawnPosition.position, Quaternion.identity);
        if (CaseMoneyCount > 0)
        {
            CaseMoneyCount--;
            Repeat();
            
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Player")
        {
            Debug.Log("SUNDUK");

            if (isCaseOpen == false)
            {
                animator.SetTrigger("boxTrigger");
                StartCoroutine(SpawmCD());
                isCaseOpen = true;
            }
        }
    }
    

    
}
