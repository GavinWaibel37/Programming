# Pac-Man in C# — Build Guide

This guide goes with the MOO ICT Pac-Man tutorial video. You will build a Pac-Man game in C# using Visual Studio and Windows Forms.

Use the video and this guide together. The video shows you where to click and what it looks like. This guide gives you the code for each part, explains what the code does, and tells you how to test it before you move on.

**What you will learn**

- How a program reacts to **events**, like a key press, a button click, or a timer tick
- How a **game loop** works (a timer that runs your code about 50 times a second)
- How screen positions work (**Left** and **Top**)
- How to tell when two objects touch (**collision**)
- How to use **lists** and **loops** to handle many objects at once
- How to write a **class** and use it to create several **objects** (the four ghosts)

---

## Table of Contents

- [Before You Start](#before-you-start)
- [Reading C# Code](#reading-c-code)
- [Section 1: Build the Form](#section-1-build-the-form)
  - [Part 1: Create the Project](#part-1-create-the-project)
  - [Part 2: Set Up the Form](#part-2-set-up-the-form)
  - [Part 3: Build the Walls](#part-3-build-the-walls)
  - [Part 4: Add Pac-Man](#part-4-add-pac-man)
  - [Part 5: Add the Coins](#part-5-add-the-coins)
  - [Part 6: Add the Game Timer](#part-6-add-the-game-timer)
  - [Part 7: Build the Start Menu](#part-7-build-the-start-menu)
  - [Part 8: Connect the Events](#part-8-connect-the-events)
- [Section 2: Pac-Man Code](#section-2-pac-man-code)
  - [Part 9: Add the Ghost Class File](#part-9-add-the-ghost-class-file)
  - [Part 10: Game Variables](#part-10-game-variables)
  - [Part 11: Create the Empty Methods](#part-11-create-the-empty-methods)
  - [Part 12: The SetUp Method](#part-12-the-setup-method)
  - [Part 13: Keyboard Controls](#part-13-keyboard-controls)
  - [Part 14: Moving Pac-Man and the Start Button](#part-14-moving-pac-man-and-the-start-button)
  - [Part 15: Wrapping Around the Edges](#part-15-wrapping-around-the-edges)
  - [Part 16: Stopping at Walls](#part-16-stopping-at-walls)
  - [Part 17: Collecting Coins](#part-17-collecting-coins)
- [Section 3: The Ghost Class](#section-3-the-ghost-class)
  - [Part 18: Ghost Variables](#part-18-ghost-variables)
  - [Part 19: The Ghost Constructor](#part-19-the-ghost-constructor)
  - [Part 20: Creating the Four Ghosts](#part-20-creating-the-four-ghosts)
  - [Part 21: Ghost Movement](#part-21-ghost-movement)
  - [Part 22: Keeping Ghosts Inside the Maze](#part-22-keeping-ghosts-inside-the-maze)
  - [Part 23: Seek Mode](#part-23-seek-mode)
- [Section 4: Finishing the Game](#section-4-finishing-the-game)
  - [Part 24: Resetting the Ghosts](#part-24-resetting-the-ghosts)
  - [Part 25: Game Over](#part-25-game-over)
  - [Part 26: Ghost Collision and Winning](#part-26-ghost-collision-and-winning)
- [Troubleshooting](#troubleshooting)
- [Try This Next](#try-this-next)
- [Key Terms](#key-terms)

---

## Before You Start

### What you need

- A **Windows** computer. Windows Forms does not run on a Mac or Chromebook.
- **Visual Studio** (already installed on the lab computers). If you want to work at home, you can download **Visual Studio Community** for free. When you install it, check the **.NET desktop development** box.
- The **game images**: Pac-Man facing left, right, up, and down (animated GIFs), four ghosts (red, blue, yellow, pink), and a coin. Mr. McMaster will tell you where to get them. Put them in a folder you can find easily.

### How to use this guide

1. Watch one part of the video.
2. Build that part. Use this guide to check your code.
3. Run the game at each **Checkpoint** and make sure it works before you move on. It is much easier to fix one small problem than ten problems at the end.

### Rules that will save you time

- **C# is case sensitive.** `pacman`, `Pacman`, and `PacMan` are three different names.
- **Names must match exactly.** If you name something `gameTimer` in the designer, the code must say `gameTimer`.
- **Save often** with **Ctrl+S**.
- The narrator in the video sometimes names things a little differently from this guide. Either name is fine. Just pick one and use it everywhere.

This guide uses these names:

| Thing on the form | Name | Other settings |
|---|---|---|
| Pac-Man picture box | `pacman` | Size 50, 50 |
| Game timer | `gameTimer` | Interval 20, Enabled False |
| Menu panel | `pnlMenu` | |
| Play button | `btnStart` | |
| Instructions / score label | `lblInfo` | |

---

## Reading C# Code

You do not need to learn all of C# to build this game, but these pieces show up everywhere. If you have used Python, the last column shows the Python version.

| C# | What it means | Python version |
|---|---|---|
| `int score = 0;` | Make a whole-number variable named `score` that starts at 0 | `score = 0` |
| `bool goLeft;` | Make a true/false variable | `go_left = False` |
| `string message` | A variable that holds text | `message = ""` |
| `;` | Ends a line of code. Almost every line needs one. | (new line) |
| `{ }` | Groups lines that belong together | indentation |
| `// comment` | A note for people. The computer ignores it. | `# comment` |
| `=` | Set a value | `=` |
| `==` | Check if two things are equal | `==` |
| `&&` | And | `and` |
| `score++` | Add 1 to score | `score += 1` |
| `pacman.Left -= speed;` | Subtract speed from pacman.Left | `pacman.left -= speed` |
| `if (goLeft) { ... }` | If goLeft is true, run the code in the braces | `if go_left:` |
| `foreach (PictureBox coin in coins)` | Loop through every coin in the coins list | `for coin in coins:` |
| `private void ShowCoins()` | A method (function) named ShowCoins | `def show_coins():` |
| `pacman.Left` | The dot gets something that belongs to an object | `pacman.left` |

In C#, **every variable has a type** (`int`, `bool`, `string`, `PictureBox`, and so on). You have to say the type when you create the variable.

---

## Section 1: Build the Form

In this section you build the game screen by dragging things onto the form. No code yet.

### Part 1: Create the Project

1. Open Visual Studio and click **Create a new project**.
2. Choose **Windows Forms App** (C#). Do **not** choose the one that says **.NET Framework**.
3. Click **Next**. Visual Studio fills in a project name like `WinFormsApp1`. **Change it to `PacManV2`.** Click **Next**.
4. Leave the framework at its default setting (for example, .NET 10.0). The video uses .NET 8, but a newer version works the same way. Click **Create**.

**Why the project name matters:** The name shows up on the `namespace` line at the top of your code files. A clear name like `PacManV2` makes your project easier to find later and makes your code easier to match with this guide. Use only letters and numbers, with no spaces.

**What you are looking at**

- The gray window in the middle is **Form1**, the window your game will run in. This is the **Design view**.
- **Solution Explorer** (right side) lists your project files.
- **Properties** (right side, usually below Solution Explorer) shows the settings for whatever you have selected.
- **Toolbox** (left side) has the controls you can drag onto the form.
- If you cannot find one of these windows, open the **View** menu.

> The screen may flicker a little while you work with a lot of pictures in Design view. That is normal.

### Part 2: Set Up the Form

Click the form's title bar to select the form. In the Properties window, set:

| Property | Value |
|---|---|
| Text | `Pac-Man Game` |
| Size | `1030, 775` |
| BackColor | Black |
| DoubleBuffered | True |

**How it works**

- **Text** is the title at the top of the window.
- **DoubleBuffered** makes the form draw each frame out of sight first, then show it all at once. This cuts down on flicker when things move.

### Part 3: Build the Walls

1. From the Toolbox, drag a **PictureBox** onto the form. Stretch it into a long, thin bar along the top.
2. Set its **BackColor** to a blue color.
3. Copy it: select it, then **hold Ctrl and drag** it. This makes a copy. To select more than one thing, **Shift+click** each one.
4. Build **eight walls**: two across the top, two across the bottom, two down the left side, and two down the right side. Leave a **gap in the middle of each side**. Pac-Man will go through these gaps and come out on the other side of the screen.
5. Make the gaps on opposite sides line up and be the same size, or Pac-Man will clip on the edge.
6. Shift+click all eight walls. In Properties, set **Tag** to `wall`.

**How it works**

**Tag** is a label you can put on any control. Later, the code will look at everything on the form and collect every picture box tagged `wall`. That means you could have 8 walls or 80 walls and the code would not change. Tags are case sensitive: use `wall`, not `Wall`.

### Part 4: Add Pac-Man

1. Drag a new **PictureBox** onto the form. Set its **Name** to `pacman`.
2. Right-click it and choose **Choose Image**.
3. Select **Project resource file**, then click **Import**. Select **all** the game images at once and click **Open**. Pick one of the Pac-Man images and click **OK**.
4. Set **Size** to `50, 50` and **SizeMode** to **StretchImage**.
5. Leave Pac-Man in the middle of the form.

**Why "Project resource file" matters**

This makes the images part of your project, so the code can use them by name, like `Properties.Resources.left`. If you pick **Local resource** instead, the code in Part 13 will not be able to find the images.

### Part 5: Add the Coins

1. Make a new PictureBox (or copy Pac-Man with Ctrl+C, Ctrl+V). Right-click it, choose **Choose Image**, and pick the coin.
2. Set **Size** to `20, 20` and **SizeMode** to **StretchImage**.
3. Set **Tag** to `coin`. Do this **before** you make copies, because copies keep the tag.
4. Hold **Ctrl and drag** to make copies. Once you have a row, select the whole row and Ctrl+drag it to make another row.
5. Fill the maze with coins. Leave space in the **four corners**, because that is where the ghosts start.

The video ends up with 104 coins. Any number works.

### Part 6: Add the Game Timer

1. In the Toolbox, open **Components** and drag a **Timer** onto the form. It shows up in the tray **below** the form, not on the form itself.
2. Set these properties:

| Property | Value |
|---|---|
| Name | `gameTimer` |
| Interval | `20` |
| Enabled | False |

**How it works**

The timer is the **game loop**. Every 20 milliseconds (about 50 times a second), it runs your code: move Pac-Man, check the walls, check the coins, move the ghosts. It starts turned off (**Enabled = False**) so the game does not begin until the player clicks Play.

### Part 7: Build the Start Menu

1. Drag a **Panel** onto the middle of the form. Set its **Name** to `pnlMenu`. A panel is a container that holds other controls.
2. Drag a **Button** **inside** the panel. Set **Text** to `Play`, **Font** to Bold, size 16, and **Name** to `btnStart`.
3. Drag a **Label** inside the panel for the game title:
   - **Text:** `Pac-Man`
   - **ForeColor:** yellow
   - **Font:** any font you like, large size
   - **AutoSize:** False, then stretch the label to the width of the panel
   - **TextAlign:** MiddleCenter
4. Add a second label inside the panel with the same settings. Set its **Name** to `lblInfo` and its **Text** to instructions, for example: `Use the arrow keys to move. Collect all the coins and avoid the ghosts.`

**How it works**

Because the button and labels are **inside** the panel, one line of code can hide or show all of them at once. The `lblInfo` label will later show the "You Win" or "You Died" message and the score.

Renaming controls matters. `gameTimer` and `lblInfo` tell you what they are. `timer1` and `label2` do not.

### Part 8: Connect the Events

An **event** is something that happens while the program runs, like a key press, a timer tick, or a button click. An **event handler** is the method that runs when that event happens.

1. Click the form's title bar to select the form. In the Properties window, click the **lightning bolt** icon to see **Events**. Find **KeyDown**, type `KeyIsDown`, and press **Enter**. Visual Studio creates an empty method and opens the code. Go back to the Design view tab.
2. Select **gameTimer** in the tray. In Events, find **Tick**, type `GameTimerEvent`, and press **Enter**.
3. Select the **Play** button. In Events, find **Click**, type `StartButtonClick`, and press **Enter**.

> **Let Visual Studio create these three methods.** Do not type their first lines yourself. When Visual Studio creates them, it also connects them to the controls behind the scenes. If you type them by hand, they will never run.

To switch between views: **F7** opens the code, **Shift+F7** opens the design.

Your `Form1.cs` code should now look like this. Your `namespace` line will match your project name. Keep yours.

```csharp
namespace PacManV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {

        }

        private void StartButtonClick(object sender, EventArgs e)
        {

        }
    }
}
```

---

## Section 2: Pac-Man Code

Now you write the code that moves Pac-Man, stops him at walls, and collects coins.

### Part 9: Add the Ghost Class File

The video creates the ghost file now. You will fill it in during Section 3.

1. In **Solution Explorer**, right-click the **project** (the one with the C# icon, not the solution at the very top).
2. Choose **Add > Class**.
3. Name it `Ghost.cs` (capital G) and click **Add**.

Leave it empty for now and go back to `Form1.cs`.

> In the video, the narrator starts typing variables right after making the Ghost file. Those variables go in **Form1.cs**, not Ghost.cs.

### Part 10: Game Variables

**File:** `Form1.cs`, inside `public partial class Form1 : Form {`, **above** `public Form1()`.

```csharp
// Which way Pac-Man is moving right now
bool goUp, goDown, goLeft, goRight;

// True when a wall is blocking Pac-Man in that direction
bool noUp, noDown, noLeft, noRight;

// Lists that will hold every wall and every coin on the form
List<PictureBox> walls = new List<PictureBox>();
List<PictureBox> coins = new List<PictureBox>();

int speed = 12;   // how many pixels Pac-Man moves each timer tick
int score = 0;    // how many coins Pac-Man has collected

// The four ghosts. They get created in the SetUp method (Part 20).
Ghost red, yellow, blue, pink;

// A list of all the ghosts, so we can loop through them
List<Ghost> ghosts = new List<Ghost>();
```

**How it works**

- Variables created here (inside the class but outside any method) can be used by **every method** in Form1.
- `goLeft` and the others track which way Pac-Man is moving. Only one should be true at a time.
- `noLeft` and the others are true when a wall is in the way. You cannot move in that direction until you turn.
- A **List** holds many items of the same type. `List<PictureBox>` is a list of picture boxes.
- `Ghost` is the class you made in Part 9. `Ghost red` says "there will be a Ghost called red." The ghost is not created yet.

> **Green squiggly lines** are warnings. The game will still run. **Red squiggly lines** are errors and must be fixed.

### Part 11: Create the Empty Methods

**File:** `Form1.cs`, below the three event methods, still inside the class.

These are empty for now. You will fill them in over the next parts.

```csharp
// Collects the walls and coins into lists and creates the ghosts
private void SetUp()
{

}

// Moves Pac-Man in the direction he is going
private void PlayerMovements()
{

}

// Makes all the coins visible again
private void ShowCoins()
{

}

// Stops Pac-Man if he runs into a wall
private void CheckBoundaries(PictureBox pacman, PictureBox wall)
{

}

// Collects a coin if Pac-Man touches it
private void CollectingCoins(PictureBox pacman, PictureBox coin)
{

}

// Ends the game if a ghost touches Pac-Man
private void GhostCollision(Ghost g, PictureBox pacman, PictureBox ghost)
{

}

// Stops the game and shows the menu with a message
private void GameOver(string message)
{

}
```

**How it works**

- A **method** is a named block of code you can run by calling its name, like `ShowCoins();`
- `private void` means only Form1 can use it (`private`) and it does not send back an answer (`void`).
- The items in parentheses are **parameters**: values you hand to the method when you call it. When the code calls `CheckBoundaries(pacman, wall)`, the method gets the real Pac-Man and one real wall. If the method changes `pacman.Left`, it moves the real Pac-Man.
- Splitting the game into small methods keeps the timer code short and easy to read.

### Part 12: The SetUp Method

**Step 1.** In the `Form1()` constructor, add `SetUp();` after `InitializeComponent();`

```csharp
public Form1()
{
    InitializeComponent();   // builds everything you made in Design view
    SetUp();                 // then runs our setup code
}
```

**Step 2.** Fill in `SetUp()`. The last line is a temporary test.

```csharp
private void SetUp()
{
    // Look at every control on the form, one at a time
    foreach (Control x in this.Controls)
    {
        // If it is a picture box tagged "wall", add it to the walls list
        if (x is PictureBox && (string)x.Tag == "wall")
        {
            walls.Add((PictureBox)x);
        }

        // If it is a picture box tagged "coin", add it to the coins list
        if (x is PictureBox && (string)x.Tag == "coin")
        {
            coins.Add((PictureBox)x);
        }
    }

    // TEMPORARY TEST: show the counts in the title bar
    this.Text = walls.Count + " " + coins.Count;
}
```

**How it works**

- `InitializeComponent()` loads everything you built in Design view. `SetUp()` runs right after it.
- `this.Controls` is everything on the form. `this` means "this form."
- `x is PictureBox` checks if the control is a picture box.
- `(string)x.Tag == "wall"` reads the Tag as text and checks if it says `wall`.
- `(PictureBox)x` is called **casting**. It tells C# to treat this control as a picture box, which it needs to be to go in the list.

> The video writes `x.Tag == "wall"`. This guide uses `(string)x.Tag == "wall"`, which is the more correct way to compare text in C#. Both work in this project.

**✅ Checkpoint:** Press **F5** (or the green Start button). The title bar should show `8 104` (your coin count may be different). If you see a 0, check your Tags. Then **delete the test line.**

### Part 13: Keyboard Controls

**File:** `Form1.cs`, inside `KeyIsDown`.

```csharp
private void KeyIsDown(object sender, KeyEventArgs e)
{
    // LEFT arrow, and no wall blocking the left
    if (e.KeyCode == Keys.Left && noLeft == false)
    {
        goRight = goDown = goUp = false;     // stop the other directions
        noRight = noDown = noUp = false;     // clear the other wall blocks
        goLeft = true;                       // start moving left
        pacman.Image = Properties.Resources.left;   // face left
    }

    // RIGHT arrow
    if (e.KeyCode == Keys.Right && noRight == false)
    {
        goLeft = goUp = goDown = false;
        noLeft = noUp = noDown = false;
        goRight = true;
        pacman.Image = Properties.Resources.right;
    }

    // UP arrow
    if (e.KeyCode == Keys.Up && noUp == false)
    {
        goLeft = goRight = goDown = false;
        noLeft = noRight = noDown = false;
        goUp = true;
        pacman.Image = Properties.Resources.up;
    }

    // DOWN arrow
    if (e.KeyCode == Keys.Down && noDown == false)
    {
        goLeft = goRight = goUp = false;
        noLeft = noRight = noUp = false;
        goDown = true;
        pacman.Image = Properties.Resources.down;
    }
}
```

**How it works**

- `e.KeyCode` tells you which key was pressed.
- `&& noLeft == false` means "only if no wall is blocking the left."
- `goRight = goDown = goUp = false;` sets all three to false in one line, so Pac-Man only moves one way at a time.
- Pac-Man keeps moving after you let go of the key, like in the real game. That is why there is no KeyUp event.

> **Image names:** type `Properties.Resources.` (with the dot) and a list pops up showing the names of your images. The names come from the image file names. If yours are different from `left`, `right`, `up`, and `down`, use yours.

### Part 14: Moving Pac-Man and the Start Button

**Step 1.** Fill in `PlayerMovements()`:

```csharp
private void PlayerMovements()
{
    if (goLeft)  { pacman.Left -= speed; }   // move left
    if (goRight) { pacman.Left += speed; }   // move right
    if (goUp)    { pacman.Top -= speed; }    // move up
    if (goDown)  { pacman.Top += speed; }    // move down
}
```

**Step 2.** Call it from the timer:

```csharp
private void GameTimerEvent(object sender, EventArgs e)
{
    PlayerMovements();
}
```

**Step 3.** Fill in the start button:

```csharp
private void StartButtonClick(object sender, EventArgs e)
{
    // Hide the menu (this hides the button and labels too)
    pnlMenu.Enabled = false;
    pnlMenu.Visible = false;

    // Reset movement and wall blocks
    goLeft = goRight = goUp = goDown = false;
    noLeft = noRight = noUp = noDown = false;

    score = 0;

    // (Ghost resets get added here in Part 24)

    gameTimer.Start();   // start the game loop
}
```

**How it works**

- **Left** is how far the picture box is from the left edge of the form. **Top** is how far it is from the top.
- On a screen, **Top gets bigger as you go down**. That is the opposite of a graph in math class. So moving up means subtracting from Top.
- Each timer tick moves Pac-Man 12 pixels. At 50 ticks per second, that looks like smooth movement.

**✅ Checkpoint:** Run the game and click **Play**. Use the arrow keys. Pac-Man should move and keep moving. He will go right through the walls. That gets fixed in Part 16.

### Part 15: Wrapping Around the Edges

**File:** `Form1.cs`. Add this to the **bottom** of `PlayerMovements()`, after the four movement lines.

```csharp
// Went off the left side? Come back on the right side.
if (pacman.Left < -30)
{
    pacman.Left = this.ClientSize.Width - pacman.Width;
}

// Went off the right side? Come back on the left side.
if (pacman.Left + pacman.Width > this.ClientSize.Width)
{
    pacman.Left = -10;
}

// Went off the top? Come back at the bottom.
if (pacman.Top < -30)
{
    pacman.Top = this.ClientSize.Height - pacman.Height;
}

// Went off the bottom? Come back at the top.
if (pacman.Top + pacman.Height > this.ClientSize.Height)
{
    pacman.Top = -10;
}
```

**How it works**

- `ClientSize` is the inside of the window, not counting the border and title bar.
- `pacman.Left + pacman.Width` is the position of Pac-Man's **right** edge.
- When Pac-Man goes past one edge, the code moves him to the opposite edge.

> This guide uses `ClientSize` in all four checks. If you followed the video and Pac-Man jumps back and forth at an edge, change your code to match this.

**✅ Checkpoint:** Go through a gap in the wall. Pac-Man should come out on the other side.

### Part 16: Stopping at Walls

**Step 1.** Fill in `CheckBoundaries()`:

```csharp
private void CheckBoundaries(PictureBox pacman, PictureBox wall)
{
    // Are Pac-Man and this wall overlapping?
    if (pacman.Bounds.IntersectsWith(wall.Bounds))
    {
        if (goLeft)
        {
            noLeft = true;                    // block left
            goLeft = false;                   // stop moving
            pacman.Left = wall.Right + 2;     // push him just right of the wall
        }

        if (goRight)
        {
            noRight = true;
            goRight = false;
            pacman.Left = wall.Left - pacman.Width - 2;   // just left of the wall
        }

        if (goUp)
        {
            noUp = true;
            goUp = false;
            pacman.Top = wall.Bottom + 2;     // just below the wall
        }

        if (goDown)
        {
            noDown = true;
            goDown = false;
            pacman.Top = wall.Top - pacman.Height - 2;    // just above the wall
        }
    }
}
```

**Step 2.** In `GameTimerEvent`, add a loop that checks every wall:

```csharp
private void GameTimerEvent(object sender, EventArgs e)
{
    PlayerMovements();

    // Check Pac-Man against every wall
    foreach (PictureBox wall in walls)
    {
        CheckBoundaries(pacman, wall);
    }
}
```

**How it works**

- **Bounds** is the invisible rectangle around a control.
- `IntersectsWith` is true when two rectangles overlap. This is how most 2D games check for collisions.
- When Pac-Man hits a wall, the code checks which way he was going, stops him, blocks that direction, and pushes him back 2 pixels so he is not stuck inside the wall.
- The `foreach` loop is why the walls list is useful: one short loop checks all eight walls.

**✅ Checkpoint:** Pac-Man should stop at every wall in all four directions. He should be able to turn and move away.

### Part 17: Collecting Coins

**Step 1.** Fill in `CollectingCoins()`:

```csharp
private void CollectingCoins(PictureBox pacman, PictureBox coin)
{
    if (pacman.Bounds.IntersectsWith(coin.Bounds))
    {
        // Only collect coins that are still showing
        if (coin.Visible)
        {
            coin.Visible = false;   // hide the coin
            score++;                // add 1 to the score
        }
    }
}
```

**Step 2.** Fill in `ShowCoins()`:

```csharp
private void ShowCoins()
{
    foreach (PictureBox coin in coins)
    {
        coin.Visible = true;
    }
}
```

**Step 3.** Update `GameTimerEvent`:

```csharp
private void GameTimerEvent(object sender, EventArgs e)
{
    PlayerMovements();

    foreach (PictureBox wall in walls)
    {
        CheckBoundaries(pacman, wall);
    }

    // Check Pac-Man against every coin
    foreach (PictureBox coin in coins)
    {
        CollectingCoins(pacman, coin);
    }

    // TEMPORARY: when every coin is collected, bring them all back
    // (Part 26 replaces this with a "You Win" message)
    if (score == coins.Count)
    {
        ShowCoins();
        score = 0;
    }
}
```

**How it works**

- Coins are **hidden**, not deleted. That makes it easy to bring them all back for the next game.
- The `if (coin.Visible)` check stops Pac-Man from collecting the same hidden coin over and over.
- `coins.Count` is how many coins are in the list. When the score equals that number, every coin has been collected.

**✅ Checkpoint:** Coins disappear when Pac-Man touches them. After you collect the last one, they all come back.

---

## Section 3: The Ghost Class

**What is a class?** A class is a **blueprint**. The Ghost class describes what every ghost **has** (a picture, a speed, a direction) and what every ghost can **do** (move, change direction). Then you use the blueprint to make four ghost **objects**: red, blue, yellow, and pink.

Each ghost keeps track of its own position and direction, but you only write the ghost code **once**. Without a class, you would write the movement code four times, once for each ghost.

### Part 18: Ghost Variables

**File:** `Ghost.cs`. Here is what the file should look like after this part. Keep your own `namespace` line.

```csharp
using System.Drawing;         // for Image
using System.Windows.Forms;   // for PictureBox and Form

namespace PacManV2
{
    internal class Ghost
    {
        int speed = 8;    // speed when moving in a straight line
        int xSpeed = 4;   // left/right speed in seek mode (half speed)
        int ySpeed = 4;   // up/down speed in seek mode (half speed)

        // The area the ghosts are allowed to move in.
        // These numbers come from YOUR form. See "Finding your numbers" below.
        int maxHeight = 685;
        int minHeight = 81;
        int maxWidth = 970;
        int minWidth = 76;

        int change = 0;   // countdown until the ghost picks a new direction
        Random random = new Random();

        // The five things a ghost can do
        string[] directions = { "left", "right", "up", "down", "seek" };
        string direction = "left";   // the ghost starts by moving left

        // The ghost's picture box. Public so Form1 can use it.
        public PictureBox image = new PictureBox();
    }
}
```

**How it works**

- `string[] directions` is an **array**, a fixed list of values. Each ghost will randomly pick one of these five.
- `Random` makes random numbers.
- Only `image` is `public`, because Form1 needs it (to reset the ghost's position and check if it touched Pac-Man). Everything else stays private because only the Ghost class uses it.

**Finding your numbers**

The four min/max numbers keep the ghosts inside the walls. Your numbers depend on how you built your maze.

1. In Design view, click a coin (or any picture box) at the **farthest top-left spot** inside the walls. Look at its **Location** in Properties. The X value is `minWidth`. The Y value is `minHeight`.
2. Click something at the **farthest bottom-right spot** inside the walls. Add 50 (the ghost's size) to its X to get `maxWidth`. Add 50 to its Y to get `maxHeight`.

The video's numbers may look a little different from the ones above. What matters is that they match your maze.

### Part 19: The Ghost Constructor

**File:** `Ghost.cs`, inside the class, below the variables.

```csharp
// The constructor runs once, every time a new Ghost is created
public Ghost(Form game, Image img, int x, int y)
{
    image.Image = img;                                  // the ghost picture
    image.SizeMode = PictureBoxSizeMode.StretchImage;   // fit the picture to the box
    image.Width = 50;
    image.Height = 50;
    image.Left = x;                                     // starting position
    image.Top = y;

    game.Controls.Add(image);   // put the ghost on the form
}
```

**How it works**

- A **constructor** has the same name as the class and no return type. It runs automatically when you create a new object.
- The parameters let each ghost be different:
  - `game` is the form, so the ghost can add itself to it
  - `img` is the ghost's picture (red, blue, yellow, or pink)
  - `x` and `y` are where it starts
- `game.Controls.Add(image)` puts the picture box on the form. Without this line, the ghost exists in the code but does not show up on the screen.

### Part 20: Creating the Four Ghosts

**File:** `Form1.cs`, at the **bottom** of `SetUp()`, after the `foreach` loop.

```csharp
// Create each ghost: (this form, its picture, starting X, starting Y)
// Then add it to the ghosts list
red = new Ghost(this, Properties.Resources.red, 100, 100);
ghosts.Add(red);

blue = new Ghost(this, Properties.Resources.blue, 848, 597);
ghosts.Add(blue);

yellow = new Ghost(this, Properties.Resources.yellow, 132, 584);
ghosts.Add(yellow);

pink = new Ghost(this, Properties.Resources.pink, 877, 130);
ghosts.Add(pink);
```

**How it works**

- `new Ghost(...)` uses the blueprint to build a real ghost. This calls the constructor from Part 19.
- `this` means "this form." It is passed in so each ghost can add itself to the form.
- Each ghost is an **instance** of the Ghost class. Same blueprint, different picture and starting spot.

**✅ Checkpoint:** Run the game. You should see four ghosts, one near each corner. They do not move yet. If a ghost is hidden behind coins or walls, see [Troubleshooting](#troubleshooting).

### Part 21: Ghost Movement

**Step 1.** **File:** `Ghost.cs`, inside the class, below the constructor.

```csharp
// Moves this ghost. Called from the game timer.
public void GhostMovement(PictureBox pacman)
{
    // Count down. When the countdown hits 0, pick a new direction.
    if (change > 0)
    {
        change--;
    }
    else
    {
        change = random.Next(50, 80);                            // new countdown
        direction = directions[random.Next(directions.Length)];  // random direction
    }

    // Move based on the current direction
    switch (direction)
    {
        case "left":
            image.Left -= speed;
            break;

        case "right":
            image.Left += speed;
            break;

        case "up":
            image.Top -= speed;
            break;

        case "down":
            image.Top += speed;
            break;

        // "seek" gets added in Part 23
    }
}
```

**Step 2.** **File:** `Form1.cs`, at the bottom of `GameTimerEvent`:

```csharp
// Move each ghost. Each one needs to know where Pac-Man is.
red.GhostMovement(pacman);
blue.GhostMovement(pacman);
yellow.GhostMovement(pacman);
pink.GhostMovement(pacman);
```

**How it works**

- `change` counts down by 1 every tick. When it reaches 0, the ghost picks a new countdown number and a new random direction.
- `random.Next(50, 80)` picks a random number from 50 up to 79. At 50 ticks per second, that is about 1 to 1.5 seconds before the ghost turns.
- `directions[random.Next(directions.Length)]` picks a random spot in the array. `directions.Length` is 5, so it picks 0, 1, 2, 3, or 4.
- A **switch** checks one value against several choices. It does the same job as a stack of `if` statements. Each `case` needs a `break;` at the end.
- `GhostMovement` is `public` because Form1 needs to call it.

**✅ Checkpoint:** The ghosts wander around, and some of them wander right off the screen. That gets fixed in the next part. If a ghost stops for a moment, it picked `"seek"`, which you add in Part 23.

### Part 22: Keeping Ghosts Inside the Maze

**File:** `Ghost.cs`, at the bottom of `GhostMovement`, **after** the closing brace of the switch.

```csharp
// If the ghost reaches an edge of the maze, turn it around
if (image.Left < minWidth)
{
    direction = "right";
}

if (image.Left + image.Width > maxWidth)
{
    direction = "left";
}

if (image.Top < minHeight)
{
    direction = "down";
}

if (image.Top + image.Height > maxHeight)
{
    direction = "up";
}
```

**How it works**

After the ghost moves, these checks see if it has gone past the edge of the maze. If it has, the ghost reverses direction, so it always stays inside.

**✅ Checkpoint:** All four ghosts wander around but stay inside the walls.

### Part 23: Seek Mode

**File:** `Ghost.cs`, inside the switch in `GhostMovement`. Add this case after `case "down":`.

```csharp
case "seek":
    // Move toward Pac-Man, left or right
    if (image.Left > pacman.Left)
    {
        image.Left -= xSpeed;
    }
    if (image.Left < pacman.Left)
    {
        image.Left += xSpeed;
    }

    // Move toward Pac-Man, up or down
    if (image.Top > pacman.Top)
    {
        image.Top -= ySpeed;
    }
    if (image.Top < pacman.Top)
    {
        image.Top += ySpeed;
    }
    break;
```

**How it works**

- The ghost compares its position to Pac-Man's. If the ghost is to the right of Pac-Man, it moves left. If it is below Pac-Man, it moves up. And so on.
- Because it can move left/right **and** up/down in the same tick, a seeking ghost moves **diagonally**. That is how you can tell a ghost is chasing you.
- Seek mode uses half speed (4 instead of 8) so the player has a chance to get away.
- This is why `GhostMovement` needs Pac-Man as a parameter: the ghost has to know where Pac-Man is.

**✅ Checkpoint:** Every so often, a ghost moves diagonally and follows Pac-Man for a bit, then goes back to wandering.

---

## Section 4: Finishing the Game

### Part 24: Resetting the Ghosts

**Step 1.** **File:** `Ghost.cs`, inside the class, below `GhostMovement`.

```csharp
// Pick a new random direction (used when the game ends)
public void ChangeDirection()
{
    direction = directions[random.Next(directions.Length)];
}
```

**Step 2.** **File:** `Form1.cs`, in `StartButtonClick`. Replace the `// (Ghost resets get added here in Part 24)` comment with:

```csharp
// Put each ghost back at its starting spot
red.image.Location = new Point(100, 100);
blue.image.Location = new Point(848, 597);
yellow.image.Location = new Point(132, 584);
pink.image.Location = new Point(877, 130);
```

**How it works**

- `ChangeDirection` makes sure a ghost that just caught Pac-Man does not charge at him again the moment the next game starts.
- `new Point(x, y)` holds an X and Y together. Setting `Location` moves the picture box to that spot.
- `red.image` reaches the ghost's picture box. This works because `image` is `public`.

### Part 25: Game Over

**File:** `Form1.cs`, fill in `GameOver()`.

```csharp
private void GameOver(string message)
{
    // Show the menu again
    pnlMenu.Visible = true;
    pnlMenu.Enabled = true;

    gameTimer.Stop();   // stop the game loop

    ShowCoins();        // bring back any coins that were collected

    // Put Pac-Man back at his starting spot.
    // Use YOUR Pac-Man's Location from the Properties window.
    pacman.Location = new Point(490, 350);

    lblInfo.Text = message;   // show the win or lose message
}
```

**Finding Pac-Man's starting spot:** In Design view, the menu panel may be covering Pac-Man. Use the **drop-down list at the top of the Properties window** to select `pacman`, then copy the numbers from **Location**.

**How it works**

The `message` parameter lets the same method show different messages. Winning and losing both end the game, but they say different things.

### Part 26: Ghost Collision and Winning

**Step 1.** **File:** `Form1.cs`, fill in `GhostCollision()`.

```csharp
private void GhostCollision(Ghost g, PictureBox pacman, PictureBox ghost)
{
    // Did this ghost touch Pac-Man?
    if (pacman.Bounds.IntersectsWith(ghost.Bounds))
    {
        GameOver("You Died! Your Score: " + score);
        g.ChangeDirection();   // give this ghost a new direction for next game
    }
}
```

**Step 2.** In `GameTimerEvent`, **replace** the temporary coin check from Part 17 with a win check, and add a loop at the bottom that checks every ghost. The finished timer looks like this:

```csharp
private void GameTimerEvent(object sender, EventArgs e)
{
    PlayerMovements();

    foreach (PictureBox wall in walls)
    {
        CheckBoundaries(pacman, wall);
    }

    foreach (PictureBox coin in coins)
    {
        CollectingCoins(pacman, coin);
    }

    // All coins collected: the player wins
    if (score == coins.Count)
    {
        GameOver("You Win! You collected all " + score + " coins.");
    }

    red.GhostMovement(pacman);
    blue.GhostMovement(pacman);
    yellow.GhostMovement(pacman);
    pink.GhostMovement(pacman);

    // Check every ghost against Pac-Man
    foreach (Ghost ghost in ghosts)
    {
        GhostCollision(ghost, pacman, ghost.image);
    }
}
```

**How it works**

- `GhostCollision` gets three things: the ghost **object** (so it can call `ChangeDirection`), Pac-Man, and the ghost's **picture box** (so it can check the collision).
- `"You Died! Your Score: " + score` joins text and a number into one message.
- The `foreach (Ghost ghost in ghosts)` loop works just like the walls and coins loops, but it loops through Ghost objects instead of picture boxes.

**✅ Checkpoint:** Touching a ghost ends the game and shows your score. Click Play to start over.

**Testing the win:** It is hard to collect every coin with ghosts chasing you. To test winning, put `//` in front of each line of the ghost collision loop, play until you collect every coin, and check for the "You Win" message. Then **remove the `//`** so the ghosts work again.

🎉 **Your game is done.**

---

## Troubleshooting

**Reading errors:** Open **View > Error List**. Double-click an error to jump to the line. The line with the problem is often the one **above** where the red squiggle shows up.

| Problem | Likely cause and fix |
|---|---|
| `; expected` or `} expected` | A missing semicolon or brace. Check the line the error points to and the line above it. |
| `The name 'something' does not exist in the current context` | A typo or wrong capitalization, or the code is outside the method's braces. Compare to the code in that part of the guide. |
| Red squiggle under `Properties.Resources.left` | Your image has a different name. Type `Properties.Resources.` and pick from the list. If the list has no images, you picked **Local resource** in Part 4. Choose Image again and import using **Project resource file**. |
| Green squiggly lines | These are warnings. The game still runs. |
| Title bar shows `0 0` or a 0 in Part 12 | A Tag is misspelled or has a capital letter. It must be exactly `wall` or `coin`. |
| Coin count is lower than expected | Some coins may have been dropped **inside** the menu panel. Move them out of the panel area. |
| One of the event methods never runs | The method was typed by hand instead of created from the Events list. Select the control, open Events (lightning bolt), and pick the method from the drop-down next to the event. |
| Clicking Play works, but the arrow keys do nothing | Check that the form's **KeyDown** event is set to `KeyIsDown`. If it is, set the form's **KeyPreview** property to True. |
| Pac-Man does not move after clicking Play | The timer's **Tick** event is not set to `GameTimerEvent`, or `gameTimer.Start();` is missing. |
| Pac-Man jumps back and forth at an edge | Use `ClientSize` in all four wrap-around checks (Part 15). |
| Pac-Man goes through walls | The wall `foreach` loop is missing from the timer, or the walls are not tagged `wall`. |
| Ghosts show up behind coins or walls | In the Ghost constructor, add `image.BringToFront();` on the line after `game.Controls.Add(image);` |
| Ghosts leave the maze or get stuck at an edge | Your min/max numbers do not match your maze. Redo "Finding your numbers" in Part 18. |
| The game ends right after clicking Play | A ghost's starting spot overlaps Pac-Man's starting spot. Move one of them. |

Still stuck? Compare your code line by line with the code in that part of the guide, then ask a classmate, then ask Mr. McMaster.

---

## Try This Next

Once your game works, try some changes. Run the game after each one to see what happens.

1. **Change the speeds.** Make Pac-Man faster or slower (`speed` in Form1). Make the ghosts faster or slower (`speed`, `xSpeed`, `ySpeed` in Ghost).
2. **Show the score while playing.** In `GameTimerEvent`, add `this.Text = "Score: " + score;`
3. **Add walls inside the maze.** Add new picture boxes and tag them `wall`. You do not need to change any code. Why does that work?
4. **Shorten the timer code.** Replace the four `GhostMovement` lines with one `foreach` loop over the `ghosts` list.
5. **Add a fifth ghost.** Use one of the existing ghost images with a new starting spot. Notice how little code it takes. That is the point of a class.
6. **Make the ghosts chase more often.** Add `"seek"` to the `directions` array a second time. Each direction has an equal chance of being picked, so this doubles the chance of seek mode.
7. **Add lives.** Give the player 3 lives. When a ghost catches Pac-Man, take away a life and reset the positions. Only call `GameOver` when there are no lives left.

---

## Key Terms

| Term | Meaning |
|---|---|
| **Variable** | A named place to store a value, like `score` or `speed` |
| **Type** | What kind of value a variable holds: `int` (whole number), `bool` (true/false), `string` (text), `PictureBox`, etc. |
| **List** | A collection of items of the same type that can grow, like `List<PictureBox>` |
| **Array** | A fixed-size collection, like `string[] directions` |
| **Loop** | Code that repeats. `foreach` runs once for every item in a list. |
| **Method** | A named block of code you can run by calling its name |
| **Parameter** | A value you hand to a method when you call it |
| **Event** | Something that happens while the program runs: a key press, a click, a timer tick |
| **Event handler** | The method that runs when an event happens |
| **Game loop** | Code that runs over and over to keep the game going. Here, it is the timer. |
| **Collision** | When two objects on the screen overlap. Checked with `Bounds.IntersectsWith`. |
| **Class** | A blueprint that describes what an object has and what it can do |
| **Object / Instance** | One real thing made from a class. `red` is an instance of `Ghost`. |
| **Constructor** | A special method that runs when a new object is created |
| **public / private** | `public` means other classes can use it. `private` means only this class can use it. |
| **Casting** | Telling C# to treat a value as a certain type, like `(PictureBox)x` |
