using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsLeakTest
{
    public partial class BasicPage : ContentPage
    {
        public BasicPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Call GC.Collect a few times to clean up
            GC.Collect();
            GC.Collect();
            GC.Collect();

            // Output the number of tracked objects which haven't been garbage collected
			int aliveObjectsCount = MemoryTracker.GetAliveObjectsCount();
			System.Diagnostics.Debug.WriteLine("Alive Tracked Objects: " + aliveObjectsCount);

 
        }
    }
}
