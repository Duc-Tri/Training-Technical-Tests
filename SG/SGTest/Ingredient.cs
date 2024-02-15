using System;
using System.Collections.Generic;

namespace SGTest
{
    public enum IngredientType : byte { NULL = 0, CAFE, SUCRE, CREME, THE, EAU, CHOCOLAT, LAIT }

    internal class Ingredient
    {
        IngredientType type;
        decimal prix;
    }
}
