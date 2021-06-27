using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFade : MonoBehaviour
{
    public bool animationEnd = false;
    private bool isBigtoSmall = true;
    private bool isSmalltoBig = true;
    public static CircleFade instance;
    private string sceneChange = string.Empty;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isBigtoSmall && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime * 12, transform.localScale.y - Time.deltaTime * 12);
            if(transform.localScale.x <= 0)
            {
                animationEnd = true;
                isBigtoSmall = true;
                gameObject.SetActive(false);
            }
        }

        if (!isSmalltoBig)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * 12, transform.localScale.y + Time.deltaTime * 12);
            if (transform.localScale.x >= 15)
            {
                animationEnd = true;
                isBigtoSmall = true;
                changeScene(sceneChange);
            }
        }
    }

    public void StartFade()
    {
        isBigtoSmall = false;
        animationEnd = false;
    }

    public void StartFadeOut(string scene)
    {
        gameObject.SetActive(true);
        isSmalltoBig = false;
        animationEnd = false;        
        sceneChange = scene;
    }

    private void changeScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
