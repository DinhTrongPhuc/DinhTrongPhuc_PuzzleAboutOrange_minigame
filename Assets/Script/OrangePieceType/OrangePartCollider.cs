using UnityEngine;
using System.Collections.Generic;

public class OrangePartCollider : MonoBehaviour
{
    public enum PartType { TopLeft, TopRight, BottomRight, BottomLeft }
    public PartType partType;

    private List<OrangePartCollider> touchingParts = new List<OrangePartCollider>();
    public bool IsInGroup => touchingParts.Count >= 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OrangePartCollider other = collision.GetComponent<OrangePartCollider>();
        if (other != null && !touchingParts.Contains(other))
        {
            touchingParts.Add(other);
            CheckForCompleteOrange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OrangePartCollider other = collision.GetComponent<OrangePartCollider>();
        if (other != null && touchingParts.Contains(other))
        {
            touchingParts.Remove(other);
        }
    }

    private void CheckForCompleteOrange()
    {
        OrangePartCollider[] allParts = FindObjectsOfType<OrangePartCollider>();

        List<OrangePartCollider> connectedGroup = new List<OrangePartCollider>();
        foreach (var part in allParts)
        {
            if (part.IsInGroup)
            {
                connectedGroup.Add(part);
            }
        }

        if (connectedGroup.Count >= 4)
        {
            HashSet<PartType> types = new HashSet<PartType>();
            foreach (var p in connectedGroup)
                types.Add(p.partType);

            if (types.Count == 4)
            {
                GameManager.Instance.OnCompleteOrange(connectedGroup);
            }
        }
    }
}
