using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakBlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            Vector3 cellWordPosition = other.transform.position;
            Vector3 cellMapPosition = GetComponent<Tilemap>().WorldToCell(cellWordPosition);
            Vector3Int tilePosition = new Vector3Int((int)cellMapPosition.x, (int)cellMapPosition.y, (int)cellMapPosition.z);
            Destroy(other.gameObject);
            GetComponent<Tilemap>().SetTile(tilePosition, null);
            //Destroy(GetComponent<Tilemap>().GetTile(tilePosition));
        }
    }
}