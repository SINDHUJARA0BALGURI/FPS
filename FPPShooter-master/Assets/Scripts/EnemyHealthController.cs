using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
   
        public int currentHealth;

        // Update is called once per frame
        void Update()
        {

        }
        public void DamageEnemy(int damageCount)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


