# FormsLeakTest2

A solution which demonstrates what appears to be a leak in Xamarin.Forms on Android, when using FreshMvvm

## Findings
Navigating to a page (Basic2Page) using CoreMethods.PushPageModel, and then back using the back button, leaves the Basic2Page un-garbage collected.

## How we're detecting un-garbage collected Pages
The static class _MemoryTracker_ allows a weak reference to an object to be held, using its _Track_ method.

We add a weak reference to the Basic2Page by calling _MemoryTracker.Track(self)_ in the page's constructor.

We also add a weak reference to an array of ints in the page's constructor.

In the OnDisappearing override, we set the int array to null.

In the first page's OnAppearing override, we output the number of tracked objects which are still live (i.e. not Garbage Collected).

We can see that every time we navigate to Basic2Page and back, one tracked object is left in the Tracker. This shows that setting the IntArray to null, allows IntArray to be Garbage Collected, but the Basic2Page has not been collected.
