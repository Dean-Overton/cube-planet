using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
 {
     [SerializeField] public Transform[] Points;
 
     public enum FollowType
     {
         MoveTowards,
         Lerp
     }
     
     public FollowType Type = FollowType.MoveTowards;
     public float Speed = 1;
     public float MaxDistanceToGoal = .1f;
     
     private int _currentPointIndex;
     private int _direction;
     
     public void Start()
     {
         if (Points.Length > 1 == false)
         {
             Debug.LogError("You must specify at least 2 points for path", gameObject);
             return;
         }            
 
         _direction = 1;
         _currentPointIndex = 0;
         transform.position = Points[0].position;
     }
     
     public void Update()
     {
         if (Points.Length > 1 == false)
             return;
         
         if (Type == FollowType.MoveTowards)
             transform.position = Vector3.MoveTowards(transform.position, Points[_currentPointIndex].position, Time.deltaTime * Speed);
         else if (Type == FollowType.Lerp)
             transform.position = Vector3.Lerp(transform.position, Points[_currentPointIndex].position, Time.deltaTime * Speed);
         
         int nextPointIndex = GetNextPointIndex();
         float distanceToGoal = (Points[nextPointIndex].position - transform.position).sqrMagnitude;
 
         if (distanceToGoal < MaxDistanceToGoal * MaxDistanceToGoal )
         {
             _currentPointIndex = nextPointIndex;
         }
     }
 
     public void OnDrawGizmos()
     {
         if (Points == null || Points.Length < 2)
             return;
         
         for (var i = 1; i < Points.Length; i++)
         {
             Gizmos.DrawLine(Points[i - 1].position, Points[i].position);
         }
     }
 
     private int GetNextPointIndex()
     {
         //check if you are at end of array, go to start if yes
         if (_currentPointIndex == Points.Length - 1)
             return 0;
 
         //else return next point
         return _currentPointIndex + 1;
     }
}
