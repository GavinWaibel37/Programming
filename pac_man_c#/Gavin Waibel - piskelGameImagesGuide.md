# Making Your Own Game Images in Piskel

In this guide you will design your own player, enemies, and coin for your Pac-Man game using **Piskel**, a free pixel-art tool that runs in your web browser. You will save each one as an animated GIF and put them in your game.

**Design your own characters.** Do not copy characters from other games, movies, or shows.

---

## Table of Contents

- [What You Will Make](#what-you-will-make)
- [Part 1: Start a New Sprite](#part-1-start-a-new-sprite)
- [Part 2: Learn the Drawing Tools](#part-2-learn-the-drawing-tools)
- [Part 3: Draw Your Player Facing Right](#part-3-draw-your-player-facing-right)
- [Part 4: Animate It](#part-4-animate-it)
- [Part 5: Save Your Work](#part-5-save-your-work)
- [Part 6: Export a GIF](#part-6-export-a-gif)
- [Part 7: Make the Other Three Directions](#part-7-make-the-other-three-directions)
- [Part 8: Make the Four Enemies](#part-8-make-the-four-enemies)
- [Part 9: Make the Coin](#part-9-make-the-coin)
- [Part 10: Put Your Images in the Game](#part-10-put-your-images-in-the-game)
- [Troubleshooting](#troubleshooting)

---

## What You Will Make

You need **nine GIF files**. The names must match exactly, because the game code looks for these names.

| File name | What it is | Canvas size in Piskel | Export size |
|---|---|---|---|
| `right.gif` | Player facing right | 25 x 25 | 50 x 50 |
| `left.gif` | Player facing left | 25 x 25 | 50 x 50 |
| `up.gif` | Player facing up | 25 x 25 | 50 x 50 |
| `down.gif` | Player facing down | 25 x 25 | 50 x 50 |
| `red.gif` | Enemy 1 | 25 x 25 | 50 x 50 |
| `blue.gif` | Enemy 2 | 25 x 25 | 50 x 50 |
| `yellow.gif` | Enemy 3 | 25 x 25 | 50 x 50 |
| `pink.gif` | Enemy 4 | 25 x 25 | 50 x 50 |
| `coin.gif` | Coin | 10 x 10 | 20 x 20 |

**Design rules**

- **Keep it square.** The game stretches every image into a square.
- **Leave the background transparent.** In the game, transparent areas show the black background.
- **Use bright colors.** Dark colors disappear on a black background.
- **Keep the animation short.** 2 to 4 frames is plenty.
- The enemies do not have to be red, blue, yellow, and pink. Those are just the file names. Each enemy should look different from the others.

---

## Part 1: Start a New Sprite

1. Go to **piskelapp.com** and click **Create Sprite**. You do not need an account.
2. On the right side, click the **Resize** button. (Hover over the buttons on the right side to see their names.)
3. Set **Width** to `25` and **Height** to `25`, then click **Resize**.

The gray and white checkerboard means **transparent**. Leave it that way for anything that is not part of your character.

---

## Part 2: Learn the Drawing Tools

The tools are on the left side. Hover over any tool to see its name and keyboard shortcut.

| Tool | What it does |
|---|---|
| **Pen** | Draws one pixel at a time |
| **Vertical mirror pen** | Draws on both the left and right sides at once. Great for enemies and coins, which look the same on both sides. |
| **Paint bucket** | Fills an area with one color |
| **Paint all pixels of the same color** | Changes every pixel of one color to a new color. Useful for recoloring. |
| **Eraser** | Makes pixels transparent again |
| **Rectangle** and **Circle** | Draw shapes |
| **Color picker** | Picks up a color from your drawing |
| **Move** | Slides your drawing around the canvas |

**Colors:** The two color squares under the tools are your colors. **Left-click** draws with the top color. **Right-click** draws with the bottom color.

**Other tips**

- **Undo** with **Ctrl+Z**.
- **Zoom** with the mouse wheel.
- Draw the outline or main shape first, then fill in details.

---

## Part 3: Draw Your Player Facing Right

Draw your player **facing right**. You will turn it to face the other directions in Part 7.

**Top-down or side view?** If you draw your player as seen **from above** (like looking down at a bug), it can be rotated to face every direction and still look right. A player seen **from the side** looks odd when rotated to face up or down. Top-down is easier for this game.

---

## Part 4: Animate It

The **frames** are the small pictures on the left side. Each frame is one picture in the animation.

1. Hover over your first frame and click the **Duplicate** icon. This makes a copy.
2. Click the new frame and change a few pixels. For example, move the wings, legs, or mouth.
3. Repeat for a third or fourth frame if you want.
4. Watch the **preview** in the top right corner. Use the **FPS** slider under it to change the speed. Around 6 to 10 FPS works well.

**Onion skin:** The onion skin button (near the preview) shows the previous frame faintly behind the current one. It helps you line up each frame.

> Duplicating a frame and changing a few pixels is much easier than drawing each frame from scratch.

---

## Part 5: Save Your Work

Exporting a GIF does **not** save your work in a form you can edit later. Save the Piskel file too.

1. On the right side, click the **Save** button.
2. Give it a name, like `player`.
3. Choose the option to **save as a file** to your computer. This makes a `.piskel` file.

To edit it later, go to piskelapp.com, click **Create Sprite**, then use the **Import** button on the right side to open your `.piskel` file.

---

## Part 6: Export a GIF

1. On the right side, click the **Export** button.
2. Click the **GIF** tab.
3. Set the size so the GIF comes out **50 x 50** (or **20 x 20** for the coin). If your canvas is 25 x 25, that means doubling the size.
4. Click **Download**.
5. Rename the file to the exact name from the table, like `right.gif`.

> **Windows tip:** Windows sometimes hides the `.gif` at the end of file names. If you rename a file to `right.gif` while that is hidden, it may really be named `right.gif.gif`. In File Explorer, click **View > Show > File name extensions** to see the full names.

---

## Part 7: Make the Other Three Directions

You already have `right.gif`. Now use the **Transform** buttons on the right side of Piskel to turn your player.

For a **top-down** player, starting from the right-facing version:

1. Click **Rotate counter-clockwise** once. The player now faces **up**. Export it as `up.gif`.
2. Click **Rotate counter-clockwise** again. The player now faces **left**. Export it as `left.gif`.
3. Click **Rotate counter-clockwise** again. The player now faces **down**. Export it as `down.gif`.

For a **side-view** player, use **Flip horizontally** to make `left.gif`. For up and down, you can reuse the right or left version, or draw new ones.

> **Important:** Rotate and flip each change only the frame you are on. Do it on **every frame** before you export, then play the preview to check. (Hovering over the Transform buttons shows a tip with a key you can hold to change all frames at once.)

---

## Part 8: Make the Four Enemies

1. Start a new sprite at 25 x 25 (Part 1).
2. Draw an enemy. The **vertical mirror pen** makes this fast if your enemy looks the same on both sides.
3. Animate it with 2 to 4 frames (Part 4).
4. Save the `.piskel` file (Part 5).
5. Export it as `red.gif` (Part 6).

To make the other three, you can either draw new enemies or recolor the first one:

1. Pick the **Paint all pixels of the same color** tool.
2. Choose a new color and click the part you want to change. Every pixel of that color changes.
3. Do this on **every frame**.
4. Export as `blue.gif`, and so on.

---

## Part 9: Make the Coin

1. Start a new sprite and resize it to **10 x 10**.
2. Draw a coin, gem, or any small item for the player to collect.
3. To make a spinning coin, duplicate the frame and make the coin a little narrower each frame, down to a thin line, then wider again.
4. Export it as `coin.gif` at **20 x 20**.

---

## Part 10: Put Your Images in the Game

**If you have not started the game yet:** In Part 4 of the Pac-Man guide, import your nine GIFs instead of the downloaded images. Everything else stays the same.

**If you already built the game with the downloaded images:** Replace the old files with yours.

1. In Visual Studio, open **Solution Explorer** and find the **Resources** folder in your project.
2. Right-click the **Resources** folder and choose **Open Folder in File Explorer**.
3. Copy your nine GIFs into that folder. When Windows asks, choose **Replace the files in the destination**.
4. Run the game. Your images should show up everywhere, including all the coins.

This only works if your file names match the old names exactly.

---

## Troubleshooting

| Problem | Fix |
|---|---|
| My character has a white or gray box around it in the game | The background was not transparent. Erase the background in Piskel and export again. |
| My character is hard to see in the game | It uses dark colors. Brighten the colors or add a light outline. |
| The animation plays too fast or too slow | Change the FPS slider in Piskel and export again. |
| My player looks wrong in one direction | You rotated or flipped only one frame. Check every frame. |
| Visual Studio can't find my image | Check the file name, and check for a hidden extra `.gif` (see the tip in Part 6). |
| My new images don't show up after replacing files | Close and reopen Visual Studio, then run the game again. |
| I closed Piskel and lost my drawing | Save the `.piskel` file every time you finish a character (Part 5). |
