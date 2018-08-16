using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNameObject : MonoBehaviour {

    float randomnum = 1;

    private Vector3 m_startPos;

    private void Start()
    {
        m_startPos = transform.localPosition;
    }

    private void Update()
    {
        float x = Random.Range(0, randomnum);
        float y = Random.Range(0, randomnum);
        transform.localPosition = m_startPos + new Vector3(x, y, 0.0f);
    }
}
