using SnippetGUI.Data;
using System.Collections.ObjectModel;

namespace SnippetGUI.ViewModel
{
    /// <summary>
    /// ViewModel for the MainWindow
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        private readonly IDataAccess dataAccess;

        private string title;
        /// <summary>
        /// The title of the snippet
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string author;
        /// <summary>
        /// The author of the snippet
        /// </summary>
        public string Author
        {
            get => author;
            set
            {
                if (author != value)
                {
                    author = value;
                    OnPropertyChanged();
                }
            }
        }

        private string description;
        /// <summary>
        /// The description of the snippet
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        private string shortcut;
        /// <summary>
        /// The shortcut to access the snippet
        /// </summary>
        public string Shortcut
        {
            get => shortcut;
            set
            {
                if (shortcut != value)
                {
                    shortcut = value;
                    OnPropertyChanged();
                }
            }
        }

        private string language;
        /// <summary>
        /// The language the snippet applies to
        /// </summary>
        public string Language
        {
            get => language;
            set
            {
                if (language != value)
                {
                    language = value;
                    OnPropertyChanged();
                }
            }
        }

        private string code;
        /// <summary>
        /// The code for the snippet
        /// </summary>
        public string Code
        {
            get => code;
            set
            {
                if (code != value)
                {
                    code = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<string> languages;
        /// <summary>
        /// Available languages that the snippet can be coded in
        /// </summary>
        public ObservableCollection<string> Languages
        {
            get => languages;
            set
            {
                if (languages != value)
                {
                    languages = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Construct a new MainViewModel
        /// </summary>
        /// <param name="dataAccess"> Data Access for config files </param>
        public MainViewModel(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess ?? new DataAccess();
            Languages = new ObservableCollection<string>(this.dataAccess.GetLanguages());
        }

        public MainViewModel() : this(new DataAccess()) { }

        #endregion
    }
}