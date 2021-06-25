using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ResolveDayPlanner.ViewModels
{
    public class ListCell : ViewCell
    {
        public ListCell()
        {
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.6, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            var ErrandTitleLabel = new Label { FontSize = 18, FontAttributes = FontAttributes.Bold, Style = Device.Styles.ListItemTextStyle };
            var DescriptionLabel = new Label() { FontSize = 15, Style = Device.Styles.ListItemTextStyle };
            var PriorityLabel = new Label { FontSize = 18, HorizontalTextAlignment = TextAlignment.End, Style = Device.Styles.ListItemTextStyle };

            ErrandTitleLabel.SetBinding(Label.TextProperty, "ErrandTitle");
            DescriptionLabel.SetBinding(Label.TextProperty, "Description");
            PriorityLabel.SetBinding(Label.TextProperty, "Priority");


            grid.Children.Add(ErrandTitleLabel);
            grid.Children.Add(DescriptionLabel, 0, 1);
            grid.Children.Add(PriorityLabel, 2, 0);

            View = grid;
        }
    }
}
