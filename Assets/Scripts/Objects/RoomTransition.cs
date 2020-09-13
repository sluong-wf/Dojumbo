using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 moveToPosition;
    
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;
    
    [SerializeField] private GameObject currCam;
    [SerializeField] private GameObject nextCam;

    [SerializeField] private PlayerMovement playerMovement;

    void Start() {
    }
    
    void OnEnable() {
        StartCoroutine(FadeCo());
    }

    public IEnumerator FadeCo() {
        if(fadeInPanel != null) {
            playerMovement.currentState = PlayerState.interact;
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
            
        currCam.SetActive(false);
        player.transform.position = moveToPosition;
        nextCam.SetActive(true);

        yield return new WaitForSeconds(fadeWait);
        
        playerMovement.currentState = PlayerState.idle;
    }
}
