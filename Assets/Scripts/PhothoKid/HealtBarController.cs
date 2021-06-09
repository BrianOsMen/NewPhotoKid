using UnityEngine;
using UnityEngine.UI;

public class HealtBarController : MonoBehaviour
{
    public Enemys d;
    private float maxHealt;
    private float actualHealt;
    public Image healtBar;
    // Start is called before the first frame update
    void Start()
    {
        maxHealt = d.maxHealt;
        actualHealt = maxHealt/maxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealt();
        healtBar.fillAmount = actualHealt;
    }

    void CheckHealt()
    {
        actualHealt = d.healt/maxHealt;
    }
}
