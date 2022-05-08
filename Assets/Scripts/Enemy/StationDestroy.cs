using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationDestroy : MonoBehaviour
{
    MainStation _Station1;
    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _Station1 = GameObject.Find("Station 2").GetComponent<MainStation>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        
        
        Destroy(gameObject, 0.5f);
    }
}
