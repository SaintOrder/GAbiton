
using UnityEngine;

public class DieSpace : MonoBehaviour
{ public GameObject Respawn;
    public static int lives = 1;
    
    public  void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            lives = lives - 1;
            other.transform.position = Respawn.transform.position;
           
        }
    }

}
