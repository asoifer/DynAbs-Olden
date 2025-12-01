using System;
using System.Collections.Generic;
using System.Text;

public partial class Village
{
    //
    // Create a set of villages.  Villages are represented as a quad tree.
    // Each village contains references to four other villages.  Users
    // specify the number of levels.
    //
    // @param level the number of level of villages.
    // @param label a unique label for the village
    // @param back  a link to the "parent" village
    // @param seed  the user supplied seed value.
    // @return the village that was created
    //
    public static Village createVillage(int level, int label, Village back, int seed)
    {
        if (level == 0)
            return null;
        else
        {
            Village village = new Village(level, label, back, seed);
            for (int i = 3; i >= 0; i--)
            {
                Village child = createVillage(level - 1, (label * 4) + i + 1, village, seed);
                village.addVillage(i, child);
            }
            return village;
        }
    }
}
