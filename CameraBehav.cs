using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehav : MonoBehaviour {
    public Transform player,player2;
    public Transform enemy;
    public Vector3 offset;
    public PlayerHealth playerHealth, playerHealth2;
    // Use this for initialization
    public List<Transform> targets;
   public  void Awake () {
      playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth2 = player2.GetComponent<PlayerHealth>();
        
    }
	
	// Update is called once per frame
	public void LateUpdate ()
    {
        if (playerHealth.currentVida <= 0)
        {
            targets.Remove(player);
        }
        if (playerHealth2.currentVida <= 0)
        {
            targets.Remove(player2);
        }
        if (targets.Count == 0)
            return;
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = newPosition;
    }
    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i< targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
