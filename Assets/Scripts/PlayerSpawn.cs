using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerSpawn : MonoBehaviour
{

    public Transform spawnPoint;
    public float startRotation;
    public GameObject playerTimer;

    //Assingables
    public Transform playerCam; //The Player camera. (Contains the main camera)
    public Transform orientation;   //The orientation of the player. (A child of player)


    // Start is called before the first frame update
    void Start()
    {

        playerTimer.GetComponent<Timer>().startTimer();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Dead"))
        {
            gameObject.transform.position = spawnPoint.transform.position;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.down;

            //Perform the rotations
            playerCam.transform.localRotation = Quaternion.Euler(0, startRotation, 0);
            orientation.transform.localRotation = Quaternion.Euler(0, startRotation, 0);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            playerTimer.GetComponent<Timer>().stopTimer();

            if(SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            


        }
    }
}
