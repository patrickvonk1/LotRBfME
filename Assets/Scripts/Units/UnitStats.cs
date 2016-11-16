using UnityEngine;
using System.Collections;

public class UnitStats : MonoBehaviour {
    public Renderer renderer;
    public int CurrentHealth;
    public int MaxHealth;

    public bool CanMove;
    public bool CanAttack;

    void OnMouseEnter()
    {
        renderer.material.shader = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
    }

    void OnMouseExit()
    {
        renderer.material.shader = Shader.Find("Yurowm/SkinShader");
    }
}
