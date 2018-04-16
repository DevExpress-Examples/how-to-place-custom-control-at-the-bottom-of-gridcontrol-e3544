using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Grid;
using System.Windows.Interactivity;
using System.Windows;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Core;
using System.Windows.Controls;
using System.Windows.Data;

namespace Q346919 {
    public class GridCustomBehavior : Behavior<TableView> {
        public static readonly DependencyProperty GridBottomContentProperty =
            DependencyProperty.Register("GridBottomContent", typeof(object), typeof(GridCustomBehavior),
            new PropertyMetadata(null));
        public static readonly DependencyProperty GridBottomContentTemplateProperty =
            DependencyProperty.Register("GridBottomContentTemplate", typeof(DataTemplate), typeof(GridCustomBehavior),
            new PropertyMetadata(null));
        public object GridBottomContent {
            get { return (object)GetValue(GridBottomContentProperty); }
            set { SetValue(GridBottomContentProperty, value); }
        }
        public DataTemplate GridBottomContentTemplate {
            get { return (DataTemplate)GetValue(GridBottomContentTemplateProperty); }
            set { SetValue(GridBottomContentTemplateProperty, value); }
        }

        public GridCustomBehavior() {
            GridBottomControl = new ContentControl();
            BindingOperations.SetBinding(GridBottomControl, ContentControl.ContentProperty, new Binding("GridBottomContent") { Source = this });
            BindingOperations.SetBinding(GridBottomControl, ContentControl.ContentTemplateProperty, new Binding("GridBottomContentTemplate") { Source = this });
        }
        protected ContentControl GridBottomControl { get; private set; }
        protected TableView GridView { get { return AssociatedObject; } }
        protected override void OnAttached() {
            base.OnAttached();
            GridView.Loaded += OnGridLoaded;
        }
        void OnGridLoaded(object sender, RoutedEventArgs e) {
            GridView.Loaded -= OnGridLoaded;
            FilterPanelControl filterPanel = LayoutHelper.FindElementByName(GridView, "PART_FilterPanel") as FilterPanelControl;
            if(filterPanel == null) return;
            DXDockPanel dockPanel = filterPanel.Parent as DXDockPanel;
            if(dockPanel == null) return;
            DXDockPanel.SetDock(GridBottomControl, Dock.Bottom);
            dockPanel.Children.Insert(0, GridBottomControl);
        }
    }
}
