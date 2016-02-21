using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

    public Color highlightColor = Color.red;

    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }
    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }

    public void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
