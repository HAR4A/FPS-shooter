using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damagePoint = 20;
    [SerializeField] private float _speed = 10f;            //1

    void Update()
    {
        ObjectMove();                                       //2
    }

    void OnTriggerEnter(Collider other)                     //3
    {
        if (other.GetComponent<PlayerCharacter>())
        {
            other.GetComponent<PlayerCharacter>().Damage(_damagePoint);
        }
            Destroy(this.gameObject);                           //3
    }

    void ObjectMove()                                       //4
    {
        transform.Translate(0, 0, _speed * Time.deltaTime); //4
    }
}
