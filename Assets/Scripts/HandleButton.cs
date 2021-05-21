using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleButton : MonoBehaviour
{
    public PlayerController gamePlayer;
    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKey(KeyCode.Return))
        {
            if (!gamePlayer.gameObject.activeSelf) {
                gamePlayer.transform.position = gamePlayer.respawnPoint;

                gamePlayer.gameObject.SetActive (true);
                gamePlayer.endGame.text = "";
                gamePlayer.ready.text = "Running";
            }
        }
    }
}
