using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBoxScript : MonoBehaviour
{
    
    public GameObject _moneyBox;
    public GameObject coin;

    private Animator animator;
    private Animator coinAnimator;

    public Transform spawnPosition;
    public GameObject spawmObject;
    public float TimeSpawn;
    public bool isCaseOpen = false;
    public int CaseMoneyCount = 4; //to do: random
   // private Rigidbody2D _rigidbody;


    void Repeat()
    {
        StartCoroutine(SpawmCD());
    }
    IEnumerator SpawmCD()
    {

        yield return new WaitForSeconds(TimeSpawn);
       // spawnPosition.position = new Vector3 (spawnPosition.position.x, spawnPosition.position.y, -1);//тут мен€й 
        Instantiate(spawmObject,new Vector3(spawnPosition.position.x, spawnPosition.position.y, -1), Quaternion.identity);
        coinAnimator = spawmObject.GetComponent<Animator>();
        //туть что-то пытаюсь
     //  _rigidbody = spawmObject.AddComponent<Rigidbody2D>();
      //  _rigidbody.AddForce(transform.up * 2, ForceMode2D.Impulse);
        //spawmObject.isStatic = false;
        if (CaseMoneyCount > 0)
        {
            coinAnimator.SetTrigger("coinsDrop");
            CaseMoneyCount--;
            Repeat();

        }
        else
        {
            coinAnimator.SetTrigger("coinsDropOff");
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
