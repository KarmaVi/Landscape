using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
    private GameMaster gm;
    private CharacterController _characterController;

    public void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        //gm = GameObject.FindWithTag("GM").GetComponent<GameMaster>();



        //transform.position = gm.lastCheckPointPos;
    }

    public void Start()
    {
        var newPosition = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));

        _characterController.enabled = false;
        transform.position = newPosition;
        _characterController.enabled = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
