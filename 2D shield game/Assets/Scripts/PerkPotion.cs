using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PerkPotion : MonoBehaviour
{
    [SerializeField]
    Text perkText;
    [SerializeField]
    float delay;

    GameObject player;

    private void Start() => perkText.gameObject.SetActive(false);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add perk and activate UI.
        if (collision.tag.Contains("Player"))
        {
            player = collision.gameObject;
            GetComponent<SpriteRenderer>().enabled = false;
            RandomPerk();
            Destroy(gameObject, delay);
        }
    }

    private void Update()
    {
        if(player != null)
            perkText.transform.position = player.transform.position + (player.transform.up * 1.5f);
    }

    //Input data to specifc component.
    void RandomPerk()
    {
        int randomNum = Random.Range(0, 3);

        //Access object even if it's disabled and set values.
        switch (randomNum)
        { 
            case 0:
                Dagger dagger = Resources.FindObjectsOfTypeAll<Dagger>().First<Dagger>();
                dagger.damage = 3;
                perkText.text = "Dagger damage +1";
                DefaultChanges();
                break;
            case 1:
                Health health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
                if (health.currentHealth == 3)
                    RandomPerk();

                if (health.currentHealth < 3)
                {
                    health.currentHealth++;
                    perkText.text = "Heart +1";
                    DefaultChanges();
                }
                break;
            case 2:
                Gun gun = Resources.FindObjectsOfTypeAll<Gun>().First<Gun>();
                if (gun.curAmmo == 3)
                    RandomPerk();

                if (gun.curAmmo < 3)
                {
                    gun.curAmmo++;
                    perkText.text = "Bullet +1";
                    GameObject.FindGameObjectWithTag("UI").GetComponent<Image>().fillAmount += 0.33f;
                    DefaultChanges();
                }
                break;
            
        }

        
    }

    void DefaultChanges()
    {
        perkText.gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnDestroy() => perkText.gameObject.SetActive(false);
}
