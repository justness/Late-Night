using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Item : MonoBehaviour
{
    public TextMeshProUGUI descriptBox;
    public GameObject alert;
    bool interactable = false;

    string[][] description = new string[3][];
    public string[] altDescript0;
    public string[] altDescript1;
    public string[] altDescript2;
    public bool alt1;
    public bool alt2;
    public GameObject[] items;
    public GameObject waterfront;

    int altDescript = 0; // Which set of lines?
    int currentDescript = 0; // Which line?

    private void Start()
    {
        description[0] = altDescript0;
        description[1] = altDescript1;
        description[2] = altDescript2;
    }

    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.Space))
        {
            float height = 2.5f;
            if (transform.position.y < -1.5f) height = 1.25f;
            else if (transform.position.y < 0.5f) height = 1.75f;
            descriptBox.gameObject.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, height, transform.position.z));

            if (currentDescript < description[altDescript].Length)
            {
                if (alt1 && !alt2 && currentDescript == 0) altDescript = 1;
                if (alt2 && currentDescript == 0) altDescript = 2;
                descriptBox.text = description[altDescript][currentDescript];
                if (currentDescript == description[altDescript].Length - 1 && items.Length >= altDescript + 1)
                {
                    if (items[altDescript] != null)
                    {
                        items[altDescript].SetActive(true);
                        if (items[altDescript].name == "Waterfront") waterfront.SetActive(true);
                    }
                }
                currentDescript++;
            }
            else
            {
                descriptBox.text = "";
                currentDescript = 0;
                Conditions.interactions++;

                if (Conditions.conditions[11] == 1 && Conditions.time == "20 00")
                {
                    Conditions.time = "21 00";
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name.TrimEnd('1') + "2");
                }
            }
        }

        if (Conditions.interactions == 30 && Conditions.time != "21 00")
        {
            if (Conditions.time == "19 00")
            {
                Conditions.time = "20 00";
                SceneManager.LoadScene(SceneManager.GetActiveScene().name + "1");
                Conditions.interactions = 0;
            }
            else if (Conditions.time == "20 00")
            {
                Conditions.time = "21 00";
                SceneManager.LoadScene(SceneManager.GetActiveScene().name.TrimEnd('1') + "2");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        interactable = true;
        alert.SetActive(true);
        alert.GetComponent<TextMeshProUGUI>().text = name;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        descriptBox.text = "";
        currentDescript = 0;
        interactable = false;
        alert.SetActive(false);
    }
}
