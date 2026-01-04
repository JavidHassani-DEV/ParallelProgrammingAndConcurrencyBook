using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ChapterFourAwaitExample;

public class MainViewModel : ObservableObject
{
    private ObservableCollection<Order> _orders = new();

    public MainViewModel()
    {
        LoadOrderDataCommand = new AsyncRelayCommand(LoadOrderDataAsync);
    }

    public ICommand LoadOrderDataCommand { get; set; }
    public ObservableCollection<Order> Orders
    {
        get { return _orders; }
        set
        {
            SetProperty(ref _orders, value);
        }
    }

    private async Task LoadOrderDataAsync()
    {
        var activeOrdersTask = AddActiveOrdersAsync();
        var archivedOrdersTask = AddArchivedOrdersAsync();

        List<Order>[] results = await Task.WhenAll([activeOrdersTask, archivedOrdersTask]).ConfigureAwait(false);
        ProcessOrders(results[0], results[1]);
    }

    private void ProcessOrders(List<Order> archivedOrders, List<Order> activeOrders)
    {
        var orders = activeOrders.Concat(archivedOrders);
        Orders = new ObservableCollection<Order>(orders);
    }

    private async Task<List<Order>> AddActiveOrdersAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(4));
        // Add directly; await captured the UI synchronization context so we are on the UI thread
        return
        [
            new Order { OrderId = 1, CustomerName = "Bob", IsArchived = false },
            new Order { OrderId = 2, CustomerName = "Alice", IsArchived = false }
        ];
    }

    private async Task<List<Order>> AddArchivedOrdersAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(4));
        return [new Order { OrderId = 3, CustomerName = "Carol", IsArchived = true }, new Order { OrderId = 4, CustomerName = "Carol", IsArchived = true }];
    }

}
