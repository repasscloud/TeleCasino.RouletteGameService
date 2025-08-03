namespace TeleCasino.RouletteGameService.Models;

public static class RouletteProperties
{
    public static readonly Dictionary<int, (string Color, int Column, int? Dozen, bool? Odd, bool? Low)> NumberProps = new()
    {
        [0] =  ("green", 0, null, null, null),
        [1] =  ("red",   1, 1, true,  true),
        [2] =  ("black", 2, 1, false, true),
        [3] =  ("red",   3, 1, true,  true),
        [4] =  ("black", 1, 1, false, true),
        [5] =  ("red",   2, 1, true,  true),
        [6] =  ("black", 3, 1, false, true),
        [7] =  ("red",   1, 1, true,  true),
        [8] =  ("black", 2, 1, false, true),
        [9] =  ("red",   3, 1, true,  true),
        [10] = ("black", 1, 1, false, true),
        [11] = ("black", 2, 1, true,  true),
        [12] = ("red",   3, 1, false, true),
        [13] = ("black", 1, 2, true,  true),
        [14] = ("red",   2, 2, false, true),
        [15] = ("black", 3, 2, true,  true),
        [16] = ("red",   1, 2, false, true),
        [17] = ("black", 2, 2, true,  true),
        [18] = ("red",   3, 2, false, true),
        [19] = ("red",   1, 2, true,  false),
        [20] = ("black", 2, 2, false, false),
        [21] = ("red",   3, 2, true,  false),
        [22] = ("black", 1, 2, false, false),
        [23] = ("red",   2, 2, true,  false),
        [24] = ("black", 3, 2, false, false),
        [25] = ("red",   1, 3, true,  false),
        [26] = ("black", 2, 3, false, false),
        [27] = ("red",   3, 3, true,  false),
        [28] = ("black", 1, 3, false, false),
        [29] = ("black", 2, 3, true,  false),
        [30] = ("red",   3, 3, false, false),
        [31] = ("black", 1, 3, true,  false),
        [32] = ("red",   2, 3, false, false),
        [33] = ("black", 3, 3, true,  false),
        [34] = ("red",   1, 3, false, false),
        [35] = ("black", 2, 3, true,  false),
        [36] = ("red",   3, 3, false, false)
    };

    public static readonly HashSet<int> RedNumbers = new() { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

    public static readonly HashSet<int> BlackNumbers = new() { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
    
    public static readonly Dictionary<string, int> BetPayouts = new()
    {
        {"straight", 35}, {"split", 17}, {"street", 11}, {"corner", 8}, {"sixline", 5},
        {"trio", 11}, {"basket", 8},
        {"col1", 2}, {"col2", 2}, {"col3", 2},
        {"_1st12", 2}, {"_2nd12", 2}, {"_3rd12", 2},
        {"red", 1}, {"black", 1}, {"odd", 1}, {"even", 1}, {"low", 1}, {"high", 1}
    };
}
