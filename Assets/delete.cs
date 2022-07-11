using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delete", 0.2f);
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
