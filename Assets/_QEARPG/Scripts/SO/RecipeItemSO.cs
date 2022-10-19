using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe Item", menuName = "Scriptable Objects/Recipe Item", order = 1)]
public class RecipeItemSO : ScriptableObject
{
    [SerializeField]
    private ItemSO _craftable;

    [SerializeField]
    private ItemSO[] _recipeItem = new ItemSO[9];

    public ItemSO[] RecipeItem { get => _recipeItem; }
    public ItemSO Craftable { get => _craftable; }
}

[CustomEditor(typeof(RecipeItemSO))]
public class CustomEditorItem : Editor
{
    private int _spriteWidth = 100;
    private int _spriteHeight = 100;

    public override void OnInspectorGUI()
    {
        var fieldItem = serializedObject.FindProperty("_item");
        var fieldRecipeItem = serializedObject.FindProperty("_recipeItem");

        var spriteItem = (ItemSO)fieldItem.objectReferenceValue;

        GUILayout.BeginArea(new Rect(new Vector2(400, 130), new Vector2(150, 150)));
        AddLabelImage(spriteItem?.Sprite);
        AddPropertyField(fieldItem);
        GUILayout.EndArea();

        int v = 0;

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < fieldRecipeItem.arraySize; i++)
        {
            var item = (ItemSO)fieldRecipeItem.GetArrayElementAtIndex(i).objectReferenceValue;

            AddLabelImage(item?.Sprite);

            if ((i + 1) % 3 == 0)
            {
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                for (int k = v; k < (v + 3); k++)
                {
                    AddPropertyField(fieldRecipeItem.GetArrayElementAtIndex(k));
                }
                v += 3;
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
            }
        }
    }

    private void AddLabelImage(Sprite sprite)
    {
        if (sprite != null)
        {
            GUILayout.Box(sprite.texture, GUILayout.Width(_spriteWidth), GUILayout.Height(_spriteHeight));
        }
        else
            GUILayout.Box(new Texture2D(_spriteWidth, _spriteHeight));
    }

    private void AddPropertyField(SerializedProperty property)
    {
        EditorGUILayout.PropertyField(property, new GUIContent(), GUILayout.Width(_spriteWidth));

        property.serializedObject.ApplyModifiedProperties();
    }
}
