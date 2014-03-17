using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LunchTimeAndroid
{
	[Activity (Label = "LunchTimeAndroid", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button createEventButton = FindViewById<Button> (Resource.Id.createEvent);
			Button notifyButton = FindViewById<Button> (Resource.Id.notify);
			Button exitButton = FindViewById<Button> (Resource.Id.exit);

			createEventButton.Click += delegate {
				notifyButton.Text = string.Format ("Notify ({0})", count++);
		
				exitButton.Click += delegate{
					SetResult(0);
					Finish();
				}

			};
		}
	}
}


