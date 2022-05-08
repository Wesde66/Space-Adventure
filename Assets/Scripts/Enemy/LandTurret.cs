using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LandTurret : MonoBehaviour
{
    [SerializeField] float MaxHealth;
    [SerializeField] GameObject Explosion;
    [SerializeField] GameObject ExplosionSmall;

    float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;


    }

    // Update is called once per frame
    void Update()
    {


        if (currentHealth <= 0)
        {
            Instantiate(Explosion, transform.position, transform.rotation);

            Destroy(gameObject, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            if (other != null)
            {
                currentHealth--;
                
                Instantiate(ExplosionSmall, other.transform.position, Quaternion.identity);

                Destroy(other.gameObject);
            }
        }
    }




}