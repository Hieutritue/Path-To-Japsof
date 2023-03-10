using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float transitionDelay = 3.0f;

    // void Start()
    // {
        
        
    // }

    // // Update is called once per frame
    public void NextLevel()
    {
        StartCoroutine(DelayedTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReloadCurrentLevel()
    {   
        StartCoroutine(DelayedTransition(SceneManager.GetActiveScene().buildIndex));
    }
    public void LoadLevel(int level)
    {
         StartCoroutine(DelayedTransition(level));
    }
    IEnumerator DelayedTransition(int index)
    {
        //CheckpointManager.SetCheckpoint(GameObject.FindGameObjectWithTag("Player").transform.position);
        anim.SetTrigger("triggertransition");

        yield return new WaitForSeconds(transitionDelay); // cho mot chut roi moi chay scene moi

        SceneManager.LoadScene(index);
    }
}