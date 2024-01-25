using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] GameObject highlighter;

    GameObject currentTarget;

    public void Highlight(GameObject target)
    {
        if (currentTarget == target) {
            return;
        }
        Vector3 position = target.transform.position;
        Highlight(position);
    }

    public void Highlight(Vector3 position)
    {
        highlighter.SetActive(true);
        highlighter.transform.position = new Vector3(position.x, position.y + 0.50f);
    }

    public void Hide()
    {
        currentTarget = null;
        highlighter.SetActive(false);
    }
}
