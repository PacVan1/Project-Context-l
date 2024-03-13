using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public int value;
    public int lastIndex;
    public List<Component> components = new List<Component>();
    public List<bool> connectedToAOrB = new List<bool>(); // true is a, false is b

    [SerializeField] GameObject sourcePrefab;
    public GameObject source;

    public void Start()
    {
        source = Instantiate(sourcePrefab, new Vector3(-3.47f, Random.Range(0f, 2f), 0), Quaternion.identity);
        GameManager.mouseDatas.Add(this);
    }
}
