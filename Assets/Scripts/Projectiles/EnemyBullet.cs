using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject explosion1;
    

    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
        _player = GameObject.Find("Player").GetComponent<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision != null)
            {
                Instantiate(explosion1, transform.position, Quaternion.identity);
                _player.playerDamage(1);

                Destroy(gameObject);
            }
        }
    }
}
