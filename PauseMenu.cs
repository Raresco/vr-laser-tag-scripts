using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuUI;
    public bool pauseState;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        this.pauseState = false;
    }

    // Update is called once per frame
    void Updat()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            pauseMenuUI.SetActive(!pauseMenuUI.activeInHierarchy);
        }
    }
}
