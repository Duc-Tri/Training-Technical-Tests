using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SGTest
{
    public enum IngredientType : byte { NULL = 0, CAFE, SUCRE, CREME, THE, EAU, CHOCOLAT, LAIT }

    public enum RecetteType : byte { NULL = 0, EXPRESSO, ALLONGE, CAPUCCINO, CHOCOLAT, THE }

    public static class DataManager
    {
        // INGREDIENTS ========================================================

        private static readonly Dictionary<IngredientType, string> IngredientNoms = new Dictionary<IngredientType, string>() {
            {IngredientType.CAFE, "Café"},
            {IngredientType.SUCRE, "Sucre"},
            {IngredientType.CREME, "Crème"},
            {IngredientType.THE, "Thé"},
            {IngredientType.EAU, "Eau"},
            {IngredientType.CHOCOLAT, "Chocolat"},
            {IngredientType.LAIT, "Lait"}    };

        private static readonly Dictionary<IngredientType, decimal> IngredientPrix = new Dictionary<IngredientType, decimal>() {
            {IngredientType.CAFE, 1},
            {IngredientType.SUCRE, 0.1m},
            {IngredientType.CREME, 0.5m},
            {IngredientType.THE, 2},
            {IngredientType.EAU, 0.2m},
            {IngredientType.CHOCOLAT, 1},
            {IngredientType.LAIT, 0.4m}    };

        public static string NomIngredient(IngredientType it) => IngredientNoms[it];
        public static string PrixIngredient(IngredientType it) => IngredientPrix[it].ToString();


        // RECETTES ===========================================================

        private static readonly Dictionary<RecetteType, string> RecetteNoms = new Dictionary<RecetteType, string>() {
            {RecetteType.EXPRESSO, "Expresso"},
            {RecetteType.ALLONGE, "Allongé"},
            {RecetteType.CAPUCCINO, "Capuccino"},
            {RecetteType.CHOCOLAT, "Chocolat"},
            {RecetteType.THE, "Thé"}    };

        private static readonly Dictionary<RecetteType, Dictionary<IngredientType, int>> RecetteIngredients = new Dictionary<RecetteType, Dictionary<IngredientType, int>>() {
            {RecetteType.EXPRESSO, new Dictionary<IngredientType,  int>{
                { IngredientType.CAFE, 1},
                { IngredientType.EAU, 1},             } },

            {RecetteType.ALLONGE, new Dictionary<IngredientType,  int>{
                { IngredientType.CAFE, 1},
                { IngredientType.EAU, 2},             } },

            {RecetteType.CAPUCCINO, new Dictionary<IngredientType,  int>{
                { IngredientType.CAFE, 1} ,
                { IngredientType.CHOCOLAT, 1} ,
                { IngredientType.EAU, 1} ,
                { IngredientType.CREME, 1} ,             } },

            {RecetteType.CHOCOLAT, new Dictionary<IngredientType,  int>{
                { IngredientType.CHOCOLAT, 3},
                { IngredientType.LAIT, 2},
                { IngredientType.EAU, 1},
                { IngredientType.SUCRE, 1},            } },

            {RecetteType.THE, new Dictionary<IngredientType,  int>{
                { IngredientType.THE, 1},
                { IngredientType.EAU, 2},            } }
        };

        public static string NomRecette(RecetteType rt) => RecetteNoms[rt];

        internal static string DetailsRecette(RecetteType rt)
        {
            return RecetteNoms[rt].ToString() + string.Join(" # ", RecetteIngredients[rt]) + " Coût:" + PrixRecetteBrut(rt) + " euros";
        }

        public static Dictionary<RecetteType, Dictionary<IngredientType, int>> ToutesRecettes => RecetteIngredients;


        // PRIX ===============================================================

        private const decimal MARGE_POURCENT = 3m / 10m;

        public static decimal PrixRecetteBrut(RecetteType rt)
        {
            decimal prix = 0;
            foreach (var e in RecetteIngredients[rt])
            {
                prix += IngredientPrix[e.Key] * e.Value;
            }

            return prix;
        }

        public static decimal PrixRecetteAvecMarge(RecetteType rt)
        {
            decimal prix = PrixRecetteBrut(rt);
            return prix + prix * MARGE_POURCENT;
        }

        internal static string PrixFinalBoisson(RecetteType rt)
        {
            return RecetteNoms[rt].ToString() + " PRIX: " + PrixRecetteAvecMarge(rt) + " euros";
        }

    }

}
