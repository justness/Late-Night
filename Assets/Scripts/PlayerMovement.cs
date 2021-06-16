using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    readonly float speed = 0.07f;
    public GameObject alert;
    public Camera cam;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;

            if (transform.childCount > 1)
            {
                if (transform.GetChild(transform.childCount - 1).name == "Reflection") transform.GetChild(transform.childCount - 1).gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            transform.position = transform.position + new Vector3(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;

            if (transform.childCount > 1)
            {
                if (transform.GetChild(transform.childCount - 1).name == "Reflection") transform.GetChild(transform.childCount - 1).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.position = transform.position + new Vector3(-speed, 0, 0);
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(false);
        }
        alert.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.6f, 0));
    }
}
