using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    [SerializeField]
    float delay;
    [SerializeField]
    float currentHealth;
    [SerializeField]
    bool useUI;
    [SerializeField]
    Image healthBar;

    SpriteRenderer sr;
    SceneChanger sc;
    ParticleSystem ps;
    bool canDamage;
    float timer;
    Color color;
    float x;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        if (!useUI)
            healthBar = null;
        else if(useUI)
            CameraControls.inst.SetUp();

        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        sc = SceneChanger.inst;
        color = new Color(255,255,255);
        color.a = 1;
        x = 1;
        startPos = transform.position;
        if (GetComponent<ParticleSystem>())
            ps = GetComponent<ParticleSystem>();

        
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = color;

        if (Time.time > timer)
            canDamage = true;

        if (currentHealth <= 0 && transform.name.Contains("Player"))
        {
            sc.GoToBegining();
            currentHealth = maxHealth;
            CameraControls.inst.SetUp();
        }
        else if (currentHealth <= 0 && !transform.name.Contains("Player"))
            Destroy(gameObject);

        if (useUI)
        {
            x = Mathf.InverseLerp(0, maxHealth, currentHealth);
            healthBar.fillAmount = x;
        }
        
    }

    public void ReduceHealth(float damage)
    {
        if (canDamage)
        {
            currentHealth -= damage;
            canDamage = false;
            timer = Time.time + delay;
            StartCoroutine(Fade());
            if (GetComponent<ParticleSystem>())
                ps.Play();
        }
    }

    IEnumerator Fade()
    {
        color.a = 0.5f;
        yield return new WaitUntil(() => canDamage == true);
        color.a = 1f;
    }

    
}
