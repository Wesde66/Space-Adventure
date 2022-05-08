using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class gunpoint : MonoBehaviour
{
    [SerializeField] GameObject Fireball;
    [SerializeField] Transform Gun1;
    [SerializeField] float delayTime;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(shoot());
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            Instantiate(Fireball, Gun1.position, transform.rotation);

            yield return new WaitForSeconds(delayTime);
        }

    }
}
