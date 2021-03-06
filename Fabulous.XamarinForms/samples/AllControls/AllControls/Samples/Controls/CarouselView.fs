namespace AllControls.Samples.Controls

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module CarouselView =
    let indicatorRef = ViewRef<IndicatorView>()
        
    let carouselViewView () =
        View.NonScrollingContentPage(
            title = "CarouselView & IndicatorView sample",
            backgroundColor = Color.Black,
            content = View.StackLayout([
                View.IndicatorView(
                    ref = indicatorRef,
                    margin = Thickness(0., 10., 0., 0.)
                )
                
                View.CarouselView(
                    indicatorView = indicatorRef,
                    verticalOptions = LayoutOptions.FillAndExpand,
                    items = [
                        for i = 0 to 15 do
                            yield View.StackLayout(
                                backgroundColor = randomColor(),
                                children = [
                                    View.Label(
                                        horizontalOptions = LayoutOptions.Center,
                                        verticalOptions = LayoutOptions.CenterAndExpand,
                                        text = sprintf "Person %i" i
                                    )
                                ]
                            )
                    ]
                )
            ])
        )
    
    let view () =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android -> 
            carouselViewView()

        | _ -> 
            View.ContentPage(
                View.StackLayout [
                    View.Label(text = "Your Platform does not support CarouselView")
                ]
            )