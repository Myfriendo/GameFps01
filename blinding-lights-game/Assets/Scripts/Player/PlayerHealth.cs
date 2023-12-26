using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth = 150f;
    public float chipSpeed = 0.5f;
    public Image frontHealthBar;
    public Image backHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        
        //if (Input.GetKeyDown(KeyCode.L)) { TakeDamage(Random.Range(5f, 10f)); }
        //if (Input.GetKeyDown(KeyCode.K)) { Heal(Random.Range(5f, 10f)); }
    }
    
    public void UpdateHealthUI()
    {   
        Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float healthPercent = health / maxHealth;
        if(fillB>healthPercent)
        {
            frontHealthBar.fillAmount = healthPercent;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;// * chipSpeed;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete= percentComplete*percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, healthPercent, percentComplete);

        }
        if(fillF<healthPercent)
        {   
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = healthPercent;
            lerpTimer += Time.deltaTime;// * chipSpeed;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete= percentComplete*percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);

        }
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        lerpTimer = 0f;
    }
    
    public void Heal(float amount)
    {
        health += amount;
        lerpTimer = 0f;
    }
}
