using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody bulletrb;
    public float lifeTime;
    public GameObject effects;
    public int damage = 1;
    public bool damageEnemy, damagePlayer;

    // Start is called before the first frame update
    void Start()
    {
        damagePlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        bulletrb.velocity = transform.forward * bulletSpeed;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(2);
        }
        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            //Debug.Log("I just got hit");
            PlayerHealthControl.instance.DamagePlayer(2);
        }


        Destroy(gameObject, 2f);
        Instantiate(effects, transform.position, transform.rotation);
    }


}
