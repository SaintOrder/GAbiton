using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    void OnCollisionEnter(Collision colision)
    {
        if (colision.transform.name == "Player")
        {
            KeepScore.Score += 1;
            Debug.Log("Gotem");
            Destroy(gameObject);
        }
    }

}
