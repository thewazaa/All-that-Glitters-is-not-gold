using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAreaManager : MonoBehaviour
{
    public static WalkAreaManager Instance { get; private set; }

    public List<Floor> listFloors = new List<Floor>();

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
            listFloors.Add(floor);
    }

    public void ChangeHowItIsSeen()
    {
        foreach (Floor floor in FindObjectsOfType<Floor>())
            floor.ChangeHowItIsSeen();
    }

    public void ShowFloorAfter(Floor after)
    {
        int id = Random.Range(1, listFloors.Count); // Floor 1 = tutorial. Avoid it

        Floor floor = Instantiate<Floor>(WalkAreaManager.Instance.listFloors[id]);
        floor.gameObject.transform.parent = transform;
        floor.transform.position = new Vector3(after.transform.position.x + floor.width, after.transform.position.y, 0);
    }
}
