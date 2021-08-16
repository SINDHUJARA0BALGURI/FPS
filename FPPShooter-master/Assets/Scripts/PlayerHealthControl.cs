using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : MonoBehaviour
{
    public static PlayerHealthControl instance;
    public int maxHealth, currentHealth;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer(int damageCount)
    {
        currentHealth -= damageCount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "Health" + currentHealth;
    }
}
