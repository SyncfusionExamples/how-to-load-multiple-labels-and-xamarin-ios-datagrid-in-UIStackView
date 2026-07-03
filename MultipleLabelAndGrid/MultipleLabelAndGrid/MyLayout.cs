using Syncfusion.SfDataGrid;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace MultipleLabelAndGrid
{
    public class GridInStackView : UIViewController
    {
        UIStackView stackView;
        SfDataGrid grid1;
        UILabel firstLabel;
        UILabel secondLabel;
        SfDataGrid grid2;
        UILabel thirdLabel;
        SfDataGrid grid3;
        public GridInStackView()
        {
            stackView = new UIStackView();
            stackView.Axis = UILayoutConstraintAxis.Vertical;

            firstLabel = new UILabel();
            firstLabel = GetHeaderLabel("Label1");

            grid1 = new SfDataGrid();
            grid1 = GetGrid();

            UIButton b = new UIButton();
            b.TouchUpInside += B_TouchUpInside;

            secondLabel = new UILabel();
            secondLabel = GetHeaderLabel("Label2");

            grid2 = new SfDataGrid();
            grid2 = GetGrid();

            thirdLabel = new UILabel();
            thirdLabel = GetHeaderLabel("Label3");

            grid3 = new SfDataGrid();
            grid3 = GetGrid();



            View.BackgroundColor = UIColor.White;
            stackView.AddArrangedSubview(firstLabel);
            stackView.AddArrangedSubview(grid1);
            stackView.AddArrangedSubview(secondLabel);
            stackView.AddArrangedSubview(grid2);
            stackView.AddArrangedSubview(thirdLabel);
            stackView.AddArrangedSubview(grid3);
            View.AddSubview(stackView);

        }

        private void B_TouchUpInside(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private SfDataGrid GetGrid()
        {
            SfDataGrid grid = new SfDataGrid();
            grid.ItemsSource = new ViewModel().OrdersInfo;
            grid.SelectionMode = SelectionMode.None;
            grid.ShowRowHeader = false;
            grid.HeightAnchor.ConstraintEqualTo(200).Active = true;
            return grid;
        }

        private UILabel GetHeaderLabel(string text)
        {
            var label = new UILabel();
            label.Text = text;
            label.TextAlignment = UITextAlignment.Center;
            label.HeightAnchor.ConstraintEqualTo(20).Active = true;
            label.BackgroundColor = UIColor.Gray;
            return label;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            stackView.Frame = new CoreGraphics.CGRect(0, 20, this.View.Frame.Width, this.View.Frame.Height);
        }
    }
}
