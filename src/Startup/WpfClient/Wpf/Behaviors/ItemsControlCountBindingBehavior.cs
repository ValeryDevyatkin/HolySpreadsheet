using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace WpfClient.Wpf.Behaviors
{
    public class ItemsControlCountBindingBehavior : Behavior<ItemsControl>
    {
        private INotifyCollectionChanged _collectionChangeNotifier;

        protected override void OnAttached()
        {
            base.OnAttached();

            _collectionChangeNotifier = AssociatedObject.Items;
            _collectionChangeNotifier.CollectionChanged += CollectionChangedOnCollectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            _collectionChangeNotifier.CollectionChanged -= CollectionChangedOnCollectionChanged;
        }

        private void CollectionChangedOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            ItemCount = AssociatedObject.Items.Count;
        }

        #region ItemCount dependency: int

        public static readonly DependencyProperty ItemCountProperty =
            DependencyProperty.Register(
                nameof(ItemCount),
                typeof(int),
                typeof(ItemsControlCountBindingBehavior),
                new PropertyMetadata(default(int)));

        public int ItemCount
        {
            get => (int) GetValue(ItemCountProperty);
            set => SetValue(ItemCountProperty, value);
        }

        #endregion
    }
}