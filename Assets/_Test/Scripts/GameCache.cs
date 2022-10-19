using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QEARPG.Test
{
    public class GameCache : MonoBehaviour
    {
        public UI.Item ItemUIPrefab;

        public int RecipesCount = 1000;

        public List<RecipeItemSO> Recipes = new List<RecipeItemSO>();

        public void Awake()
        {
            for (int i = 0; i < RecipesCount; i++)
            {
                Recipes.Add(Resources.Load<RecipeItemSO>($"Test/Recipe Item ({i})"));
            }
        }
    }
}
