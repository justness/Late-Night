using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    GameObject map;
    GameObject pause;
    public ParticleSystem rain;
    public PlayerMovement pm;

    void Start()
    {
        if (transform.childCount > 5)
        {
            map = transform.GetChild(4).gameObject;
            pause = transform.GetChild(5).gameObject;
        }

        if (transform.GetChild(0).gameObject.name == "Time") transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = Conditions.time;

        int n = 0;
        foreach (int c in Conditions.conditions)
        {
            if (c == 1)
            {
                transform.GetChild(3).GetChild(n).gameObject.SetActive(true);
            }
            n++;
        }
    }

    void Update()
    {
        if (map && Input.GetKeyDown(KeyCode.M))
        {
            map.SetActive(!map.activeSelf);
        }
        if (pause && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)))
        {
            pause.SetActive(!pause.activeSelf);
            if (pause.activeSelf)
            {
                rain.Pause();
                if (pm) pm.enabled = false;
            }
            else
            {
                rain.Play();
                if (pm) pm.enabled = true;
            }

            // TODO: Pause animations in scene.
        }
    }

    public void RestartScene()
    {
        Conditions.conditions = new int[14];
        Conditions.time = "19 00";
        SceneManager.LoadScene("Office");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
