namespace Captions.Viewmodels
{
    public abstract class ListViewModel
    {

        public int CurrentPageNumber { get; set; }
        public bool EndOfSearch { get; set; }
    }
}