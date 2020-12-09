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
    
    //Input data to specifc component.
    void RandomPerk()
    {
        int randomNum = Random.Range(0, 3);
        perkText.gameObject.SetActive(true);
        perkText.transform.position = player.transform.position + (player.transform.up * 1.5f);

        //Access object even if it's disabled.
        switch (randomNum)
        { 
            case 0:
                Dagger dagger = Resources.FindObjectsOfTypeAll<Dagger>().First<Dagger>();
                dagger.damage = 4;
                perkText.text = "Dagger damage +2";
                break;
            case 1:
                Gun gun = Resources.FindObjectsOfTypeAll<Gun>().First<Gun>();
                gun.curAmmo++;
                Debug.Log("Extra Ammo");
                perkText.text = "Bullet +2";
                break;
            case 2:
                Health health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
                health.currentHealth++;
                perkText.text = "Heart +1";
                break;
        }
    }

    private void OnDestroy() => perkText.gameObject.SetActive(false);
}
