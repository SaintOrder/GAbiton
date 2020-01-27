
using UnityEngine;
public class LifeCollection : MonoBehaviour
{
    private GameObject Oldbattery;
    public GameObject SolutiontoUnload;
    private DieSpace _dieSpace;

    private void Start()
    {
        _dieSpace = GameObject.Find("DieSpace").GetComponent<DieSpace>();
    }

    private void Update()
    {
        Destroy(Oldbattery);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _dieSpace.lives += 1;
            Oldbattery.transform.position = SolutiontoUnload.transform.position;
            
        }
    }
}
