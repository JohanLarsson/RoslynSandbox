namespace RoslynSandbox
{
    public class ViewModel : GalaSoft.MvvmLight.ObservableObject
    {
        private int name;

        public string Greeting => $"Hello{this.Name}";

        public int Name
        {
            get { return this.name; }
            set
            {
                if (this.Set(ref this.name, value))
                {
                    this.RaisePropertyChanged(() => this.Greeting);
                }
            }
        }
    }
}