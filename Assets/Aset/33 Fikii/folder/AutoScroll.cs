using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AutoScroll : MonoBehaviour
{
    float speed = 100.0f;
    float textPosBegin = -454.0f;
    float boundaryTextEnd = -454.0f;

    RectTransform myGorectTransform;
    [SerializeField]
    TextMeshProUGUI mainText;

    [SerializeField]
    bool isLooping = false;
    // Start is called before the first frame update
    void Start()
    {
        myGorectTransform =gameObject.GetComponent<RectTransform>();
    }

        IEnumerator AutoScrollText()
        {
            while(myGorectTransform.localPosition.y< boundaryTextEnd)
            {
                myGorectTransform.Tranlate(Vector3.up * speed * Time.deltaTime);
                yield return null;
            }
        }
}
