using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainStation : MonoBehaviour
{
    [SerializeField] float destroy = 8;
    [SerializeField] float speed;
    [SerializeField] GameObject Explosion;

    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        transform.DOScale(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy <= 0 )
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            
            Destroy(gameObject, 0.5f);
        }

        transform.Rotate(0, 0, -1 * 3 * Time.deltaTime, Space.Self);
        
       
    }

   public  void DestroyStation(int __destroy)
    {
        destroy -= __destroy;
        _player.DestroyStationsLevel(1);
    }


}
