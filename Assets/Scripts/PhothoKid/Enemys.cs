using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemys : MonoBehaviour
{

    public bool isEnemy;
    public bool isTrigger;
    private bool recoverHealt;
    private bool inRecovery;
    public int enemyClass;
    public int damageSize;
    public string consonants = "BCDFGHJKLMNPQRSTVWXYZ";
    public string vowels = "AEIOU";
    public string enemyAtack;
    public string trueEnemyAtack;
    public int healt;
    public int maxHealt;
    public Text box;

    // Start is called before the first frame update
    void Start()
    {
        isEnemy = true;
        recoverHealt = false;
        inRecovery = false;
        healt = maxHealt;
    }

    private void Update()
    {
        RecoveryHealt();
    }

    public void Damage()
    {
        if(healt > 0)
        {
            DoAtack();
            healt -= 25;
            recoverHealt = true;
        }
    }

    private void OnTriggerStay()
    {
        isTrigger = true;
    }

    private void OnTriggerExit()
    {
        isTrigger = false;
        box.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && healt > 0)
        {
            DoAtack();
        }
    }


    private string Atack()
    {
        string atackString = "";
        char theChar;
        if(enemyClass == 1)
        {
            for(int i = 0; i < 5; i++)
            {
                theChar = consonants[Random.Range(0, consonants.Length)];
                atackString += theChar;
            }
        }
        if(enemyClass == 2)
        {
            for(int i = 0; i < 5; i++)
            {
                theChar = vowels[Random.Range(0, vowels.Length)];
                atackString += theChar;
            }
        }
        if(enemyClass == 3)
        {
            int l = Random.Range(0, 4);
            for(int i = 0; i < 5; i++)
            {
                if (l == i)
                {
                    theChar = consonants[Random.Range(0, consonants.Length)];
                    atackString += theChar;
                }
                else
                {
                    theChar = vowels[Random.Range(0, vowels.Length)];
                    atackString += theChar;
                }
            }
        }
        return atackString;
    }

    public void DoAtack()
    {
        enemyAtack = Atack();
        trueEnemyAtack = ReplaceR(enemyAtack);
        Debug.Log(enemyAtack);
        box.text = enemyAtack;
    }

    private string ReplaceR(string str)
    {
        bool vowelFindIt;
        string result = "";
        for(int i = 0; i < str.Length; i++)
        {
            vowelFindIt = false;
            for(int j = 0; j < 5; j++)
            {
                if(str[i] == vowels[j])
                {
                    result += str[i];
                    vowelFindIt = true;
                }
                if(j == 4 && !vowelFindIt)
                    result += 'R';
            }
        }
        return result;
    }

    void RecoveryHealt()
    {
        if(healt < maxHealt && recoverHealt && !inRecovery)
        {
            StartCoroutine(DelayRecovery(0.5f));
        }
    }

    IEnumerator DelayRecovery(float delayTime)
    {
        inRecovery = true;
        recoverHealt = false;
        yield return new WaitForSeconds(delayTime);
        healt++;
        recoverHealt = true;
        inRecovery = false;
    }

}
