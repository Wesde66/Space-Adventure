using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    [SerializeField] GameObject Fireball;
    [SerializeField] float speed;
    [SerializeField] Transform _LeftFire;
    [SerializeField] Transform _RightFire;

    Player _player;
    UIManager _UIManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        StartCoroutine(FireBullet());
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        float randomX = Random.Range(-7, 7);

        if (transform.position.y <= -6)
        {
            transform.position = new Vector3(randomX, 6, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            if (other.tag != null)
            {
                _UIManager.ScoreUpdate(15);
                Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(this.gameObject, 0.2f);
            }
        }

        if (other.tag == "Player")
        {
            if (other.tag != null)
            {
                _player.playerDamage(1);
                Instantiate(Explosion, transform.position, Quaternion.identity);

                Destroy(this.gameObject, 0.5f);
            }
        }
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            Instantiate(Fireball, _LeftFire.position, Quaternion.identity);
            Instantiate(Fireball, _RightFire.position, Quaternion.identity);

            yield return new WaitForSeconds(2);
        }

    }
}
