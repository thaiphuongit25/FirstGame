using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float respawmDelay;    
    public PlayerController gamePlayer;
    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn() {
        StartCoroutine ("RespawnCoroutine");
    }

    public void StopHere() {
        gamePlayer.gameObject.SetActive(false);
    }

    public IEnumerator RespawnCoroutine(){
        gamePlayer.gameObject.SetActive (false);
        yield return new WaitForSeconds (respawmDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;

        gamePlayer.endGame.text = "";

        gamePlayer.gameObject.SetActive (true);
    }
}
