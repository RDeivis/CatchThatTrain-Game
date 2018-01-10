using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {

	[SerializeField]
	float xPos = 0.3f;
	[SerializeField]
	int chunkSize = 128;
	[SerializeField]
	int chunkSizeY = 100;
	[SerializeField]
	float chunkDetailToSize = 10f;
	[SerializeField]
	int loadChunks = 3;
	[SerializeField]
	float scale = 3f;
	[SerializeField]
	float heightMultiplier = 5f;
	[SerializeField]
	float roadHeight = 0.1f;
	[SerializeField]
	float mapScale = 1f;
	[SerializeField]
	Material ground;
	[SerializeField]
	Material pavement;
	[SerializeField]
	GameObject MeshMapGround;
	[SerializeField]
	GameObject MeshMapPavement;

	public void ChangeMapScale(){
		if (MeshMapGround != null && MeshMapPavement != null) {
			MeshMapGround.transform.localScale = new Vector3 (mapScale, mapScale, 1f);
			MeshMapPavement.transform.localScale = new Vector3 (mapScale, mapScale, 1f);
		}
	}

	public void GeneratePavementMesh(){
		Debug.Log ("<color=green>Generate Pavement mesh!</color>");

		if (MeshMapPavement != null) {
			DestroyImmediate (MeshMapPavement);
		}

		MeshMapPavement = new GameObject ("MeshPavementMap");

		for (int i = 0; i < loadChunks; i++) {

			Vector3[] vertices = new Vector3[chunkSize * 2];
			Vector2[] edgeColliderVertices = new Vector2[chunkSize];
			Vector2[] uvs = new Vector2[chunkSize * 2];
			int[] triangles = new int[(chunkSize - 1) * (2-1) * 6];
			int triIndex = 0;

			for (int x = 0; x < chunkSize; x++) {
				for (int y = 0; y < 2; y++) {
					float noise = Mathf.PerlinNoise (xPos, (x + ((chunkSize - 1) * i)) / (scale * chunkDetailToSize)) * heightMultiplier;
					if (y == 0) {
						vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise - roadHeight, 0);
						edgeColliderVertices [x] = new Vector2 (x / chunkDetailToSize, noise - roadHeight);
						uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, 0);
					} else {
						vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise + roadHeight, 0);
						uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, 1);
					}

					if (i == 0 && x <= 100) {
						float noise2 = Mathf.PerlinNoise (xPos, (101 + ((chunkSize - 1) * i)) / (scale * chunkDetailToSize)) * heightMultiplier;
						if (y == 0) {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise2 - roadHeight, 0);
							edgeColliderVertices [x] = new Vector2 (x / chunkDetailToSize, noise2 - roadHeight);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, 0);
						} else {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise2 + roadHeight, 0);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, 1);
						}
					} else if (i == loadChunks-1) {
						float noise3 = Mathf.PerlinNoise (xPos, ((chunkSize-1) + ((chunkSize - 1) * (i-1))) / (scale * chunkDetailToSize)) * heightMultiplier;
						if (y == 0) {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise3 - roadHeight, 0);
							edgeColliderVertices [x] = new Vector2 (x / chunkDetailToSize, noise3 - roadHeight);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, 0);
						} else {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise3 + roadHeight, 0);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, 1);
						}
					}


					if (x < (chunkSize - 1) && y < (2 - 1)) {
						triangles [triIndex] = y * chunkSize + x;
						triangles [triIndex + 1] = (y + 1) * chunkSize + (x + 1);
						triangles [triIndex + 2] = (y + 1) * chunkSize + x;

						triangles [triIndex + 3] = (y + 1) * chunkSize + (x + 1);
						triangles [triIndex + 4] = y * chunkSize + x;
						triangles [triIndex + 5] = y * chunkSize + (x + 1);

						triIndex += 6;
					}
				}
			}

			GameObject chunk = new GameObject ("chunk " + i);

			Mesh mesh = new Mesh ();
			mesh.vertices = vertices;
			mesh.uv = uvs;
			mesh.triangles = triangles;
			mesh.RecalculateBounds ();
			mesh.RecalculateNormals ();

			chunk.AddComponent<MeshFilter> ().sharedMesh = mesh;
			chunk.AddComponent<MeshRenderer> ().sharedMaterial = pavement;
			chunk.AddComponent<EdgeCollider2D> ().points = edgeColliderVertices;
			chunk.tag = "Collidable";

			chunk.transform.parent = MeshMapPavement.transform;
			chunk.transform.rotation = new Quaternion (180f, 0, 0, 0);
			chunk.transform.position = new Vector3 (i * (chunkSize - 1) / chunkDetailToSize, 0, 0);
		}
	}

	public void GenerateGroundMesh(){
		Debug.Log ("<color=green>Generate Ground mesh!</color>");

		if (MeshMapGround != null) {
			DestroyImmediate (MeshMapGround);
		}

		MeshMapGround = new GameObject ("MeshGroundMap");

		for (int i = 0; i < loadChunks; i++) {

			Vector3[] vertices = new Vector3[chunkSize * chunkSizeY];
			Vector2[] uvs = new Vector2[chunkSize * chunkSizeY];
			int[] triangles = new int[(chunkSize - 1) * (chunkSizeY-1) * 6];
			int triIndex = 0;

			for (int x = 0; x < chunkSize; x++) {
				for (int y = 0; y < chunkSizeY; y++) {
					float noise = Mathf.PerlinNoise (xPos, (x + ((chunkSize - 1) * i)) / (scale * chunkDetailToSize)) * heightMultiplier;
					if (y == 0) {
						vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise, 0);
						uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, noise);
					} else if (y > noise) {
						vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, y, 0);
						uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, y);
					} else {
						vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise, 0);
						uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, noise);
					}

					if (i == 0 && x <= 100) {
						float noise2 = Mathf.PerlinNoise (xPos, (101 + ((chunkSize - 1) * i)) / (scale * chunkDetailToSize)) * heightMultiplier;
						if (y == 0) {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise2, 0);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, noise2);
						} else if (y > noise2) {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, y, 0);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, y);
						} else {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise2, 0);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, noise2);
						}

					} else if (i == loadChunks-1) {
						float noise3 = Mathf.PerlinNoise (xPos, ((chunkSize - 1) + ((chunkSize - 1) * (i - 1))) / (scale * chunkDetailToSize)) * heightMultiplier;
						if (y == 0) {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise3, 0);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, noise3);
						} else if (y > noise3) {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, y, 0);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, y);
						} else {
							vertices [y * chunkSize + x] = new Vector3 (x / chunkDetailToSize, noise3, 0);
							uvs [y * chunkSize + x] = new Vector2 (x / chunkDetailToSize, noise3);
						}

					}

					if (x < (chunkSize - 1) && y < (chunkSizeY - 1)) {
						triangles [triIndex] = y * chunkSize + x;
						triangles [triIndex + 1] = (y + 1) * chunkSize + (x + 1);
						triangles [triIndex + 2] = (y + 1) * chunkSize + x;

						triangles [triIndex + 3] = (y + 1) * chunkSize + (x + 1);
						triangles [triIndex + 4] = y * chunkSize + x;
						triangles [triIndex + 5] = y * chunkSize + (x + 1);

						triIndex += 6;
					}
				}
			}

			GameObject chunk = new GameObject ("chunk " + i);

			Mesh mesh = new Mesh ();
			mesh.vertices = vertices;
			mesh.uv = uvs;
			mesh.triangles = triangles;
			mesh.RecalculateBounds ();
			mesh.RecalculateNormals ();

			chunk.AddComponent<MeshFilter> ().sharedMesh = mesh;
			chunk.AddComponent<MeshRenderer> ().sharedMaterial = ground;

			chunk.transform.parent = MeshMapGround.transform;
			chunk.transform.rotation = new Quaternion (180f, 0, 0, 0);
			chunk.transform.position = new Vector3 (i * (chunkSize - 1) / chunkDetailToSize, 0, 0.01f);
		}
	}
}
