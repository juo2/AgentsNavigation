using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ProjectDawn.Navigation.Sample.Zerg
{
    public class SelectionCircle : MonoBehaviour
    {
        public Mesh Mesh;
        public Material Material;
        public Material EnemyMaterial;
        public float3 Offset;

        public static SelectionCircle instance { get; private set; }


        private void Awake()
        {
            instance = this;
        }

        public void Draw(float3 position, float scale)
        {
            Graphics.DrawMesh(Mesh, Matrix4x4.TRS(position + Offset, quaternion.RotateX(math.radians(90)), Vector3.one * scale), Material, 0);
        }

        public void DrawEnemy(float3 position, float scale)
        {
            Graphics.DrawMesh(Mesh, Matrix4x4.TRS(position + Offset, quaternion.RotateX(math.radians(90)), Vector3.one * scale), EnemyMaterial, 0);
        }
    }
}
