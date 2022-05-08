using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{
    [SerializeField] float _speed;
    [SerializeField] float PlayerShootOff;
    [SerializeField] float MaxHealth;
    [SerializeField] float LevelOver = 80;
    [SerializeField] Animator anim;
    [SerializeField] Transform _firePoint;
    [SerializeField] GameObject _PlayerBullet1;
    [SerializeField] GameObject _TrippleShot;
    [SerializeField] GameObject Explosion;
    
    UIManager _UIManager;
    SpriteRenderer PlayerSprite; 

    bool firedelay = true;
    bool shieldsUp = false;
    bool trippleshotActive = false;
    bool Level1Active = false;

    float currentHealth;
    float BoostActivate = 1;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();

        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        PlayerSprite = GetComponent<SpriteRenderer>();

        currentHealth = MaxHealth;

       


    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();

        if (LevelOver == 0)
        {
            StartCoroutine(Level3LoadSequence());
        }

        if (Level1Active == true)
        {
            transform.Translate(Vector3.up * PlayerShootOff * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && firedelay)
        {
            FireWeapon();
            firedelay = false;
            StartCoroutine(DelayBullets());
        }
    }

    void MovementPlayer()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(H, V, 0) * (_speed * BoostActivate) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.3f, 0), 0);

        if (H < -0.1f)
        {
            anim.SetBool("TurnLeft", true);
        }
        else
        {
            anim.SetBool("TurnLeft", false);
        }

        if (H > 0.1f)
        {
            anim.SetBool("TurnRight", true);
        }
        else
        {
            anim.SetBool("TurnRight", false);
        }

        if (transform.position.x >= 9.4f)
        {
            transform.position = new Vector3(-9.3f, transform.position.y, 0);
        }

        if (transform.position.x <= -9.4f)
        {
            transform.position = new Vector3(9.3f, transform.position.y, 0);
        }


    }

    void FireWeapon()
    {
        if (trippleshotActive == true)
        {
            Instantiate(_TrippleShot, _firePoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_PlayerBullet1, _firePoint.position, Quaternion.identity);
        }
        
    }

    IEnumerator DelayBullets()
    {
        yield return new WaitForSeconds(0.5f);
        firedelay = true;
    }

    public void playerDamage(int Damage)
    {
        

        if (shieldsUp == false)
        {
            currentHealth -= Damage;

            if (currentHealth <= 0)
            {
                _UIManager.LivesUpdateImage(0);
                Instantiate(Explosion, transform.position, Quaternion.identity);
                PlayerSprite.enabled = false;
                transform.GetChild(1).gameObject.SetActive(false);
            }

            if (currentHealth == 1)
            {
                _UIManager.LivesUpdateImage(1);
            }

            if (currentHealth == 2)
            {
                _UIManager.LivesUpdateImage(2);
            }

            if (currentHealth == 3)
            {
                _UIManager.LivesUpdateImage(3);
            }
        }
        else
        {
            shieldsUp = false;
            transform.GetChild(2).gameObject.SetActive(false);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shield")
        {
            if (other != null)
            {
                transform.GetChild(2).gameObject.SetActive(true);
                shieldsUp = true;

                Destroy(other.gameObject);
            }
        }

        if (other.tag == "SpeedBoost")
        {
            if (other != null)
            {
                StartCoroutine(Boost());
                Destroy(other.gameObject);
            }
        }

        if (other.tag == "TrippleShot")
        {
            StartCoroutine(TrippleShot());
            Destroy(other.gameObject);
        }
    }

    IEnumerator Boost()
    {
        BoostActivate = 2;
        yield return new WaitForSeconds(6);
        BoostActivate = 1;
    }

    IEnumerator TrippleShot()
    {
        trippleshotActive = true;
        yield return new WaitForSeconds(10);
        trippleshotActive = false;
    }

    IEnumerator LoadScene2()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(2);
    }

    IEnumerator Level3LoadSequence()
    {
        yield return new WaitForSeconds(2);
        transform.localScale = new Vector3(0.6f, 0.6f, 2);
        ScaleDown();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }

    public void PlayerShootOffSequence()
    {
        transform.localScale = new Vector3(0.6f, 0.6f, 2);
        ScaleDown();
        Level1Active = true;
        StartCoroutine(LoadScene2());
    }

    public void DestroyStationsLevel(int A)
    {
        LevelOver -= A;
    }
    void ScaleDown()
    {
        transform.DOScale(0, 2);
    }
}


