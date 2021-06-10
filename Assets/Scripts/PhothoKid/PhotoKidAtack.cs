using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PhotoKidAtack : MonoBehaviour
{
    
    private Enemys d;
    private int atacksAcerts;
    private bool recoverKidHealt;
    private bool inRecovery;
    public int kidHealt;
    public int kidMaxHealt;
    public GameObject joy;

    // Start is called before the first frame update
    void Start()
    {
        atacksAcerts = 0;
        kidHealt = kidMaxHealt;
        inRecovery = false;
        joy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RecoveryHealt();
        char x = CharKeyDetection();
        if(d != null && x != ' ')
        {
            if(x == d.trueEnemyAtack[atacksAcerts])
            {
                Debug.Log(d.enemyAtack[atacksAcerts]);
                atacksAcerts++;
            }
            else
            {
                Debug.Log("Ataque Fallido");
                atacksAcerts = 0;
                kidHealt -= d.damageSize;
                recoverKidHealt = true;
                if(kidHealt <= 0) 
                {
                    Debug.Log("PhotoKid Muerto");
                    Destroy(GameObject.Find("Player"));
                }
                d.DoAtack();
            }
            if(atacksAcerts == 5)
            {
                Debug.Log("Da�o");
                d.Damage();
                atacksAcerts = 0;
                if(d.healt < 1)
                {
                    Destroy(GameObject.Find(d.name));
                    joy.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        d = other.GetComponent<Enemys>();
        if(d != null)
            joy.SetActive(true);
    }

    private void OnTriggerExit()
    {
        d = null;
        atacksAcerts = 0;
        joy.SetActive(false);
    }

    private void AtackEnemy()
    {
        string enemyAtack = d.enemyAtack;
        string trueArack = d.trueEnemyAtack;
        Debug.Log(enemyAtack);
    }

    private char CharKeyDetection()
    {
        char x = ' ';
        if(Input.GetButtonUp("Fire1"))
            x = 'A';
        if(Input.GetButtonUp("Fire2"))
            x = 'E';
        if(Input.GetButtonUp("Fire3"))
            x = 'I';
        if(Input.GetButtonUp("Fire4"))
            x = 'O';
        if(Input.GetButtonUp("Fire5"))
            x = 'U';
        if(Input.GetButtonUp("Jump"))
            x = 'R';
        return x;
    }

    void RecoveryHealt()
    {
        if (kidHealt < kidMaxHealt && recoverKidHealt && !inRecovery && kidHealt > 0)
        {
            StartCoroutine(DelayRecovery(1.0f));
        }
    }

    IEnumerator DelayRecovery(float delayTime)
    {
        inRecovery = true;
        recoverKidHealt = false;
        yield return new WaitForSeconds(delayTime);
        kidHealt++;
        recoverKidHealt = true;
        inRecovery = false;
    }

}
