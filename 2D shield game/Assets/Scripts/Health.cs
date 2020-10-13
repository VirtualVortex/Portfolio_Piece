using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    [SerializeField]
    float delay;
    [SerializeField]
    float currentHealth;

    SpriteRenderer sr;
    bool canDamage;
    float timer;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        color = new Color(255,255,255);
        color.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = color;

        if (Time.time > timer)
            canDamage = true;

        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public void ReduceHealth(float damage)
    {
        if (canDamage)
        {
            currentHealth -= damage;
            canDamage = false;
            timer = Time.time + delay;
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        color.a = 0.5f;
        yield return new WaitUntil(() => canDamage == true);
        color.a = 1f;

    }
}
