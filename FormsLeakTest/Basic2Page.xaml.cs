using System;
using System.Collections.Generic;


using Xamarin.Forms;

namespace FormsLeakTest
{
	public partial class Basic2Page : ContentPage
	{
        private int[] IntArray;
		public Basic2Page()
		{
			InitializeComponent();

            // Track this page
            MemoryTracker.Track(this);

            // Create an array of ints and track it
            IntArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MemoryTracker.Track(IntArray);
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Set IntArray to null - this allows the Garbage Collecter to collect it
            IntArray = null;
        }
	}
}
