using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAreaManager : MonoBehaviour
{
    public static WalkAreaManager Instance { get; private set; }

    public List<Floor> poolFloors = new List<Floor>();

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        foreach (Floor floor in Resources.LoadAll<Floor>("Floors"))
        {
            Floor tmp = Instantiate<Floor>(floor, Vector3.zero, gameObject.transform.rotation, gameObject.transform);
            poolFloors.Add(tmp);
            tmp.gameObject.SetActive(false);
        }
    }

    public void ShowFloorAfter(Floor after)
    {
        int id = Random.Range(0, WalkAreaManager.Instance.poolFloors.Count - 1);

        Floor floor = WalkAreaManager.Instance.poolFloors[id];
        WalkAreaManager.Instance.poolFloors.Remove(floor);
        floor.gameObject.SetActive(true);
        floor.transform.position = new Vector3(after.transform.position.x + floor.width, after.transform.position.y, 0);
        floor.Reset();
    }

    public void HideFloor(Floor floor)
    {
        poolFloors.Add(floor);
        floor.gameObject.SetActive(false);
    }
}
