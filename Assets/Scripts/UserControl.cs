using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class UserControl : MonoBehaviour
{
    [SerializeField] GameObject markerPrefab;
    [SerializeField] private UnitMovement selectedUnit;
    [SerializeField] Camera GameCamera;

    // Start is called before the first frame update
    void Start()
    {
        markerPrefab.SetActive(false);
    }
    public void HandleSelection()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the unit, so we make sure to check in the parent
            var unit = hit.collider.GetComponentInParent<UnitMovement>();
            selectedUnit = unit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        MarkerHandling();
    }

    void MarkerHandling()
    {
        if (selectedUnit == null && markerPrefab.activeInHierarchy)
        {
            markerPrefab.SetActive(false);
            markerPrefab.transform.SetParent(null);
        }
        else if (selectedUnit != null && markerPrefab.transform.parent != selectedUnit.transform)
        {
            markerPrefab.SetActive(true);
            markerPrefab.transform.SetParent(selectedUnit.transform, false);
            markerPrefab.transform.localPosition = Vector3.zero;
        }
    }
}
