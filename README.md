# TeleCasino Roulette Game

A command-line Roulette spin animation and result generator built with .NET.  
Users place bets on single numbers, splits, corners, columns, dozens, colors, parity, high/low, basket, or trios, and receive an animated video of the spin plus a JSON summary.

---

## Features

- **Animated spin**:
  1. **Ball roll** animation over a rotating wheel  
  2. **Final drop** onto the winning number pocket  
  3. **Highlight** the winning number and color  
  4. **Result board overlay** showing all bet types and outcome  

- **JSON output**: Detailed result including wager, bet type, winning number, payout, net gain, and generated video file.  
- **Realistic table rules**: Supports all major European/American roulette bet types.

---

## Installation

1. Ensure [.NET 9.0 SDK](https://dotnet.microsoft.com/download) is installed.  
2. Clone or download this repository.  
3. Add dependencies:

   ```bash
   dotnet add package SkiaSharp
   dotnet add package Svg.Skia
   dotnet add package Newtonsoft.Json
   ```

4. Place your wheel and ball animation assets in the `wwwroot/` directory:
   - `red_*.mp4` (e.g., `red_1.mp4`, `red_3.mp4`…)  
   - `black_*.mp4`  
   - `green_0.mp4`, `green_00.mp4`  
   - `roulette_ball_red.mp4`, `roulette_ball_black.mp4`, `roulette_ball_green.mp4`

---

## Build & Publish

```bash
# Clean and build
rm -rf bin obj
dotnet clean
dotnet restore
dotnet publish -c Release

# The single-file, self-contained binary will be in:
#   bin/Release/net9.0/<RID>/publish/TeleCasino.RouletteGame
```

---

## Usage

```bash
TeleCasino.RouletteGame <SpinId> <Wager> --bet <betArg> [--json]
```

- `<SpinId>`: Unique identifier used for output filenames (`<SpinId>.mp4` and `<SpinId>.json`).  
- `<Wager>`: Must be 1, 2, or 5.  
- `--bet <betArg>`: Supported bet types:
  - **Straight**: `n17`  
  - **Split**: `split_14_17`  
  - **Corner**: `corner_1_2_4_5`  
  - **Column**: `col1`, `col2`, `col3`  
  - **Dozen**: `_1st12`, `_2nd12`, `_3rd12`  
  - **Color**: `red`, `black`  
  - **Parity**: `even`, `odd`  
  - **High/Low**: `high`, `low`  
  - **Basket**: `basket` (0, 00, 1, 2, 3)  
  - **Trio**: `trio12`, `trio23`  

- `--json` (optional): Print the JSON summary to console.

### Example

```bash
TeleCasino.RouletteGame spinX1 2 --bet split_14_17 --json
```

- Generates `spinX1.mp4` (video) and `spinX1.json`:

```json
{
  "SpinId": "spinX1",
  "Wager": 2,
  "Bet": "split_14_17",
  "WinningNumber": 17,
  "Color": "black",
  "Payout": 34,
  "NetGain": 32,
  "VideoFile": "spinX1.mp4"
}
```

---

## Rules & Parameters

- **Valid wagers**: 1, 2, or 5  
- **Bet types**: Straight (35:1), Split (17:1), Street (11:1), Corner (8:1), Column/Dozen (2:1), Color/Even/Odd/High/Low (1:1), Basket (6:1), Trio (11:1).  
- **House edge**: American table with double zero (5.26% house edge).

---

## Payout Table

| Bet Type    | Format Example     | Odds   |
|-------------|-------------------|--------|
| Straight    | `n17`             | 35:1   |
| Split       | `split_14_17`     | 17:1   |
| Street      | `street_1_2_3`    | 11:1   |
| Corner      | `corner_1_2_4_5`  | 8:1    |
| Column      | `col1`            | 2:1    |
| Dozen       | `_1st12`          | 2:1    |
| Color       | `red`             | 1:1    |
| Even/Odd    | `even`            | 1:1    |
| High/Low    | `high`            | 1:1    |
| Basket      | `basket`          | 6:1    |
| Trio        | `trio12`          | 11:1   |

---

## License

This project is released under the MIT License.
