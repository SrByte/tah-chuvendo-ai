using TahChuvendoAi.ViewModels;

namespace TahChuvendoAi.Views;

public partial class SearchResult : ContentPage
{
    public SearchResult(SearchResultViewModel searchResultViewModel)
	{
		InitializeComponent();
        BindingContext = searchResultViewModel;
    }
}