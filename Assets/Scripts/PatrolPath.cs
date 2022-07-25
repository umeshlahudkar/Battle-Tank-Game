using UnityEngine;


/// <summary>
/// To Show WayPoints In Editor mode
/// </summary>
public class PatrolPath : MonoBehaviour
{
    int j = 0;
    private void OnDrawGizmos()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawSphere(transform.GetChild(i).position , 1f);
            j = i + 1;
            if (j == transform.childCount)
            {
                j = 0;
            }
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(j).position);
        }
        
    }

}
