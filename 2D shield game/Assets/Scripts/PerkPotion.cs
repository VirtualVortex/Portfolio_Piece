using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PerkPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            RandomPerk();
            Destroy(gameObject);
        }
    }

    void RandomPerk()
    {
        int randomNum = Random.Range(0, 3);

        switch (randomNum)
        {
            case 0:
                Dagger dagger = Resources.FindObjectsOfTypeAll<Dagger>().First<Dagger>();
                dagger.damage = 5;
                Debug.Log("Dagger damage");
                break;
            case 1:
                Gun gun = Resources.FindObjectsOfTypeAll<Gun>().First<Gun>();
                gun.curAmmo++;
                Debug.Log("Extra Ammo");
                break;
            case 2:
                Health health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
                health.currentHealth++;
                Debug.Log("Extra Heart");
                break;
        }
    }
}
