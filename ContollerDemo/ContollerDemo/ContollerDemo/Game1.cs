using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ContollerDemo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Texture2D spriteTexture;
        bool keyA = false, keyB = false, keyX = false, keyY = false;
        bool dPadDown = false, dPadUp = false, dPadLeft = false, dPadRight = false;
        float triggerLT=0;
        float triggerRT=0;
        String leftThumbX, leftThumbY = "";
        String rightThumbX, rightThumbY = "";
        bool leftShoulder, rightShoulder = false;
        int mouseVal = 0;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("spritefont1");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            //Check Triggers
            triggerLT = GamePad.GetState(PlayerIndex.One).Triggers.Left;
            triggerRT = GamePad.GetState(PlayerIndex.One).Triggers.Right;


            //check ShoulderButtons
            //LB
            leftShoulder=    GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed;
            //RB
            rightShoulder = GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed;



            GamePadState gamepad1 =
                 GamePad.GetState(PlayerIndex.One);



            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


                //Check Dpad buttons
               if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                //
                dPadDown = true;
               else if(GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Released)
                dPadDown=   false;

                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                    dPadUp = true;
                else if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Released)
                    dPadUp = false;


                if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                    dPadLeft = true;
                else if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Released)
                    dPadLeft = false;
                       
                if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                    dPadRight = true;
                if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Released)
                    dPadRight = false;
                            
            
            //Check Gamepad buttons

                            //A
                            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                                keyA = true;
                            else if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Released)
                                keyA = false;


                            //B
                               if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
                                keyB = true;
                               else if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Released)
                                keyB = false;

                           //X
                             if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
                                 keyX = true;
                             else if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Released)
                                 keyX = false;

                           //Y
                             if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
                                 keyY = true;
                             else if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Released)
                                 keyY = false;

               //Check ThumbSticks
                         //Left
                             leftThumbX = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X.ToString();
                             leftThumbY = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y.ToString();
                         //Right
                             rightThumbX = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X.ToString();
                             rightThumbY = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y.ToString();




            //Mouse
                             IsMouseVisible = true;

                             
            //Keyboard
                             KeyboardState newState = Keyboard.GetState();


                //exits
                 if( newState.IsKeyDown(Keys.Escape)){
                       this.Exit();
                 }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            //Display trigger values
            spriteBatch.DrawString(font,
                                    "Trigger Values: " +  "Left=" + triggerLT + "     Right=" + triggerRT,
                                    new Vector2(10, 10),
                                    Color.MintCream);
            //Display Button values
            spriteBatch.DrawString(font,
                                    "Buttons: " + "A=" + keyA + ",  B=" +keyB + ", X=" + keyX  + ", Y=" +  keyY,
                                    new Vector2(10, 30),
                                    Color.MintCream);
            //Display Dpad values
            spriteBatch.DrawString(font,
                                    "DPad: " + "Down =" + dPadDown + ",  Up =" + dPadUp + ",  Left =" + dPadLeft + ",  Right =" + dPadRight,
                                    new Vector2(10, 50),
                                    Color.MintCream);
            //Display the Left thumbstick's values
            spriteBatch.DrawString(font,
                                    "Left Thumbstick: " + "X =" + leftThumbX + ",  Y =" + leftThumbY,
                                    new Vector2(10, 70),
                                    Color.MintCream);
            //Display the right thumbstick's values
            spriteBatch.DrawString(font,
                                    "Right Thumbstick: " + "X =" + rightThumbX + ",  Y =" + rightThumbY,
                                    new Vector2(10, 90),
                                    Color.MintCream);
            //Display the shoulder button values
            spriteBatch.DrawString(font,
                                    "Shoulder: " + "LB =" + leftShoulder + ",  RB =" + rightShoulder,
                                    new Vector2(10, 110),
                                    Color.MintCream);
            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
