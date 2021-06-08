using UnityEngine;

public class MainCamController : MonoBehaviour
{

    public GameObject go;
    public Camera cam;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = cam.transform.position - go.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (go != null)
        {
            cam.transform.position = go.transform.position + distance;
        }
    }
}
