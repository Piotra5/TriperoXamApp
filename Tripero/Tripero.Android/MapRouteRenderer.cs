//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using CoreLocation;
//using MapKit;
//using Xamarin.Forms.Maps.Android;

/////


///// Map route renderer for iOS.
/////
///// The map used in this implementation is called BindableMap, enherit from Xamarin.Forms.Maps
///// and implements a List<Xamarin.Forms.Maps.Points> RouteCoordinates with a BindableProperty
///// implementation for easy access. The name of the BindableProperty is RouteCoordinatesProperty.
//public class MapRouteRenderer : MapRenderer
//{
//    ///

//    /// The visual data for the map route on the map.
//    /// </summary
//    MKPolylineRenderer polylineRenderer;
//    /// <summary>
//    /// Empty constructor is redundant.... Initializes a new instance of the <see cref="T:MyMapApp.iOS.Renderer.Maps.MapRouteRenderer"/> class.
//    /// </summary>
//    public MapRouteRenderer()
//    {
//    }

//    /// <summary>
//    /// Called when any bindable property on the Map view changes. This is used to handle changes
//    /// to the route line on the map.
//    /// </summary>
//    /// <param name="sender">Sender of the event; in this case the MapView of the type BindableMap</param>
//    /// <param name="e">The property that had some change applied.</param>
//    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
//    {
//        base.OnElementPropertyChanged(sender, e);

//        if (null == this.Element || null == this.Control)
//            return;

//        if (e.PropertyName == BindableMap.RouteCoordinatesProperty.PropertyName)
//        {
//            UpdatePolyLine((BindableMap)sender);
//        }
//    }

//    /// <summary>
//    /// Every time an element changes, this is fired.
//    /// </summary>
//    /// It is not enough to update the route line on the map - as this seems to fire
//    /// only when the Xamarin map is created, not if the parameters are changing.
//    /// <param name="e">E.</param>
//    protected override void OnElementChanged(ElementChangedEventArgs<View> e)
//    {
//        base.OnElementChanged(e);

//        if (e.OldElement != null)
//        {
//            var nativeMap = Control as MKMapView;
//            if (nativeMap != null)
//            {
//                nativeMap.RemoveOverlays(nativeMap.Overlays);
//                nativeMap.OverlayRenderer = null;
//                polylineRenderer = null;
//            }
//        }

//        if (e.NewElement != null)
//        {
//            var formsMap = (BindableMap)e.NewElement;

//            UpdatePolyLine(formsMap);
//        }
//    }

//    /// <summary>
//    /// The common method between <seealso cref="OnElementChanged(ElementChangedEventArgs{View})"/> 
//    /// and <seealso cref="OnElementPropertyChanged(object, PropertyChangedEventArgs)"/> to actually 
//    /// change the polyline data for the renderer to use later.
//    /// </summary>
//    /// <param name="map">The map object containing the new map route line data.</param>
//    private void UpdatePolyLine(BindableMap map)
//    {
//        var nativeMap = Control as MKMapView;

//        nativeMap.OverlayRenderer = GetOverlayRenderer;

//        CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[map.RouteCoordinates.Count];

//        int index = 0;
//        foreach (var position in map.RouteCoordinates)
//        {
//            coords[index++] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
//        }

//        var routeOverlay = MKPolyline.FromCoordinates(coords);
//        nativeMap.AddOverlay(routeOverlay);
//    }

//    /// <summary>
//    /// The overlay renderer for the native map, using previous stored polyline data.
//    /// </summary>
//    /// <returns>The overlay renderer.</returns>
//    /// <param name="mapView">The native map view.</param>
//    /// <param name="overlayWrapper">Overlay wrapper.</param>
//    MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlayWrapper)
//    {
//        if (polylineRenderer == null && !Equals(overlayWrapper, null))
//        {
//            var overlay = ObjCRuntime.Runtime.GetNSObject(overlayWrapper.Handle) as IMKOverlay;
//            polylineRenderer = new MKPolylineRenderer(overlay as MKPolyline)
//            {
//                FillColor = UIColor.Blue,
//                StrokeColor = UIColor.Red,
//                LineWidth = 3,
//                Alpha = 0.4f
//            };
//        }
//        return polylineRenderer;
//    }
//}