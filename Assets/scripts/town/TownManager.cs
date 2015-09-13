using config;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public void OnAddTown()
    {
        GameObject floor = GameObject.Instantiate(Resources.Load("floors/Town", typeof(GameObject))) as GameObject;
        floor.transform.SetParent(transform);
        floor.transform.localScale = Vector3.one;
        floor.transform.localPosition = Positions.CENTER;
    }
}
