using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;
    
    [SerializeField] private GameObject currCam;
    [SerializeField] private GameObject nextCam;

    private PlayerMovement player;

    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    
    void OnEnable() {
        playerStorage.InitialValue = playerPosition;
        StartCoroutine(FadeCo());
    }

    public IEnumerator FadeCo() {
        currCam.SetActive(false);
        nextCam.SetActive(true);

        if(fadeInPanel != null) {
            player.currentState = PlayerState.interact;
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
        yield return new WaitForSeconds(fadeWait);
        
        player.currentState = PlayerState.idle;
    }
}
