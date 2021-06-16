using System.Collections;
using UnityEngine;

public class DarkController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(Fade());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(Appear());
        }
    }

    IEnumerator Fade()
    {
        for (float ft = 0.7f; ft >= 0; ft -= 0.015f)
        {
            Color c = GetComponent<SpriteRenderer>().color;
            c.a = ft;
            GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
    }
    IEnumerator Appear()
    {
        for (float ft = 0; ft <= 0.7f; ft += 0.015f)
        {
            Color c = GetComponent<SpriteRenderer>().color;
            c.a = ft;
            GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
    }
}
