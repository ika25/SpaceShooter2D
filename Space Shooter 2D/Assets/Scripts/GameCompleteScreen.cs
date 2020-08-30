using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCompleteScreen : MonoBehaviour
{
    //Veriables
    public float timeBetweenTexts;//How long it takes for each txt appearing.
    public bool canExit;//we only want to be able to press any key when message appears.
    public string mainMenuName = "MainMenu";
    public Text message, score, pressKey;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowTextCo());
    }

    // Update is called once per frame
    void Update()
    {
        if(canExit && Input.anyKeyDown)
        {
            SceneManager.LoadScene(mainMenuName);//load to main menue
        }
    }

    //veriable functions
    public IEnumerator ShowTextCo()
    {
        yield return new WaitForSeconds(timeBetweenTexts);
        message.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeBetweenTexts);
        score.text = "Final Score " + PlayerPrefs.GetInt("currentScore");//This will update the score that shows when we get end of the game.
        score.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeBetweenTexts);
        pressKey.gameObject.SetActive(true);
        canExit = true;

    }
}
