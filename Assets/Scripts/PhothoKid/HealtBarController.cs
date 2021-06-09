using UnityEngine;
using UnityEngine.UI;

public class HealtBarController : MonoBehaviour
{
    public Enemys d;
    public PhotoKidAtack e;
    private float maxHealt;
    private float actualHealt;
    public Image healtBar;
    // Start is called before the first frame update
    void Start()
    {
        if(d != null)
            maxHealt = d.maxHealt;
        if (e != null)
            maxHealt = e.kidMaxHealt;
        actualHealt = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealt();
        healtBar.fillAmount = actualHealt;
    }

    void CheckHealt()
    {
        if(d != null)
            actualHealt = d.healt/maxHealt;
        if (e != null)
            actualHealt = e.kidHealt / maxHealt;
    }
}
