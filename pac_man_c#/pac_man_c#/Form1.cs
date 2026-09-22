using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PacManV2
{
    public partial class Form1 : Form
    {
        // Which way Pac-Man is moving right now
        bool goUp, goDown, goLeft, goRight;

        // True when a wall is blocking Pac-Man in that direction
        bool noUp, noDown, noLeft, noRight;

        // Lists that will hold every wall and every coin on the form
        List<PictureBox> walls = new List<PictureBox>();
        List<PictureBox> coins = new List<PictureBox>();

        int speed = 12;   // how many pixels Pac-Man moves each timer tick
        int score = 0;    // how many coins Pac-Man has collected

        // The four ghosts. They get created in the SetUp method.
        Ghost red, yellow, blue, pink;

        // A list of all the ghosts, so we can loop through them
        List<Ghost> ghosts = new List<Ghost>();

        public Form1()
        {
            InitializeComponent();   // builds everything you made in Design view
            SetUp();                 // then runs our setup code
        }

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

        private void StartButtonClick(object sender, EventArgs e)
        {
            // Hide the menu (this hides the button and labels too)
            pnlMenu.Enabled = false;
            pnlMenu.Visible = false;

            // Reset movement and wall blocks
            goLeft = goRight = goUp = goDown = false;
            noLeft = noRight = noUp = noDown = false;

            score = 0;

            // Put each ghost back at its starting spot
            red.image.Location = new Point(100, 100);
            blue.image.Location = new Point(848, 597);
            yellow.image.Location = new Point(132, 584);
            pink.image.Location = new Point(877, 130);

            gameTimer.Start();   // start the game loop
        }

        // Collects the walls and coins into lists and creates the ghosts
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
        }

        // Moves Pac-Man in the direction he is going
        private void PlayerMovements()
        {
            if (goLeft) { pacman.Left -= speed; }   // move left
            if (goRight) { pacman.Left += speed; }   // move right
            if (goUp) { pacman.Top -= speed; }    // move up
            if (goDown) { pacman.Top += speed; }    // move down

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
        }

        // Makes all the coins visible again
        private void ShowCoins()
        {
            foreach (PictureBox coin in coins)
            {
                coin.Visible = true;
            }
        }

        // Stops Pac-Man if he runs into a wall
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

        // Collects a coin if Pac-Man touches it
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

        // Ends the game if a ghost touches Pac-Man
        private void GhostCollision(Ghost g, PictureBox pacman, PictureBox ghost)
        {
            // Did this ghost touch Pac-Man?
            if (pacman.Bounds.IntersectsWith(ghost.Bounds))
            {
                GameOver("You Died! Your Score: " + score);
                g.ChangeDirection();   // give this ghost a new direction for next game
            }
        }

        // Stops the game and shows the menu with a message
        private void GameOver(string message)
        {
            // Show the menu again
            pnlMenu.Visible = true;
            pnlMenu.Enabled = true;

            gameTimer.Stop();   // stop the game loop

            ShowCoins();        // bring back any coins that were collected

            // Put Pac-Man back at his starting spot.
            pacman.Location = new Point(490, 350);

            lblInfo.Text = message;   // show the win or lose message
        }
    }
}