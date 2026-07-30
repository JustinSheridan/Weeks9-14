using UnityEngine;

public class HeroController : MonoBehaviour
{
    public Animator heroAnimator;
    public bool isMoving = false;
    
    public AudioSource footstepAudioSource1;
    public AudioSource footstepAudioSource2;
    public AudioSource footstepAudioSource3;
    void Start()
    {
        
    }

    void Update()
    {
        heroAnimator.SetBool("isMoving", isMoving);
    }

    public void OnFootstep()
    {
        int randomIndex = Random.Range(1, 3);
        if (randomIndex == 1)
        {
            footstepAudioSource1.Play();
        }
        else if (randomIndex == 2)
        {
            footstepAudioSource2.Play();
        }
        else if (randomIndex == 3)
        {
            footstepAudioSource3.Play();
        }
        else
        {
            Debug.Log("No sound available to play");
                
        }
    }
}