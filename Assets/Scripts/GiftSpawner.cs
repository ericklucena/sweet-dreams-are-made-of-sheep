using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
	public GameObject ObjectToSpawn;
	public UnityEngine.Events.UnityEvent OnSpawn;
    public int RandomVariation;
    public int TopPositionToSpawn;

    private void Start()
    {
        RandomVariation = 1;
        TopPositionToSpawn = 9;
    }

    public void Spawn()
    {       
        List<GameObject> objects = GameObject.FindGameObjectsWithTag("Obstacle").ToList();

		System.Random rnd = new System.Random();
        int xposition = rnd.Next(-RandomVariation, RandomVariation);
        float realPosition = 0;

        switch(xposition){
            case 1:
                realPosition = GameController.Instance.XRight;
                break;
             case 0:
                realPosition = GameController.Instance.XCenter;
                break;
             case -1:
                realPosition = GameController.Instance.XLeft;
                break;
        }

        Vector3 position = new Vector3(realPosition, TopPositionToSpawn, 0);

        foreach(GameObject go in objects){
            var meshFilter = go.transform.GetComponent<Collider2D>();
            if (go.transform.position.Equals(position)
                || (go.transform.position.x.Equals(position.x) 
                    && (go.transform.position.y + (meshFilter.bounds.size.y /2)) >= position.y )){
                position.y = (go.transform.position.y + (meshFilter.bounds.size.y / 2)) + 5;
            }
        }

        var obj = GameObject.Instantiate(ObjectToSpawn, position, ObjectToSpawn.transform.rotation);
        OnSpawn.Invoke();
    }
}