using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrolling = 0f;


    [SerializeField] private GameObject skyPrefab;

    private float xExtent;
    private List<GameObject> _listOfSkyPrefabsInScene;

    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        Transform firstChild = transform.GetChild(0);

        float xMinPrefabExtent = firstChild.GetChild(0).GetComponent<MeshRenderer>().bounds.max.x;
        float xMaxPrefabExtent =
            firstChild.GetChild(firstChild.childCount - 1).GetComponent<MeshRenderer>().bounds.min.x;

        xExtent = xMinPrefabExtent - xMaxPrefabExtent;
    }


    // A FUCKING GOOD WAY THAT DOESNT WORK BECAUSE OF THE WEIRD WAY THE SCENE WAS MODELED :'(
    //void Update()
    //{
    //    //this.transform.GetComponent<Rigidbody2D>().velocity	= new Vector2 (scrolling, 0); 

    //    foreach (Transform aChildTransform in transform)
    //    {
    //        Material material = aChildTransform.GetComponent<MeshRenderer>().material;
    //        Vector2 currentOffest = material.mainTextureOffset;
    //        currentOffest += Vector2.left * scrolling * Time.deltaTime;
    //        material.mainTextureOffset = currentOffest;
    //    }
    //}
    public void GenerateANewSkyPlan()
    {
         //Instantiate()
    }
}