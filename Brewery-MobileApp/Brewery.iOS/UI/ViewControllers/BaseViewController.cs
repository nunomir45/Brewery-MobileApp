using System.ComponentModel;
using Autofac;
using Brewery.Core;
using Brewery.Core.ViewModels;

namespace Brewery.iOS.UI.ViewControllers;

public abstract class BaseViewController<T> : BaseViewController where T : BaseViewModel
    {
        public T _viewModel { get; private set; }

        public BaseViewController()
        { }

        public BaseViewController(IntPtr handle) : base(handle)
        { }

        public override BaseViewModel[] CreateViewModels()
        {
            _viewModel = App.Container.Resolve<T>();
            return new[] { _viewModel };
        }

    }

    public abstract partial class BaseViewController : UIViewController
    {
        private List<BaseViewModel> _viewModels { get; } = new List<BaseViewModel>();
        //public StatusBarBackground StatusBar { get; set; }
        //private LoadingView _loadingView { get; set; }
       

        public BaseViewController()
        { }

        public BaseViewController(string nibName, NSBundle bundle) : base(nibName, bundle)
        { }

        public BaseViewController(IntPtr handle) : base(handle)
        { }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupViewModels();
        }

        public override void ViewWillAppear(bool animated)
        {
            try
            {
                base.ViewWillAppear(animated);

                SetUpBindings();

                _viewModels?.ForEach(vm => vm?.Appearing());
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            try
            {
                CleanUpBindings();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            _viewModels.ForEach(vm => vm.Disappearing());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            CleanViewModels();
        }

        #region ViewModels 

        private void SetupViewModels()
        {
            var viewModels = CreateViewModels();
            AddViewModels(viewModels);
        }

        public abstract BaseViewModel[] CreateViewModels();

        private void AddViewModels(IEnumerable<BaseViewModel> viewModels)
        {
            if (viewModels != null)
            {
                foreach (var viewModel in viewModels)
                {
                    AddViewModel(viewModel);
                }
            }
        }

        private void AddViewModel(BaseViewModel viewModel)
        {
            _viewModels.Add(viewModel);
            viewModel.PropertyChanged += OnPropertyChanged;
        }

        private void CleanViewModels()
        {
            foreach (var viewModel in _viewModels)
            {
                viewModel.PropertyChanged -= OnPropertyChanged;
            }
            _viewModels.Clear();
        }

        #endregion

        protected abstract void SetUpBindings();
        protected abstract void CleanUpBindings();

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BeginInvokeOnMainThread(() =>
            {
                var vm = (BaseViewModel)sender;
                if (e.PropertyName != nameof(vm.IsBusy)) return;
                if (vm.IsBusy)
                {
                    //_loadingView.Show(this.View);
                }
                else
                {
                    //_loadingView.Hide();
                }
            });
        }

        protected void PushViewController(string storyboardString, string viewControllerName)
        {
            BeginInvokeOnMainThread(() =>
            {
                var storyboard = UIStoryboard.FromName(storyboardString, null);
                var viewController = storyboard.InstantiateViewController(viewControllerName);
                
                if (NavigationController != null)
                {
                    NavigationController.PushViewController(viewController, true);
                }
            });
        }
    }