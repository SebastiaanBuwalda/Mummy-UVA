using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewAnimation : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void OnMouseDown () {
        if (animator.GetBool("isHit")==false) {
        animator.SetBool("isHit", true);
        
        }
    }


    public void PlaySound(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
        StartCoroutine( SwitchScene());
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("firstScene");
    }
}
