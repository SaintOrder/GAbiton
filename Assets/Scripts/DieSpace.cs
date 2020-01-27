
using UnityEngine;

public class DieSpace : MonoBehaviour
{
    public GameObject Respawn;
    public int lives = 3;
    private KeepScore _keepScore;

    private void Start()
    {
        _keepScore = GameObject.Find("Scoreboard").GetComponent<KeepScore>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            lives = lives - 1;
            //If player still has lives, respawn
            if (lives > 0)
            {
                other.transform.position = Respawn.transform.position;
            }
            //Else, player is dead. Run game over screen
            else
            {
                _keepScore.Died();
            }
        }
    }

}
