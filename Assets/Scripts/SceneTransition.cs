using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private PlayerMovement player;

    // called before Start
    void Awake() {
        if(fadeInPanel != null) {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }

        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger) {
            playerStorage.InitialValue = playerPosition;
            // SceneManager.LoadScene(sceneToLoad);
            StartCoroutine(FadeCo());
        }
    }

    public IEnumerator FadeCo() { // Coroutine
        if(fadeOutPanel != null) {
            player.currentState = PlayerState.interact;
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone) {
            yield return null;
        }
        player.currentState = PlayerState.idle;
    }
}
