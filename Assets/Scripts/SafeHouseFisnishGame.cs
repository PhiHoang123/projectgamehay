using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SafeHouseFisnishGame : MonoBehaviour
{
    AudioSource safeDoorAudio;

    public Text endGameText;
    public RestartGame theGameController;

    bool insafe = false;

    // Start is called before the first frame update
    void Start()
    {
        safeDoorAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && insafe == false)
        {
            Animator safeDoorAnim = GetComponentInChildren<Animator>();
            safeDoorAnim.SetTrigger("safeHouseTrigger");
            safeDoorAudio.Play();
            endGameText.text = "You Survive";
            Animator endGameAnim = endGameText.GetComponent<Animator>();
            endGameAnim.SetTrigger("endGame");
            theGameController.restartTheGame();
            insafe = true;

        }
    }

}
