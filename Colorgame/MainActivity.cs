using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace Colorgame
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private readonly string[] colors = { "Red", "Blue", "Green", "Yellow", "Purple", "Orange" };
        private readonly Random random = new Random();
        private int score = 100;
        private TextView scoreDisplay;
        private View dice1, dice2, dice3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            dice1 = FindViewById<View>(Resource.Id.dice1);
            dice2 = FindViewById<View>(Resource.Id.dice2);
            dice3 = FindViewById<View>(Resource.Id.dice3);
            scoreDisplay = FindViewById<TextView>(Resource.Id.scoreDisplay);

            RollDice();

            // Set up the buttons
            SetupButton(Resource.Id.betRed, Android.Graphics.Color.Red);
            SetupButton(Resource.Id.betBlue, Android.Graphics.Color.Blue);
            SetupButton(Resource.Id.betGreen, Android.Graphics.Color.Green);
            SetupButton(Resource.Id.betYellow, Android.Graphics.Color.Yellow);
            SetupButton(Resource.Id.betPurple, Android.Graphics.Color.Purple);
            SetupButton(Resource.Id.betOrange, Android.Graphics.Color.Orange);
        }


        private void SetupButton(int buttonId, Android.Graphics.Color color)
        {
            Button button = FindViewById<Button>(buttonId);
            button.Click += (sender, e) => PlaceBet(color);
        }

        private void RollDice()
        {
            dice1.SetBackgroundColor(GetRandomColor());
            dice2.SetBackgroundColor(GetRandomColor());
            dice3.SetBackgroundColor(GetRandomColor());
        }

        private Android.Graphics.Color GetRandomColor()
        {
            var color = colors[random.Next(colors.Length)];
            switch (color)
            {
                case "Red":
                    return Android.Graphics.Color.Red;
                case "Blue":
                    return Android.Graphics.Color.Blue;
                case "Green":
                    return Android.Graphics.Color.Green;
                case "Yellow":
                    return Android.Graphics.Color.Yellow;
                case "Purple":
                    return Android.Graphics.Color.Purple;
                case "Orange":
                    return Android.Graphics.Color.Orange;
                default:
                    return Android.Graphics.Color.Black; // Default color
            }
        }

        private void PlaceBet(Android.Graphics.Color color)
        {
            if (dice1.Background is Android.Graphics.Drawables.ColorDrawable colorDrawable1 && colorDrawable1.Color == color ||
                dice2.Background is Android.Graphics.Drawables.ColorDrawable colorDrawable2 && colorDrawable2.Color == color ||
                dice3.Background is Android.Graphics.Drawables.ColorDrawable colorDrawable3 && colorDrawable3.Color == color)
            {
                // The player wins, double the bet
                score += 10;
            }
            else
            {
                // The player loses, subtract the bet
                score -= 10;
            }

            // Update score display
            scoreDisplay.Text = $"Score: {score}";

            // Roll the dice again for the next round
            RollDice();
        }
    


public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}