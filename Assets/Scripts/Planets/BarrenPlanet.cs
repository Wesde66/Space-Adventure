using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BarrenPlanet : MonoBehaviour
{
    Player _player;

    bool PlanetApproachActive = false;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        planetMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == 0f && transform.position.y == 2f)
        {
            _player.PlayerShootOffSequence();
        }
    }

    public void planetMovement()
    {
        Sequence MySequence = DOTween.Sequence();

        MySequence.Append(transform.DOMoveX(0, 60, false))
            .Append(transform.DOMove(new Vector3(-3.32f, -0.61f, 0), 20, false))
            .Append(transform.DOMove(new Vector3(5.36f, -0.61f, 0), 20, false))
            .Append(transform.DOMove(new Vector3(0f, 2f, 0), 20, false));

    }

   
}

    



