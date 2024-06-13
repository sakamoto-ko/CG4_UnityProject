using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
