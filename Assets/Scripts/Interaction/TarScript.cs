using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarScript : MonoBehaviour
{

    public ItemTeleporting itemTeleporting;
    private float TimeSpan = 25f;
    private bool StartSpan = false;
    public bool CloneSpan = false;

    public GameObject TarShape;
    public GameObject SafeShape;
    // Start is called before the first frame update
    void Start()
    {
        SafeShape.SetActive(false);
        if (CloneSpan == true) //It should never be "true" for the parent (or the already existing) tar so it could execute properly for its clones only.
        {
            StartSpan = true;
            Vector3 randomVector = new Vector3(Random.Range(itemTeleporting.TarMin.x, itemTeleporting.TarMax.x), 0.75f, Random.Range(itemTeleporting.TarMin.z, itemTeleporting.TarMax.z));
            gameObject.transform.position = randomVector;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (StartSpan == true) { TimeSpan -= Time.deltaTime; }
       if (TimeSpan <= 0.2f)
        {
            SafeShape.SetActive (true);
            TarShape.SetActive (false);
        }
        if (TimeSpan <= 0) {Destroy(gameObject); }
    }
}
