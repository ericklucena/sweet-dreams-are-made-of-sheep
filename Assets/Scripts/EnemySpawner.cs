using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject ObjectToSpawn;
	public UnityEngine.Events.UnityEvent OnSpawn;
	public int RandomVariation = 1;
	public int TopPositionToSpawn = 9;

	private void Start()
	{
	}

	public void Spawn()
	{
		List<GameObject> objects = GameObject.FindGameObjectsWithTag("Obstacle").ToList();
        List<GameObject> sheep = GameObject.FindGameObjectsWithTag("Sheep").ToList();

		if (sheep != null)
			objects.AddRange(sheep);
        
		System.Random rnd = new System.Random();
		int xposition = rnd.Next(-RandomVariation, RandomVariation);
		float realPosition = 0;

		switch (xposition)
		{
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

        float xPosition = realPosition;
        float yPosition = TopPositionToSpawn;

		foreach (GameObject go in objects)
		{
			var meshFilter = go.GetComponent<Collider2D>();
			if ((go.transform.position.y + (meshFilter.bounds.size.y / 2) >= yPosition)
                && (go.transform.position.y - (meshFilter.bounds.size.y / 2) <= yPosition)
                && (go.transform.position.x + (meshFilter.bounds.size.x / 2) >= xPosition)
               && (go.transform.position.x - (meshFilter.bounds.size.x / 2) <= xPosition))
			{
				yPosition += meshFilter.bounds.size.y + 1;
			}
		}

        Vector3 position = new Vector3(xPosition, yPosition, 0);

		var obj = GameObject.Instantiate(ObjectToSpawn, position, ObjectToSpawn.transform.rotation);
		OnSpawn.Invoke();
	}
}