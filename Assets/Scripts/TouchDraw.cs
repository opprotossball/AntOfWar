using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDraw : MonoBehaviour
{ 
    private Coroutine drawing;
    private LineRenderer line;
    [SerializeField] private GameObject LinePrefab;
    [SerializeField] private TrailManager TrailManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartLine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndLine();
        }
    }

    private void StartLine()
    {
        if(drawing != null) 
        {
            StopCoroutine(drawing);
        }
        GameObject go = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
        TrailManager.AddTrail(go);
        drawing = StartCoroutine(DrawLine(go));
    }

    private void EndLine()
    {
        StopCoroutine(drawing);
    }

    private IEnumerator DrawLine(GameObject go)
    {
        LineRenderer line = go.GetComponent<LineRenderer>();
        line.positionCount = 0;
        while(true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, pos);
            yield return null;
        }
    }
}
