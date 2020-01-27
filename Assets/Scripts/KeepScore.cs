using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScore : MonoBehaviour
{
    private DieSpace _dieSpace;
    private PlayerMovement _movement;
    private Animator _gameOverAnimator;

    private void Start()
    {
        _movement = GameObject.Find("player").GetComponent<PlayerMovement>();
        _gameOverAnimator = GameObject.Find("GAMEOVER").GetComponent<Animator>();
        _dieSpace = GameObject.Find("DieSpace").GetComponent<DieSpace>();
    }

    public void Died()
    {
        _movement.enabled = false;
        _gameOverAnimator.SetBool("isDead", true);  
    }
      void OnGUI()
    {
        GUI.Box(new Rect(100, 50, 50, 20), _dieSpace.lives.ToString());
    }
}
