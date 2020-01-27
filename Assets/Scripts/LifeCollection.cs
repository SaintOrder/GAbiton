
using UnityEngine;
public class LifeCollection : MonoBehaviour
{
    private GameObject Oldbattery;
    public GameObject SolutiontoUnload;
    private void Update()
    {
        Destroy(Oldbattery);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DieSpace.lives += 1;
            Oldbattery.transform.position = SolutiontoUnload.transform.position;
            
        }
    }
}
