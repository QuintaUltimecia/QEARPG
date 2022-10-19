using UnityEngine;
using System.Collections.Generic;

namespace QEARPG
{
    public static class GameCache
    {
        //Prefabs
        public readonly static UI.Item ItemUIPrefab = Resources.Load<UI.Item>("Item");

        //Game objects
        public readonly static Canvas Canvas = GameObject.FindObjectOfType<Canvas>();

        //Items
        public static ItemSO Rock = Resources.Load<ItemSO>("Items/Rock");
        public static ItemSO Stick = Resources.Load<ItemSO>("Items/Stick");

        //Recipes
        public static RecipeItemSO Axe = Resources.Load<RecipeItemSO>("Recipes/Axe");
        public static RecipeItemSO Sword = Resources.Load<RecipeItemSO>("Recipes/Sword");

        public static List<ItemSO> Items = new List<ItemSO>() { Rock, Stick };
        public static List<RecipeItemSO> Recipes = new List<RecipeItemSO>() { Axe, Sword };
    }
}
