using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FishORamaEngineLibrary;

namespace FishORama
{
    /// CLASS: Simulation class - the main class users code in to set up a FishORama simulation
    /// All tokens to be displayed in the scene are added here
    public class Simulation : IUpdate, ILoadContent
    {
        // CLASS VARIABLES
        // Variables store the information for the class
        private IKernel kernel;                 // Holds a reference to the game engine kernel which calls the draw method for every token you add to it
        private Screen screen;                  // Holds a reference to the screeen dimensions (width, height)
        private ITokenManager tokenManager;     // Holds a reference to the TokenManager - for access to ChickenLeg variable

        /// PROPERTIES
        public ITokenManager TokenManager      // Property to access chickenLeg variable
        {
            set { tokenManager = value; }
        }

        // *** ADD YOUR CLASS VARIABLES HERE ***
        // Variables to hold fish will be declared here
        private string textureID;               // Holds a string to identify asset used for this token
        private float xPosition;                // Holds the X coordinate for token position on screen
        private float yPosition;                // Holds the Y coordinate for token position on screen
        private int xDirection;                 // Holds the direction the token is currently moving - X value should be either -1 (left) or 1 (right)
        private int yDirection;
        float pXpos;
        float pYpos;

        OrangeFish orangeFish1;

        Seahorse seaHorse1;

        Piranha1 piranha;

        Urchin urchin1;

        Random rand;

        int urchinFishWidth = 180;

        int urchinFishHeight = 112;

        int seahorseFishWidth = 74;

        int seahorseFishHeight = 128;

        int piranhaFishWidth = 132;

        int piranhaFishHeight = 128;

        int orangeFishWidth = 128;

        int orangeFishHeight = 64;

        Urchin[] urchinArray = new Urchin[3];  //the array, which is holding 3 urchins

        Seahorse[] seahorseArray = new Seahorse[5]; 

        Piranha1[] piranhaArray = new Piranha1[1];

        OrangeFish[] orangefishArray = new OrangeFish[1];

        int Up = 50;

        int Down = 50;

        /// CONSTRUCTOR - for the Simulation class - run once only when an object of the Simulation class is INSTANTIATED (created)
        /// Use constructors to set up the state of a class
        public Simulation(IKernel pKernel)
        {
            xPosition = pXpos;
            yPosition = pYpos;
            xDirection = 1;
            yDirection = 1;
            kernel = pKernel;                   // Stores the game engine kernel which is passed to the constructor when this class is created
            screen = kernel.Screen;             // Sets the screen variable in Simulation so the screen dimensions are accessible

            // *** ADD OTHER INITIALISATION (class setup) CODE HERE ***

            rand = new Random();


            

        }

        /// METHOD: LoadContent - called once at start of program
        /// Create all token objects and 'insert' them into the FishORama engine
        public void LoadContent(IGetAsset pAssetManager)
        {
            // *** ADD YOUR NEW TOKEN CREATION CODE HERE ***
            // Code to create fish tokens and assign to thier variables goes here
            // Remember to insert each token into the kernel

            int initXpos;
            int initYpos;

            initXpos = rand.Next(-401, 401); // the position randomizer
            initYpos = rand.Next(-401, 401); 

            //urhchin array

            for (int i = 0; i < urchinArray.Length; i++)  // the urchin array
            {
                int xSpeed = 5;
                

                xSpeed = rand.Next(1, 3); // the speed randomizer
                

                initXpos = rand.Next(((screen.width / 2) * -1) + (urchinFishWidth / 2), ((screen.width / 2) + 1) - (urchinFishWidth / 2)); // this will restrict the are where the fish will be able to spawn

                initYpos = rand.Next(((screen.height / 2) * -1) + (urchinFishHeight / 2), ((screen.height / 2 / 4 -210) + 1) - (urchinFishHeight / 2)); // this will restrict the are where the fish will be able to spawn so that it will spawn at the bottom of the screen near rocks and sand

                Urchin tempFish = new Urchin ("Urchin", initXpos, initYpos, // this will be spawning the fish
                screen, tokenManager);

                urchinArray[i] = tempFish; // this is the fish from the array
                kernel.InsertToken(tempFish);
            }

            //seahorse array

            for (int i = 0; i < seahorseArray.Length; i++) // the seahorse array
            {
                int xSpeed = 5;
                int ySpeed = 5;

                xSpeed = rand.Next(2, 6); //the speed randomizer
                ySpeed = xSpeed / 2; // this will half the speed of the horizontal speed/ xSpeed it will make it go at an angle of 45

                initXpos = rand.Next(((screen.width / 2) * -1) + (seahorseFishWidth / 2), ((screen.width / 2) + 1) - (seahorseFishWidth / 2)); // this will restrict the are where the fish will be able to spawn

                initYpos = rand.Next(((screen.height / 2) * -1) + (seahorseFishHeight / 2), ((screen.height / 2) + 1) - (seahorseFishHeight / 2)); // this will restrict the are where the fish will be able to spawn

                Seahorse tempFish = new Seahorse("Seahorse", initXpos, initYpos, // this will be spawning the fish
                screen, tokenManager);

                seahorseArray[i] = tempFish; // this is the fish from the array
                kernel.InsertToken(tempFish);


            }

            //orange Fish spawn

            for (int i = 0; i < orangefishArray.Length; i++) // the orange fish array
            {
                int xSpeed;
                int ySpeed;

                xSpeed = rand.Next(2, 6); // the speed randomizer

                ySpeed = (xSpeed / 2); // this will half the speed of the horizontal speed/ xSpeed

                initXpos = rand.Next(((screen.width / 2) * -1) + (orangeFishWidth / 2), (screen.width / 2) + 1) - (orangeFishWidth / 2); // this will restrict the are where the fish will be able to spawn

                initYpos = rand.Next(((screen.height / 2) * -1) + (orangeFishHeight / 2), ((screen.height / 2) + 1) - (orangeFishHeight / 2)); // this will restrict the are where the fish will be able to spawn

                OrangeFish tempFish = new OrangeFish("OrangeFish", initXpos, initYpos, // this will be spawning the fish
                screen, tokenManager);

                orangefishArray[i] = tempFish; // this is the fish from the array
                kernel.InsertToken(tempFish);
            }

            //piranha Fish spawn

            for (int i = 0; i < piranhaArray.Length; i++) //the piranha fish array
            {
                int xSpeed = 5;
                

                xSpeed = rand.Next(2, 6); //the speed randomizer
               

                initXpos = rand.Next(((screen.width / 2) * -1) + (piranhaFishWidth / 2), ((screen.width / 2) + 1) - (piranhaFishWidth / 2)); // this will restrict the are where the fish will be able to spawn

                initYpos = rand.Next((((screen.height / 2) / 8) * -1) + (piranhaFishHeight / 2), ((screen.height / 2) + 1) - (piranhaFishHeight / 2)); // this will restrict the are where the fish will be able to spawn

                Piranha1 tempFish = new Piranha1("Piranha1", initXpos, initYpos, // this will be spawning the fish
                screen, tokenManager);

                piranhaArray[i] = tempFish; // this is the fish from the array
                kernel.InsertToken(tempFish);
            }
            

        }

        /// METHOD: Update - called 60 times a second by the FishORama engine when the program is running
        /// Add all tokens so Update is called on them regularly
        public void Update(GameTime gameTime)
        {

            // *** ADD YOUR UPDATE CODE HERE ***
            // Each fish object (sitting in a variable) must have Update() called on it here

            foreach (Urchin fish in urchinArray) // this will update the fish's behaviour
            {
                fish.Update();
            }

            foreach (Seahorse fish in seahorseArray) // this will update the fish's behaviour
            {
                fish.Update();
            }

            foreach (Piranha1 fish in piranhaArray) // this will update the fish's behaviour
            {
                fish.Update();
            }
         
            foreach (OrangeFish fish in orangefishArray) // this will update the fish's behaviour
            {
                fish.Update();
            }
            
            
        }
    }
}
