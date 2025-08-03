namespace TeleCasino.RouletteGameService.Models;

public enum RouletteBetType
{
    //n
    n0, n1, n2, n3, n4, n5, n6, n7, n8, n9,
    n10, n11, n12, n13, n14, n15, n16, n17, n18, n19,
    n20, n21, n22, n23, n24, n25, n26, n27, n28, n29,
    n30, n31, n32, n33, n34, n35, n36,

    // trio
    trio12, // 0,1,2
    trio23, // 0,2,3

    // horizontal splits (left-right)
    split_1_2,   split_2_3,   split_4_5,
    split_5_6,   split_7_8,   split_8_9,
    split_10_11, split_11_12, split_13_14,
    split_14_15, split_16_17, split_17_18,
    split_19_20, split_20_21, split_22_23,
    split_23_24, split_25_26, split_26_27,
    split_28_29, split_29_30, split_31_32,
    split_32_33, split_34_35, split_35_36,

    // vertical splits (up-down):
    split_1_4,   split_2_5,   split_3_6,
    split_4_7,   split_5_8,   split_6_9,
    split_7_10,  split_8_11,  split_9_12,
    split_10_13, split_11_14, split_12_15,
    split_13_16, split_14_17, split_15_18,
    split_16_19, split_17_20, split_18_21,
    split_19_22, split_20_23, split_21_24,
    split_22_25, split_23_26, split_24_27,
    split_25_28, split_26_29, split_27_30,
    split_28_31, split_29_32, split_30_33,
    split_31_34, split_32_35, split_33_36,

    // street (lowest number in each row of 3)
    street_1, street_4, street_7, street_10, street_13, street_16,
    street_19, street_22, street_25, street_28, street_31, street_34,

    // corner
    corner_1_2_4_5,     corner_2_3_5_6,     corner_4_5_7_8,     corner_5_6_8_9, corner_7_8_10_11,
    corner_8_9_11_12,   corner_10_11_13_14, corner_11_12_14_15, corner_13_14_16_17,
    corner_14_15_17_18, corner_16_17_19_20, corner_17_18_20_21, corner_19_20_22_23,
    corner_20_21_23_24, corner_22_23_25_26, corner_23_24_26_27, corner_25_26_28_29,
    corner_26_27_29_30, corner_28_29_31_32, corner_29_30_32_33, corner_31_32_34_35,
    corner_32_33_35_36,

    // six line (double street)
    sixline_1,  sixline_4,  sixline_7,  sixline_10,
    sixline_13, sixline_16, sixline_19, sixline_22,
    sixline_25, sixline_28, sixline_31,

    // basket
    basket, // 0,1,2,3

    // columns
    col1,  // 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34
    col2,  // 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35
    col3,  // 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36

    // dozens
    _1st12,
    _2nd12,
    _3rd12,

    // even / odd
    red, black,
    odd, even,
    low, high
}