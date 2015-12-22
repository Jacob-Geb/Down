using UnityEngine;
using System.Collections;

public class StretchScript : MonoBehaviour {

	void Start () {
        GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);

        GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        transform.localScale = Vector3.one;
	}
}
