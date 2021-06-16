using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject arrow;
    TextMeshProUGUI locationName;
    public string nextScene;

    void Start()
    {
        arrow = transform.parent.GetChild(0).gameObject;
        locationName = transform.parent.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        // TODO: If character is at this location, disable this game object.
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        arrow.SetActive(true);
        arrow.GetComponent<RectTransform>().localPosition = GetComponent<RectTransform>().localPosition + new Vector3(0, 65, 0);
        locationName.text = name.TrimEnd('1','2');
    }

    public void OnPointerExit (PointerEventData eventdata)
    {
        arrow.SetActive(false);
        locationName.text = "";
    }

    public void LoadLocation()
    {
        SceneManager.LoadScene(nextScene);
    }
}
