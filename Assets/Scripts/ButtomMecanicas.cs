using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtomMecanicas : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => {
            CircleFade.instance.StartFadeOut("Mecanicas");
        });
    }

    private void Start()
    {
        CircleFade.instance.StartFade();
    }
}
